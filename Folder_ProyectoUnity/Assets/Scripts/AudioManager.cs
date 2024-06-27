using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip fondoMusic;

    private void Start()
    {
        musicSource.clip = fondoMusic;
        musicSource.Play();
    }
}
