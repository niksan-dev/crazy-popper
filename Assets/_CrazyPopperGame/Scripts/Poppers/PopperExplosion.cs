using UnityEngine;
using CrazyPopper.Core;

namespace CrazyPopper.Poppers
{
    public class PopperExplosion : MonoBehaviour
    {
        public void Explode()
        {
            ProjectileSpawner.Spawn(transform.position);
            //PuffSpawner.Spawn(transform.position);
            //AudioManager.Instance.PlayPop();
            Destroy(gameObject);
        }
    }
}
