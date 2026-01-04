using UnityEngine;
using CrazyPopper.Poppers;
using CrazyPopper.Projectiles;
public class PoolRegistry : MonoBehaviour
{
    public static PoolRegistry Instance { get; private set; }

    [Header("Prefabs")]
    public PopperEntity popperPrefab;
    public EyeView leftEyePrefab;
    public EyeView rightEyePrefab;
    public Projectile projectilePrefab;

    public ObjectPool<PopperEntity> PopperPool;
    public ObjectPool<EyeView> LeftEyePool;
    public ObjectPool<EyeView> RightEyePool;
    public ObjectPool<Projectile> ProjectilePool;

    private void Awake()
    {
        Instance = this;

        PopperPool = new ObjectPool<PopperEntity>(popperPrefab, 20, transform);
        LeftEyePool = new ObjectPool<EyeView>(leftEyePrefab, 40, transform);
        RightEyePool = new ObjectPool<EyeView>(rightEyePrefab, 40, transform);
        ProjectilePool = new ObjectPool<Projectile>(projectilePrefab, 20, transform);
    }
}
