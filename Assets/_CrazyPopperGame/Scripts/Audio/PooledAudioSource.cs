using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PooledAudioSource : MonoBehaviour, IPoolable
{
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(AudioConfig config)
    {
        source.clip = config.clip;
        source.volume = config.volume;
        source.loop = config.loop;
        source.Play();
    }

    public void OnSpawn() { }

    public void OnDespawn()
    {
        source.Stop();
        source.clip = null;
    }

    private void Update()
    {
        if (!source.loop && !source.isPlaying)
        {
            AudioPool.Release(this);
        }
    }
}
