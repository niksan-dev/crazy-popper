using UnityEngine;
using CrazyPopper.Core;

namespace CrazyPopper.Poppers
{
    public class PopperExplosion : MonoBehaviour
    {
        public void Explode()
        {
            ProjectileFactory.Spawn(transform.position);
            PuffFactory.Spawn(transform.position);
            //AudioManager.Instance.PlayPop();
            Destroy(gameObject);
        }
    }
}
