using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DropDownHandler))]
public class RoomInfoHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text roomNameText;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TMP_Text produceAmountText;
    [SerializeField] private Image produceImage;
    [SerializeField] private TMP_Text ratCount;
    private DropDownHandler dropDownHandler;

    private Room currentRoom;
    private RoomResourceHandler roomResourceHandler;

    private void Start()
    {
        dropDownHandler = GetComponent<DropDownHandler>();
    }

    public void DisplayInfo(Room room)
    {
        currentRoom = room;
        if (room.gameObject.TryGetComponent(out RoomResourceHandler resourceRoom))
        {
            roomResourceHandler = resourceRoom;
            dropDownHandler.room = resourceRoom;
            dropDownHandler.dropdown.gameObject.SetActive(resourceRoom.canSwitchResourceTypes);
            switch (resourceRoom.roomType)
            {
                case ERoomType.ResourceRoomWood:
                    dropDownHandler.dropdown.value = 0;
                    break;
                case ERoomType.ResourceRoomStone:
                    dropDownHandler.dropdown.value = 1;
                    break;
                case ERoomType.ResourceRoomMetal:
                    dropDownHandler.dropdown.value = 2;
                    break;
            }
            
            UpdateProductionAmountDisplay();
        }
        else
        {
            dropDownHandler.dropdown.gameObject.SetActive(false);
        }
        roomNameText.text = room.roomName;
    }

    public void UpdateProductionAmountDisplay()
    {
        if(roomResourceHandler != null)
        {
            switch (roomResourceHandler.roomType)
            {
                case ERoomType.NutritionRoom:
                    produceAmountText.text = roomResourceHandler.nutritionAmount.ToString();
                    produceImage.sprite = roomResourceHandler.nutritionSprite;
                    break;
                case ERoomType.ResourceRoomWood:
                    produceAmountText.text = roomResourceHandler.woodAmount.ToString();
                    produceImage.sprite = roomResourceHandler.woodSprite;
                    break;
                case ERoomType.ResourceRoomStone:
                    produceAmountText.text = roomResourceHandler.stoneAmount.ToString();
                    produceImage.sprite = roomResourceHandler.stoneSprite;
                    break;
                case ERoomType.ResourceRoomMetal:
                    produceAmountText.text = roomResourceHandler.metalAmount.ToString();
                    produceImage.sprite = roomResourceHandler.metalSprite;
                    break;
                case ERoomType.ResearchRoom:
                    produceAmountText.text = roomResourceHandler.plagueVialAmount.ToString();
                    produceImage.sprite = roomResourceHandler.vialSprite;
                    break;
            }
        }
    }

    private void Update()
    {
        if(roomResourceHandler != null)
        {
            progressBar.maxValue = currentRoom.timeToProduce;
            progressBar.value = currentRoom.timeToProduce - currentRoom.currentTime;
        }
        if(currentRoom != null)
        {
            ratCount.text = currentRoom.characterIndex.Count.ToString() + "/" + currentRoom.characterLocations.Count.ToString();
        }
    }
}
