using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrazyPopper.UI
{
    public class ScreenMainMenu : ScreenView
    {
        protected override void OnShow()
        {
            Debug.Log("Home Screen Opened");
        }

        protected override void OnHide()
        {
            Debug.Log("Home Screen Closed");
        }
    }
}
