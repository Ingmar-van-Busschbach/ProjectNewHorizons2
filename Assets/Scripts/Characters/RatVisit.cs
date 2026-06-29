using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatVisit : MonoBehaviour
{
    [SerializeField] private float ratVisitorCooldown;
    [SerializeField] private Character ratPrefab;
    [Tooltip("spawnPosition should be just outside of screen so it seems the rat walks to colony")]
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Room room;
    [SerializeField] private int count;

    private Room[] rooms;
    private int maxRats;
    private int assignedRats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rooms = FindObjectsByType<Room>(FindObjectsSortMode.InstanceID);
        StartCoroutine(RatVisitor());
    }

    IEnumerator RatVisitor()
    {
        maxRats = 0;
        assignedRats = 0;
        foreach (Room room in rooms)
        {
            if (room.unlockedRoom)
            {
                maxRats += room.characterLocations.Count;
                assignedRats += room.characterIndex.Count;
            }
        }
        // -4 to ignore the plague spreading room, and leave 1 open spot.
        if(assignedRats < maxRats - 4)
        {
            count++;
            Character spawnedRat = Instantiate(ratPrefab, spawnPosition.position, transform.rotation);
            spawnedRat.gameObject.name = "Rat " + count;
            Transform roomLocation = room.AssignCharacter(spawnedRat);
            if (roomLocation == spawnedRat.gameObject.transform) { Destroy(spawnedRat.gameObject); }
            else
            {
                spawnedRat.MoveToLocation(roomLocation);
                ResourceManager.instance.ResourceHandler(EResourceType.Rats, 1);
            }
            yield return new WaitForSeconds(ratVisitorCooldown);
            StartCoroutine(RatVisitor());
        }
        else
        {
            yield return new WaitForSeconds(10f);
            StartCoroutine(RatVisitor());
        }
        
    }


}
