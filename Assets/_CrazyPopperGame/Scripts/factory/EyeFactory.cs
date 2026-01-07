using UnityEngine;

using CrazyPopper.Poppers;
public static class EyeFactory
{
    public static void AttachEyes(Transform parent, PopperState state)
    {
        var left = PoolRegistry.Instance.LeftEyePool
            .Spawn(parent.position, Quaternion.identity);
        var right = PoolRegistry.Instance.RightEyePool
            .Spawn(parent.position, Quaternion.identity);

        left.transform.SetParent(parent, false);
        right.transform.SetParent(parent, false);

        SetEyePositions(left, right, state);
    }

    static void SetEyePositions(EyeView left, EyeView right, PopperState state)
    {
        switch (state)
        {

            case PopperState.Blue:
                Debug.Log("Setting eye positions for Blue popper");
                left.transform.localPosition = new Vector3(-0.3f, 0.25f, 0);
                right.transform.localPosition = new Vector3(0.3f, 0.25f, 0);
                break;
            case PopperState.Yellow:
                Debug.Log("Setting eye positions for Yellow popper");
                left.transform.localPosition = new Vector3(-0.22f, 0.25f, 0);
                right.transform.localPosition = new Vector3(0.22f, 0.25f, 0);
                break;
            case PopperState.Purple:
                Debug.Log("Setting eye positions for Purple popper");
                left.transform.localPosition = new Vector3(-0.25f, 0.3f, 0);
                right.transform.localPosition = new Vector3(0.25f, 0.1f, 0);
                break;
            default:
                break;
        }
    }


    public static void DetachEyes(Transform parent)
    {

        var left = parent.transform.GetChild(0).GetComponent<EyeView>();
        var right = parent.transform.GetChild(1).GetComponent<EyeView>();


        PoolRegistry.Instance.LeftEyePool.Despawn(left);
        PoolRegistry.Instance.RightEyePool.Despawn(right);
    }
}
