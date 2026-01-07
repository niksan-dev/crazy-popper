using System.Collections;
using System.Collections.Generic;
using CrazyPopper.Events;
using UnityEngine;

namespace CrazyPopper.UI
{
    public class ScreenInGame : ScreenView, IBackKeyHandler
    {
        protected override void OnShow()
        {

            EventBus.RaiseConsumedMove(TurnManager.Instance.RemainingMoves);
            Debug.Log("In Game Screen Opened");
            // Initialize game elements here

        }

        protected override void OnHide()
        {
            Debug.Log("In Game Screen Closed");
        }

        public bool OnBackPressed()
        {
            UIViewManager.Instance.Show<PopupQuitGame>();
            return true;
        }
    }
}
