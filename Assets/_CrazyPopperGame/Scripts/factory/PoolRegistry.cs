using UnityEngine;
using CrazyPopper.Poppers;
using CrazyPopper.Projectiles;
public class PoolRegistry : MonoBehaviour
{
    public static PoolRegistry Instance { get; private set; }

    public Transform gridSpawnerTransform;

    [Header("Prefabs")]
    public PopperEntity popperPrefab;
    public EyeView leftEyePrefab;
    public EyeView rightEyePrefab;
    public Projectile projectilePrefab;

    public PuffParticle puffPrefab;

    public ObjectPool<PopperEntity> PopperPool;
    public ObjectPool<EyeView> LeftEyePool;
    public ObjectPool<EyeView> RightEyePool;
    public ObjectPool<Projectile> ProjectilePool;
    public ObjectPool<PuffParticle> PuffPool;

    private void Awake()
    {
        Instance = this;

        PopperPool = new ObjectPool<PopperEntity>(popperPrefab, 10, transform);
        LeftEyePool = new ObjectPool<EyeView>(leftEyePrefab, 20, transform);
        RightEyePool = new ObjectPool<EyeView>(rightEyePrefab, 20, transform);
        ProjectilePool = new ObjectPool<Projectile>(projectilePrefab, 20, transform);
        PuffPool = new ObjectPool<PuffParticle>(puffPrefab, 5, transform);
    }
}
