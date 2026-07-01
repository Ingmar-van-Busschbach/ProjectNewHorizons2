using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RatStatDisplay : MonoBehaviour
{
    [SerializeField] private Slider resourcefulness;
    [SerializeField] private Slider athletics;
    [SerializeField] private Slider tempo;
    [SerializeField] private Slider smarts;
    [SerializeField] private TMP_Text ratNameText;
    [SerializeField] private Button infectButton;
    private Character character;
    private Stat ratStats;
    public void DisplayStats(Stat ratStats, StatPlugs statPlugs, string ratName, Character character)
    {
        this.character = character;
        this.ratStats = ratStats;
        Stat maxStats = statPlugs.MaxStats();
        resourcefulness.maxValue = maxStats.recourcefulness;
        athletics.maxValue = maxStats.athletics;
        tempo.maxValue = maxStats.tempo;
        smarts.maxValue = maxStats.smarts;

        ratNameText.text = ratName;
    }

    public void Infect()
    {
        if(ResourceManager.instance.plagueVials > 0)
        {
            character.isInfected = true;
            ResourceManager.instance.ResourceHandler(EResourceType.PlagueVials, -1);
        }
        infectButton.gameObject.SetActive(ResourceManager.instance.plagueVials > 0);
    }

    public void Update()
    {
        if (character != null)
        {
            infectButton.gameObject.SetActive(ResourceManager.instance.plagueVials > 0 && !character.isInfected);

        }
        if (ratStats != null)
        {
            resourcefulness.value = ratStats.recourcefulness;
            athletics.value = ratStats.athletics;
            tempo.value = ratStats.tempo;
            smarts.value = ratStats.smarts;
        }
    }
}
