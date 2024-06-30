using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SingleTry : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSFX;
    [SerializeField] private AudioSetting audioSettings;

    public static SingleTry instance;

    public static SingleTry Instance
    {
        get 
        { 
            return instance; 
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            LoadVolumeSettings();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadVolumeSettings();
    }

    public void LoadVolumeSettings()
    {
        sliderMaster.value = audioSettings.masterVolume;
        sliderMusic.value = audioSettings.musicVolume;
        sliderSFX.value = audioSettings.sfxVolume;
        SetVolumeMaster();
        SetVolumeMusic();
        SetVolumeSFX();
    }

    public void SetVolumeMaster()
    {
        float volume = sliderMaster.value;
        myMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        audioSettings.masterVolume = volume;
    }

    public void SetVolumeMusic()
    {
        float volume = sliderMusic.value;
        myMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        audioSettings.musicVolume = volume;
    }

    public void SetVolumeSFX()
    {
        float volume = sliderSFX.value;
        myMixer.SetFloat("SFXvolume", Mathf.Log10(volume) * 20);
        audioSettings.sfxVolume = volume;
    }
}