using UnityEngine;
using CrazyPopper.Poppers;
public class PoolRegistry : MonoBehaviour
{
    public static PoolRegistry Instance { get; private set; }

    [Header("Prefabs")]
    public PopperEntity popperPrefab;
    public EyeView leftEyePrefab;
    public EyeView rightEyePrefab;

    public ObjectPool<PopperEntity> PopperPool;
    public ObjectPool<EyeView> LeftEyePool;
    public ObjectPool<EyeView> RightEyePool;

    private void Awake()
    {
        Instance = this;

        PopperPool = new ObjectPool<PopperEntity>(popperPrefab, 30, transform);
        LeftEyePool = new ObjectPool<EyeView>(leftEyePrefab, 60, transform);
        RightEyePool = new ObjectPool<EyeView>(rightEyePrefab, 60, transform);
    }
}
