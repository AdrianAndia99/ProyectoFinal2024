using UnityEngine;

[CreateAssetMenu(fileName = "AudioSettings", menuName = "ScriptableObjects/Audio Settings")]
public class AudioSetting : ScriptableObject
{
    public float masterVolume = 0.7f;
    public float musicVolume = 0.7f;
    public float sfxVolume = 0.7f;
}