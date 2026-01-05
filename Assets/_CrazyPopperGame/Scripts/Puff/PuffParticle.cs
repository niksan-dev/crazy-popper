using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class PuffParticle : MonoBehaviour, IPoolable
{
    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void Play(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);

        ps.Clear(true);
        ps.Play(true);
    }

    private void Update()
    {
        if (!ps.IsAlive(true))
        {
            PoolRegistry.Instance.PuffPool.Despawn(this);
        }
    }

    public void OnSpawn()
    {
        ps.Clear(true);
        ps.Play(true);
    }

    public void OnDespawn()
    {
        ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
