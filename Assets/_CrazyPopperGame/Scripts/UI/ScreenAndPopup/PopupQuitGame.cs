using System.Collections;
using System.Collections.Generic;
using CrazyPopper.Events;
using UnityEngine;
using UnityEngine.UI;

namespace CrazyPopper.UI
{
    public class PopupQuitGame : PopupView
    {

        [SerializeField] private Button btnYes;
        [SerializeField] private Button btnNo;

        void Start()
        {
            btnYes.onClick.AddListener(OnYesClick);
            btnNo.onClick.AddListener(OnNoClick);
        }

        void OnYesClick()
        {
            UIViewManager.Instance.Hide<PopupQuitGame>();
            UIViewManager.Instance.Hide<ScreenInGame>();
            //UIViewManager.Instance.Show<ScreenMainMenu>();
            EventBus.RaiseLevelExit();
        }

        void OnNoClick()
        {
            UIViewManager.Instance.Hide<PopupQuitGame>();

        }
        protected override void OnShow()
        {
            Debug.Log("Popup Opened");
            EventBus.RaiseGameStateChanged(true);
        }

        protected override void OnHide()
        {
            Debug.Log("Popup Closed");
            EventBus.RaiseGameStateChanged(false);
        }
    }
}