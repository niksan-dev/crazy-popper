using System.Collections;
using System.Collections.Generic;
using CrazyPopper.Poppers;
using UnityEngine;
using UnityEngine.UI;

namespace CrazyPopper.UI
{
    public class PopupLevelWin : PopupView
    {
        [SerializeField] private Button btnNextLevel;


        void Start()
        {
            btnNextLevel.onClick.AddListener(OnNextLevelClicked);
        }

        void OnNextLevelClicked()
        {
            UIViewManager.Instance.Hide<PopupLevelWin>();
            GameManager.Instance.currentLevelIndex++;
            GameManager.Instance.currentLevelIndex = Mathf.Min(GameManager.Instance.currentLevelIndex, GameManager.Instance.levelsSO.levels.Length - 1);
            GameManager.Instance.InitializeGame();
        }
        protected override void OnShow()
        {
            Debug.Log("Level Win Popup Opened");
            GameManager.Instance.audioManager.PlaySound(AudioType.Win);
        }

        protected override void OnHide()
        {
            Debug.Log("Level Win Popup Closed");
        }
    }
}
