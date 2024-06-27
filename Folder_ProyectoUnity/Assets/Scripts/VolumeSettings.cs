using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider Slider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("music"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = Slider.value;
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("music",volume);
    }

    private void LoadVolume()
    {
        Slider.value = PlayerPrefs.GetFloat("music");
        SetMusicVolume();
    }
}