using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrazyPopper.UI
{
    public class PopupExit : PopupView
    {
        protected override void OnShow()
        {
            Debug.Log("Popup Opened");
        }

        protected override void OnHide()
        {
            Debug.Log("Popup Closed");
        }
    }
}

