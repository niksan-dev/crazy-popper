using UnityEngine;
using CrazyPopper.Core;
using CrazyPopper.Events;

namespace CrazyPopper.Poppers
{
    public class PopperExplosion : MonoBehaviour
    {
        public void Explode()
        {
            ProjectileFactory.Spawn(transform.position);
            PuffFactory.Spawn(transform.position);
            EventBus.UnregisterPopper();
            //AudioManager.Instance.PlayPop();
            //Destroy(gameObject);
        }
    }
}
