using UnityEngine;
using CrazyPopper.Poppers;

public static class PopperFactory
{
    public static PopperEntity Create(
        Vector3 position,
        PopperState state
    )
    {
        var popper = PoolRegistry.Instance.PopperPool
            .Spawn(position, Quaternion.identity);

        popper.Initialize(state);
        EyeFactory.AttachEyes(popper.transform);

        return popper;
    }

    public static void Destroy(PopperEntity popper)
    {
        PoolRegistry.Instance.PopperPool.Despawn(popper);
    }
}
