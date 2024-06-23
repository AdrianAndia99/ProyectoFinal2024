using UnityEngine;

public class AudioArreglo : MonoBehaviour
{
    public AudioClip[] audioClips;

    // M�todo para obtener un audio clip espec�fico
    public AudioClip GetAudioClip(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            return audioClips[index];
        }
        return null;
    }
}