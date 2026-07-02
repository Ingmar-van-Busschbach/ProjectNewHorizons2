using System.Collections;
using UnityEngine;

public class StatImprovementRoom : Room
{
    [SerializeField] private EStatToImprove statToImprove;
    [SerializeField] private int improveAmount;
    [SerializeField] private StatPlugs statPlugs;
    private void Start()
    {
        StartCoroutine(ImproveStats());
    }

    private IEnumerator ImproveStats()
    {
        collectButton.gameObject.SetActive(false);
        currentTime = timeToProduce;
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(0.1f);
            if (characterIndex.Count > 0)
            {
                currentTime -= 0.1f;
            }
        }
        collectButton.gameObject.SetActive(true);
    }

    public void AddStats()
    {
        foreach(Character character in characterIndex.Keys)
        {
            Stat stat = new Stat();
            switch (statToImprove)
            {
                case EStatToImprove.Resourcefulness:
                    stat.recourcefulness = improveAmount;
                    break;
                case EStatToImprove.Athletics:
                    stat.athletics = improveAmount;
                    break;
                case EStatToImprove.Tempo:
                    stat.tempo = improveAmount;
                    break;
                case EStatToImprove.Smarts:
                    stat.smarts = improveAmount;
                    break;
            }
            character.stats.Add(stat);
            character.stats.ClampToMaxStats(statPlugs.MaxStats());
        }
        collectSound.Play();
        StartCoroutine(ImproveStats());
    }
}
