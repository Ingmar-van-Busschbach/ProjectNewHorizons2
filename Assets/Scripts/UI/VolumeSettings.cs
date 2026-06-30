using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;
    
    public void ApplySettings()
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(slider.value)*20);
    }
}
