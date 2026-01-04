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

        SetEyePositions(left, right);
    }

    static void SetEyePositions(EyeView left, EyeView right)
    {
        left.transform.localPosition = new Vector3(-0.2f, 0.25f, 0);
        right.transform.localPosition = new Vector3(0.2f, 0.25f, 0);
    }

    public static void DetachEyes(EyeView left, EyeView right)
    {
        PoolRegistry.Instance.LeftEyePool.Despawn(left);
        PoolRegistry.Instance.RightEyePool.Despawn(right);
    }
}
