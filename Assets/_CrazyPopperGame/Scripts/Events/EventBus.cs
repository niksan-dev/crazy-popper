
using System;
using UnityEngine;
using CrazyPopper.Poppers;
namespace CrazyPopper.Events
{
    public static class EventBus
    {
        public static event Action OnClickPlay;
        public static event Action OnRegisterPopper;
        public static event Action<PopperState, PopperEntity> OnPopperStateChanged;
        public static void RaiseClickPlay() => OnClickPlay?.Invoke();
        public static void RegisterPopper() => OnRegisterPopper?.Invoke();
        public static void RaisePopperStateChanged(PopperState state, PopperEntity sender) => OnPopperStateChanged?.Invoke(state, sender);
    }
}