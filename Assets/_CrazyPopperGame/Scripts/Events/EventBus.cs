
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
        public static void RaiseClickPlay() => OnClickPlay?.Invoke();
        public static void RegisterPopper() => OnRegisterPopper?.Invoke();
        public static void UnregisterPopper() => OnUnRegisterPopper?.Invoke();
        public static void RaisePopperStateChanged(PopperState state, PopperEntity sender) => OnPopperStateChanged?.Invoke(state, sender);
        public static void RaiseConsumedMove(int remainingMoves) => OnConsumedMove?.Invoke(remainingMoves);
        public static void RaiseAllReactionsResolved() => OnAllReactionsResolved?.Invoke();
        public static void RaiseRegisterReactionTracker(bool isRegistering) => OnRegisterReactionTracker?.Invoke(isRegistering);
    }
}