using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RoomResourceHandler : Room
{
    [Header("Room Resource Handler")]
    public ERoomType roomType;
    
    [Header("Amount to produce per resource")]
    public int nutritionAmount;
    public int woodAmount;
    public int stoneAmount;
    public int metalAmount;
    public int plagueVialAmount;
    public bool canSwitchResourceTypes;
    [Tooltip("The effectiveness the stats have when at minimum and maximum stat values. Should be a number between 0-1 and 1-2, with both being the same value away from 1.")]
    [SerializeField] private Vector2 statEffectiveness;

    [Header("audio per resource (resource room only)")]
    public AudioClip woodAudioClip;
    public AudioClip stoneAudioClip;
    public AudioClip metalAudioClip;

    public Sprite woodSprite;
    public Sprite stoneSprite;
    public Sprite metalSprite;
    public Sprite nutritionSprite;
    public Sprite vialSprite;

    [SerializeField] private AudioClip woodCollectionSound;
    [SerializeField] private AudioClip stoneCollectionSound;
    [SerializeField] private AudioClip metalCollectionSound;
    [SerializeField] private AudioClip nutritionCollectionSound;
    [SerializeField] private AudioClip vialCollectionSound;

    private void Start()
    {
        StartCoroutine(ResourceHandler());
    }
    private IEnumerator ResourceHandler()
    {
        collectButton.gameObject.SetActive(false);
        currentTime = timeToProduce;
        while(currentTime > 0)
        {
            yield return new WaitForSeconds(0.1f);
            if(characterIndex.Count > 0)
            {
                float averageStat = 0;
                if(roomType == ERoomType.ResearchRoom)
                {
                    foreach (Character character in characterIndex.Keys)
                    {
                        averageStat += character.GetSmarts();
                    }
                }
                else
                {
                    foreach (Character character in characterIndex.Keys)
                    {
                        averageStat += character.GetRecourcefulness();
                    }
                }  
                if (characterIndex.Count > 0)
                {
                    averageStat = averageStat / characterIndex.Count;
                }
                else
                {
                    averageStat = 1;
                }
                averageStat = RemapFloat(averageStat, new Vector2(0, 2), statEffectiveness);
                currentTime -= 0.1f * averageStat;
            }
        }
        if (canSwitchResourceTypes)
        {
            switch (roomType)
            {
                case ERoomType.NutritionRoom:
                    collectButton.image.sprite = nutritionSprite;
                    break;
                case ERoomType.ResourceRoomWood:
                    collectButton.image.sprite = woodSprite;
                    break;
                case ERoomType.ResourceRoomStone:
                    collectButton.image.sprite = stoneSprite;
                    break;
                case ERoomType.ResourceRoomMetal:
                    collectButton.image.sprite = metalSprite;
                    break;
                case ERoomType.ResearchRoom:
                    collectButton.image.sprite = vialSprite;
                    break;
            }
        }
        collectButton.gameObject.SetActive(true);
    }

    public void AddResources()
    {
        switch (roomType)
        {
            case ERoomType.NutritionRoom:
                collectSound.clip = nutritionCollectionSound;
                ResourceManager.instance.ResourceHandler(EResourceType.Nutrition, nutritionAmount * characterIndex.Count);
                break;
            case ERoomType.ResourceRoomWood:
                collectSound.clip = woodCollectionSound;
                ResourceManager.instance.ResourceHandler(EResourceType.Wood, woodAmount * characterIndex.Count);
                break;
            case ERoomType.ResourceRoomStone:
                collectSound.clip = stoneCollectionSound;
                ResourceManager.instance.ResourceHandler(EResourceType.Stone, stoneAmount * characterIndex.Count);
                break;
            case ERoomType.ResourceRoomMetal:
                collectSound.clip = metalCollectionSound;
                ResourceManager.instance.ResourceHandler(EResourceType.Metal, metalAmount * characterIndex.Count);
                break; 
            case ERoomType.ResearchRoom:
                collectSound.clip = vialCollectionSound;
                ResourceManager.instance.ResourceHandler(EResourceType.PlagueVials, plagueVialAmount * characterIndex.Count);
                break;
        }
        collectSound.Play();
        StartCoroutine(ResourceHandler());
    }

    public float RemapFloat(float value, Vector2 rangeA, Vector2 rangeB)
    {
        float t = Mathf.InverseLerp(rangeA.x, rangeA.y, value);
        return Mathf.Lerp(rangeB.x, rangeB.y, t);
    }
}
