using System.Collections;
using System.Collections.Generic;
using CrazyPopper.Poppers;
using UnityEngine;

namespace CrazyPopper.UI
{
    public class PopupLevelLose : PopupView
    {
        protected override void OnShow()
        {
            Debug.Log("Level Lose Popup Opened");
            GameManager.Instance.audioManager.PlaySound(AudioType.Fail);
        }

        protected override void OnHide()
        {
            Debug.Log("Level Lose Popup Closed");
        }
    }
}
