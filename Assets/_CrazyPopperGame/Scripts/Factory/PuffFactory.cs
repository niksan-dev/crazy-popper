using UnityEngine;

public static class PuffFactory
{

    public static void Spawn(Vector3 pos)
    {
        var puff = PoolRegistry.Instance.PuffPool
            .Spawn(pos, Quaternion.identity);
        //puff.GetComponent<PuffParticle>().Play(pos);
    }
}
