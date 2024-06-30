using UnityEngine;

public class AudioArreglo : MonoBehaviour
{
    public AudioSource[] audioSources;

    public AudioSource GetAudioSource(int index)
    {
        if (index >= 0 && index < audioSources.Length)
        {
            return audioSources[index];
        }
        return null;
    }
}