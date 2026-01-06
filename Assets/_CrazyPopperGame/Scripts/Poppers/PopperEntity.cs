
using CrazyPopper.Events;
using UnityEngine;

namespace CrazyPopper.Poppers
{
    public class PopperEntity : MonoBehaviour, IPoolable
    {
        public PopperState State => state;

        [SerializeField] private PopperState state;
        private PopperExplosion explosion;

        internal bool IsPopped = false;

        private void Awake()
        {
            explosion = GetComponent<PopperExplosion>();
        }

        public void Initialize(PopperState start)
        {
            state = start;
            IsPopped = false;
            //Debug.Log($"Popper reacted to state: {state}");
            EventBus.RaisePopperStateChanged(state, this);
            EventBus.RegisterPopper();
        }

        public void ReactToInput()
        {
            if (state == PopperState.Purple)
            {
                Explode();
                return;
            }

            state--;

            Debug.Log($"Popper reacted to state: {state}");
            EventBus.RaisePopperStateChanged(state, this);

        }

        private void Explode()
        {
            //spawn projectiles, effects, sounds, etc//TODO:
            IsPopped = true;
            PopperFactory.Destroy(this);
            explosion.Explode();
            GameManager.Instance.audioManager.PlaySound(AudioType.Pop);
        }


        public void OnSpawn()
        {

        }

        public void OnDespawn()
        {

        }
    }
}
