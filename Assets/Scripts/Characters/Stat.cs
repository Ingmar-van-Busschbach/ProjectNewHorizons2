using UnityEngine;

[System.Serializable]
public class Stat
{
    public int recourcefulness;
    public int athletics;
    public int tempo;
    public int smarts;

    public void Add(Stat stat)
    {
        recourcefulness += stat.recourcefulness;
        athletics += stat.athletics;
        tempo += stat.tempo;
        smarts += stat.smarts;
    }

    public void ClampToMaxStats(Stat maxStats)
    {
        recourcefulness = Mathf.Clamp(recourcefulness, 0, maxStats.recourcefulness);
        athletics = Mathf.Clamp(athletics, 0, maxStats.athletics);
        tempo = Mathf.Clamp(tempo, 0, maxStats.tempo);
        smarts = Mathf.Clamp(smarts, 0, maxStats.smarts);
    }

    public void Debug()
    {
        UnityEngine.Debug.Log("Stats: " + recourcefulness + ", " + athletics + ", " + tempo + ", " + smarts);
    }
}
