using System.Collections;
using System.Collections.Generic;
using CrazyPopper.Events;
using CrazyPopper.Poppers;
using UnityEngine;
using UnityEngine.UI;

namespace CrazyPopper.UI
{
    public class PopupLevelLose : PopupView, IBackKeyHandler
    {
        [SerializeField] private Button btnRetry;
        [SerializeField] private Button btnExit;

        void Start()
        {
            btnRetry.onClick.AddListener(OnClickRetry);
            btnExit.onClick.AddListener(OnClickExit);
        }

        void OnClickRetry()
        {
            EventBus.RaiseLevelRetry();
            UIViewManager.Instance.Hide<PopupLevelLose>();
            //UIViewManager.Instance.Show<ScreenInGame>();
        }

        void OnClickExit()
        {
            EventBus.RaiseLevelExit();
            UIViewManager.Instance.Hide<PopupLevelLose>();
            UIViewManager.Instance.Show<ScreenMainMenu>();
        }
        protected override void OnShow()
        {
            UIViewManager.Instance.Hide<PopupQuitGame>();
            Debug.Log("Level Lose Popup Opened");
            GameManager.Instance.audioManager.PlaySound(AudioType.Fail);
        }

        protected override void OnHide()
        {
            Debug.Log("Level Lose Popup Closed");
        }

        public bool OnBackPressed()
        {
            OnClickExit();
            return true;
        }
    }
}
