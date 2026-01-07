
using CrazyPopper.Core;
using CrazyPopper.Events;
using DG.Tweening;
using UnityEngine;

namespace CrazyPopper.Poppers
{
    public class PopperEntity : MonoBehaviour, IPoolable, IDeSpawnable
    {
        public PopperState State => state;

        [SerializeField] private PopperState state;
        private PopperExplosion explosion;

        internal bool IsPopped = false;

        Vector3 finalPosition, randomPosition;

        internal Transform leftEye, rightEye;

        float[] randPositions = new float[] { -7f, -8f, 8f, 7f, 9, -9f };

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
            PopperFactory.DeSpawn(this);
            explosion.Explode();
            GameManager.Instance.audioManager.PlaySound(AudioType.Pop);

            ReactionTracker.Instance.IncrementChain();
            CalculateScore();
        }

        void CalculateScore()
        {
            int chainBonus = ReactionTracker.Instance.CurrentChain * GameConstants.ComboMultiplier;
            ScoreManager.Instance.Add(GameConstants.BaseScore + chainBonus);
        }


        public void OnSpawn()
        {

            this.transform.parent = GridSpawner.Instance.transform;
            finalPosition = this.transform.position;
            randomPosition = new Vector3(randPositions[Random.Range(0, randPositions.Length)], randPositions[Random.Range(0, randPositions.Length)], 0);
            this.transform.position = randomPosition;
            this.transform.DOMove(finalPosition, 0.5f).SetEase(Ease.Linear);
        }

        public void OnDespawn()
        {
            this.transform.parent = PoolRegistry.Instance.transform;
        }

        public void Despawn()
        {
            PopperFactory.DeSpawn(this);
        }
    }
}
