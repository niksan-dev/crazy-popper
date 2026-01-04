
using CrazyPopper.Events;
using UnityEngine;

namespace CrazyPopper.Poppers
{
    public class PopperEntity : MonoBehaviour, IPoolable
    {
        public PopperState State => state;

        [SerializeField] private PopperState state;

        private PopperStateMachine stateMachine;
        private PopperExplosion explosion;

        private void Awake()
        {
            stateMachine = GetComponent<PopperStateMachine>();
            explosion = GetComponent<PopperExplosion>();

            //Initialize(PopperState.Yellow);
        }

        public void Initialize(PopperState start)
        {
            state = start;
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
            PopperFactory.Destroy(this);
            explosion.Explode();
        }


        public void OnSpawn()
        {

        }

        public void OnDespawn()
        {

        }
    }
}
