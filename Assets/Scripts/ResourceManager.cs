using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;

    [Tooltip("amount of seconds in one day/night cycle")]
    [SerializeField] private float dayCycleTime = 1;

    [Header("resources")]
    [SerializeField] private int rats = 2;

    [Tooltip("Amount of nutrition rats start with")]
    [SerializeField] private int NutritionStarter = 100;

    [Tooltip("amount nutrition drained per rat per day")]
    [SerializeField] private int nutritionDrain;

    [Header("UI")]
    [SerializeField] TMP_Text ratCounter;
    [SerializeField] TMP_Text nutritionCounter;
    [SerializeField] TMP_Text woodCounter;
    [SerializeField] TMP_Text stoneCounter;
    [SerializeField] TMP_Text metalCounter;
    [SerializeField] Slider plagueSlider;
    [SerializeField] TMP_Text PlagueVialCounter;

    [Header("Storage")]
    [Tooltip("max storage per item without any storage room")]
    public int nutritionStorage;
    public int buildresourceStorage;
    public int plagueVileStorage;

    [Header("material amounts")]
    [HideInInspector] public int nutrition;
    [HideInInspector] public int stone;
    [HideInInspector] public int wood;
    [HideInInspector] public int metal;
    [HideInInspector] public int plague;
    [HideInInspector] public int plagueVials;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        nutrition = NutritionStarter;
        nutritionCounter.text = nutrition.ToString();
        StartCoroutine(DayCycle());
    }

    public IEnumerator DayCycle()
    {
        yield return new WaitForSeconds(dayCycleTime);
        nutrition -= nutritionDrain * rats;
        nutritionCounter.text = nutrition.ToString();
        if (nutrition < 0 || rats < 0)
        {
            Debug.Log("oops you failed");
        }

        Debug.Log("ending day...");
        StartCoroutine(DayCycle());
    }
    public void ResourceHandler(EResourceType resource, int amount)
    {
        switch (resource)
        {
            case EResourceType.Rats:
                rats += amount;
                ratCounter.text = rats.ToString();
                break;
            case EResourceType.Nutrition:
                nutrition += amount;
                nutrition = Mathf.Clamp(nutrition, 0, nutritionStorage);
                nutritionCounter.text = nutrition.ToString();
                break;
            case EResourceType.Wood: 
                wood += amount;
                wood = Mathf.Clamp(wood, 0, buildresourceStorage);
                woodCounter.text = wood.ToString();
                break;
            case EResourceType.Stone:
                stone += amount;
                stone = Mathf.Clamp (stone, 0, buildresourceStorage);
                stoneCounter.text = stone.ToString();
                break;
            case EResourceType.Metal:
                metal += amount;
                metal = Mathf.Clamp(metal, 0, buildresourceStorage);
                metalCounter.text = metal.ToString();
                break;
            case EResourceType.Plague:
                plague += amount;
                plagueSlider.value = plague; 
                break;
            case EResourceType.PlagueVials:
                plagueVials += amount;
                plagueVials = Mathf.Clamp(plagueVials, 0, plagueVileStorage);
                PlagueVialCounter.text = plagueVials.ToString();
                break;
                
        }
    }

}
