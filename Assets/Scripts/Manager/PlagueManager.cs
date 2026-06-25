using UnityEngine.UI;
using UnityEngine;

public class PlagueManager : MonoBehaviour
{
    public static PlagueManager instance;
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
}
