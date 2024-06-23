using UnityEngine;

public class AudioArreglo : MonoBehaviour
{
    public AudioClip[] audioClips;

    // Método para obtener un audio clip específico
    public AudioClip GetAudioClip(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            return audioClips[index];
        }
        return null;
    }
}