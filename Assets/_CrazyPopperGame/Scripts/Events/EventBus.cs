
using System;
using UnityEngine;
using CrazyPopper.Poppers;
namespace CrazyPopper.Events
{
    public static class EventBus
    {
        public static event Action OnClickPlay;
        public static event Action OnRegisterPopper;

        public static event Action OnUnRegisterPopper;

        public static event Action<PopperState, PopperEntity> OnPopperStateChanged;
        public static event Action<int> OnConsumedMove;
        public static event Action OnAllReactionsResolved;
        public static event Action<bool> OnRegisterReactionTracker;

        public static event Action<LevelConfig> OnGameInitialized;
        public static event Action<int> OnClickLevel;

        public static event Action OnLevelRetry;
        public static event Action OnLevelExit;
        public static event Action OnLevelFailed;
        public static event Action<bool> OnGameStateChanged;
        public static event Action<int> OnUpdateScore;

        public static void RaiseClickLevel(int levelIndex) => OnClickLevel?.Invoke(levelIndex);
        public static void RaiseClickPlay() => OnClickPlay?.Invoke();
        public static void RegisterPopper() => OnRegisterPopper?.Invoke();
        public static void UnregisterPopper() => OnUnRegisterPopper?.Invoke();
        public static void RaiseUpdateScore(int newScore) => OnUpdateScore?.Invoke(newScore);
        public static void RaisePopperStateChanged(PopperState state, PopperEntity sender) => OnPopperStateChanged?.Invoke(state, sender);
        public static void RaiseConsumedMove(int remainingMoves) => OnConsumedMove?.Invoke(remainingMoves);
        public static void RaiseAllReactionsResolved() => OnAllReactionsResolved?.Invoke();
        public static void RaiseRegisterReactionTracker(bool isRegistering) => OnRegisterReactionTracker?.Invoke(isRegistering);
        public static void RaiseGameInitialized(LevelConfig level) => OnGameInitialized?.Invoke(level);
        public static void RaiseLevelRetry() => OnLevelRetry?.Invoke();
        public static void RaiseLevelExit() => OnLevelExit?.Invoke();
        public static void RaiseLevelFailed() => OnLevelFailed?.Invoke();
        public static void RaiseGameStateChanged(bool isPaused) => OnGameStateChanged?.Invoke(isPaused);
    }
}