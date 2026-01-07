

using UnityEngine;

public static class AudioPool
{
    private static ObjectPool<PooledAudioSource> pool;

    public static void Initialize(
        PooledAudioSource prefab,
        int preload,
        Transform root
    )
    {
        pool = new ObjectPool<PooledAudioSource>(prefab, preload, root);
    }

    public static PooledAudioSource Spawn(Vector3 position)
    {
        return pool.Spawn(position, Quaternion.identity);
    }

    public static void Release(PooledAudioSource src)
    {
        pool.Despawn(src);
    }
}

