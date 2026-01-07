using UnityEngine;

[CreateAssetMenu(menuName = "Audio/Audio Config")]
public class AudioConfig : ScriptableObject
{
    public AudioType type;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1f;

    public bool loop;
}
