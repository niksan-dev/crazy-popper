using CrazyPopper.Events;
using UnityEngine;

namespace CrazyPopper.Poppers
{
    public class PopperInputHandler : MonoBehaviour
    {
        private PopperEntity entity;
        private bool isLevelFailed = false;
        private bool isGamePaused = false;

        private void Awake()
        {
            entity = GetComponent<PopperEntity>();
        }

        void OnEnable()
        {
            EventBus.OnLevelFailed += OnLevelFailed;
            EventBus.OnGameInitialized += OnGameInitialized;
            EventBus.OnGameStateChanged += (isPaused) =>
            {
                isGamePaused = isPaused;
            };
        }

        void OnDisable()
        {
            EventBus.OnLevelFailed -= OnLevelFailed;
            EventBus.OnGameInitialized -= OnGameInitialized;
            EventBus.OnGameStateChanged -= (isPaused) =>
           {
               isGamePaused = false;
           };
        }

        void OnGameInitialized(LevelConfig level)
        {
            isLevelFailed = false;
            isGamePaused = false;
        }

        void OnLevelFailed()
        {
            isLevelFailed = true;
        }

        private void OnMouseDown()
        {
            if (isGamePaused || isLevelFailed)
                return;

            if (ReactionTracker.Instance.activeReactions > 0)
                return;
            entity.ReactToInput();
            TurnManager.Instance.ConsumeMove();
        }
    }
}
