using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CrazyPopper.UI
{
    public class PopupExitGame : PopupView
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
            UIViewManager.Instance.Hide<PopupExitGame>();
            Debug.Log("Popup Closed");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        void OnNoClick()
        {
            UIViewManager.Instance.Hide<PopupExitGame>();
        }

        protected override void OnShow()
        {
            Debug.Log("Popup Opened");
        }

        protected override void OnHide()
        {

        }
    }
}

