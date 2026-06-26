using UnityEngine;

public class RoomStorageHandler : Room
{
    [Header("Amount storage will go up by")]
    [Tooltip("this amount + original nutrition = new nutrition storage")]
    [SerializeField] private int additionalNutrition;
    [SerializeField] private int additionalBuildingResources;
    [SerializeField] private int additionalPlagueVials;

    public void storageUpgrade()
    {
        ResourceManager.instance.buildresourceStorage += additionalBuildingResources;
        ResourceManager.instance.nutritionStorage += additionalNutrition;
        ResourceManager.instance.plagueVileStorage += additionalPlagueVials;
    }

}
