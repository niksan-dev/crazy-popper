
using UnityEngine;
namespace CrazyPopper.Poppers
{
    public class EyeView : MonoBehaviour, IPoolable
    {
        public void OnSpawn()
        {

        }

        public void OnDespawn()
        {
            // transform.SetParent(null);
        }
    }
}
