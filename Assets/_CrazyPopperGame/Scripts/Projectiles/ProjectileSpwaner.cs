using UnityEngine;
using CrazyPopper.Projectiles;
public static class ProjectileSpawner
{
    public static GameObject projectilePrefab;

    public static void Spawn(Vector3 position)
    {
        SpawnOne(position, Vector2.up);
        SpawnOne(position, Vector2.down);
        SpawnOne(position, Vector2.left);
        SpawnOne(position, Vector2.right);
    }

    private static void SpawnOne(Vector3 pos, Vector2 dir)
    {
        var p = PoolRegistry.Instance.ProjectilePool
            .Spawn(pos, Quaternion.identity);
        p.GetComponent<Projectile>().Init(dir);
    }
}
