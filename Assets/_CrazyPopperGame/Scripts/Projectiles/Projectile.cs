using UnityEngine;
using CrazyPopper.Poppers;

namespace CrazyPopper.Projectiles
{
    public class Projectile : MonoBehaviour, IPoolable
    {
        private Vector2 dir;
        private float speed = 8f;

        public void Init(Vector2 direction) => dir = direction.normalized;

        private void Update()
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out PopperEntity p))
            {
                p.ReactToInput();
                PoolRegistry.Instance.ProjectilePool.Despawn(this);
            }

            //check for walls or out of bounds
            if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Bounds")
            {
                PoolRegistry.Instance.ProjectilePool.Despawn(this);
            }
        }


        public void OnSpawn()
        {

        }

        public void OnDespawn()
        {

        }
    }
}
