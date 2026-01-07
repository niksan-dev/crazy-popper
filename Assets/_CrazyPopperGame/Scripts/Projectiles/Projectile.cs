using UnityEngine;
using CrazyPopper.Poppers;
using CrazyPopper.Events;
using CrazyPopper.Core;

namespace CrazyPopper.Projectiles
{
    public class Projectile : MonoBehaviour, IPoolable, IDeSpawnable
    {
        private Vector2 dir;
        private float speed = 8f;

        public void Init(Vector2 direction)
        {
            dir = direction.normalized;
            EventBus.RaiseRegisterReactionTracker(true);
        }

        private void Update()
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out PopperEntity p) && p.IsPopped == false)
            {
                p.ReactToInput();
                PoolRegistry.Instance.ProjectilePool.Despawn(this);
                EventBus.RaiseRegisterReactionTracker(false);
            }

            //check for walls or out of bounds
            if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Bounds")
            {
                PoolRegistry.Instance.ProjectilePool.Despawn(this);
                EventBus.RaiseRegisterReactionTracker(false);
            }
        }


        public void OnSpawn()
        {
            this.transform.parent = GridSpawner.Instance.transform;
        }

        public void OnDespawn()
        {
            this.transform.parent = PoolRegistry.Instance.transform;
        }

        public void Despawn()
        {
            ProjectileFactory.DeSpawn(this);
        }
    }
}
