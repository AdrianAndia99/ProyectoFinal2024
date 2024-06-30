using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider MusicSlider;
    public float sliderValue;

    private void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("volume",0.7f);
        AudioListener.volume = MusicSlider.value; 
    }

    public void ChangeValue(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("volume",sliderValue);
        AudioListener.volume = MusicSlider.value;
    }
}