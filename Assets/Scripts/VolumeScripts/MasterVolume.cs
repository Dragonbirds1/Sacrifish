using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioCooool;
    [SerializeField] private Slider musicSlider;

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        AudioCooool.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
}