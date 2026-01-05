using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component, IPoolable
{
    private readonly Stack<T> pool = new();
    private readonly T prefab;
    private readonly Transform root;

    public ObjectPool(T prefab, int preload, Transform parent)
    {
        this.prefab = prefab;
        root = parent;

        for (int i = 0; i < preload; i++)
            pool.Push(Create());
    }

    private T Create()
    {
        var obj = Object.Instantiate(prefab, root);
        obj.gameObject.SetActive(false);
        return obj;
    }

    public T Spawn(Vector3 pos, Quaternion rot)
    {
        var obj = pool.Count > 0 ? pool.Pop() : Create();
        obj.transform.SetPositionAndRotation(pos, rot);
        obj.gameObject.SetActive(true);
        obj.OnSpawn();
        return obj;
    }

    public void Despawn(T obj)
    {
        obj.OnDespawn();
        obj.gameObject.SetActive(false);
        pool.Push(obj);
    }
}
