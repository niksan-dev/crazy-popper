using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Configs")]
    [SerializeField] private List<AudioConfig> audioConfigs;

    [Header("Pooling")]
    [SerializeField] private PooledAudioSource audioSourcePrefab;
    [SerializeField] private int preloadSources = 10;

    private Dictionary<AudioType, AudioConfig> configMap;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        BuildMap();

        AudioPool.Initialize(audioSourcePrefab, preloadSources, transform);

        PlaySound(AudioType.Background);
    }

    private void BuildMap()
    {
        configMap = new Dictionary<AudioType, AudioConfig>();

        foreach (var config in audioConfigs)
        {
            configMap[config.type] = config;
        }
    }

    public void PlaySound(AudioType type)
    {
        if (!configMap.TryGetValue(type, out var config))
        {
            Debug.LogWarning($"AudioConfig not found for {type}");
            return;
        }

        var src = AudioPool.Spawn(transform.position);
        src.Play(config);
    }
}

public enum AudioType
{
    Background,
    Pop,
    Win,
    Fail
}
