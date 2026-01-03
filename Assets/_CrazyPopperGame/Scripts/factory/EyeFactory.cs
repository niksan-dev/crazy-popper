using UnityEngine;

using CrazyPopper.Poppers;
public static class EyeFactory
{
    public static void AttachEyes(Transform parent)
    {
        var left = PoolRegistry.Instance.LeftEyePool
            .Spawn(parent.position, Quaternion.identity);
        var right = PoolRegistry.Instance.RightEyePool
            .Spawn(parent.position, Quaternion.identity);

        left.transform.SetParent(parent, false);
        right.transform.SetParent(parent, false);
    }

    public static void DetachEyes(EyeView left, EyeView right)
    {
        PoolRegistry.Instance.LeftEyePool.Despawn(left);
        PoolRegistry.Instance.RightEyePool.Despawn(right);
    }
}
