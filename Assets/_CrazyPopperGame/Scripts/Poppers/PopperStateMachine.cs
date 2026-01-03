using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyPopper.Events;
namespace CrazyPopper.Poppers
{
    public class PopperStateMachine : MonoBehaviour
    {
        public bool TryAdvance(ref PopperState state)
        {
            if (state == PopperState.Purple)
                return true;

            state--;
            EventBus.RaisePopperStateChanged(state);
            return false;
        }
    }
}