using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrazyPopper.UI
{
    public class ScreenInGame : ScreenView
    {
        protected override void OnShow()
        {
            Debug.Log("In Game Screen Opened");
        }

        protected override void OnHide()
        {
            Debug.Log("In Game Screen Closed");
        }
    }
}
