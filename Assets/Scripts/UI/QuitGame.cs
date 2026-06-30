using UnityEngine;

public class QuitGame : MonoBehaviour
{
#if UNITY_WEBGL
    void Start()
    {
        this.gameObject.SetActive(false);
    }
#endif
    public void HandleQuit()
    {
        Application.Quit();
    }
}
