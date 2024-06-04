using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RadioController : MonoBehaviour
{
    [Header("Lista canciones")]
    [SerializeField] private Tracks[] audioTracks;
    private int trackIndex;

    [SerializeField] private TextMeshProUGUI trackTextUI;

    private AudioSource radioSource;
    void Start()
    {
        radioSource = GetComponent<AudioSource>();

        trackIndex = 0;
        radioSource.clip = audioTracks[trackIndex].trackAudioClip;
        trackTextUI.text = audioTracks[trackIndex].name;
    }

    public void SkipFowardButton()
    {
        if(trackIndex < audioTracks.Length - 1)
        {
            trackIndex++;
            StartCoroutine(FadeOut(radioSource,0.5f));
        }
    }

    public void SkipBackwardButton()
    {
        if(trackIndex >= 1)
        {
            trackIndex--;
            StartCoroutine(FadeOut(radioSource, 0.5f));
        }

    }
    void UpdateTrack(int index)
    {
        radioSource.clip = audioTracks[index].trackAudioClip;
        trackTextUI.text = audioTracks[index].name; 
    }
    public void AudioVolume(float volume)
    {
        radioSource.volume = volume;
    }

    public void PlayAudio()
    {
        StartCoroutine(FadeIn(radioSource, 0.5f));
    }

    public void PauseAudio()
    {
        radioSource.Pause();
    }

    public void StopAudio()
    {
        StartCoroutine(FadeOut(radioSource, 0.5f));
    }

    public IEnumerator FadeOut(AudioSource audioSource ,  float fadeTime)
    {
        float startVolume = audioSource.volume;
        while(audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
        UpdateTrack(trackIndex);
    }

    public IEnumerator FadeIn(AudioSource audioSource , float fadeTime)
    {
        float startVolume = audioSource.volume;

        audioSource.volume = 0;
        audioSource.Play();

        while(audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        audioSource.volume = startVolume;
    }
}