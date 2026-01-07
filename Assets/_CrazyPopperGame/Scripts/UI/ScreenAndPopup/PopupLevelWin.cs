using System.Collections;
using System.Collections.Generic;
using CrazyPopper.Events;
using CrazyPopper.Poppers;
using UnityEngine;
using UnityEngine.UI;

namespace CrazyPopper.UI
{
    public class PopupLevelWin : PopupView, IBackKeyHandler
    {
        [SerializeField] private Button btnNextLevel;
        [SerializeField] private Button btnMainMenu;
        [SerializeField] private Text txtTapBonusScore;
        [SerializeField] private Text txtCurrentScore;
        [SerializeField] private Text txtTotalScore;
        [SerializeField] private Text txtBestScore;


        void Start()
        {
            btnNextLevel.onClick.AddListener(OnNextLevelClicked);
            btnMainMenu.onClick.AddListener(OnClickMainMenu);
        }

        void OnEnable()
        {
            SetScoreTexts();
        }

        void SetScoreTexts()
        {
            int currentScore = GameManager.Instance.scoreData.currentScore;
            int tapBonusScore = GameManager.Instance.scoreData.tapBonusScore;
            int totalScore = GameManager.Instance.scoreData.totalScore;
            int bestScore = ProgressManager.Instance.GetLevelBest(GameManager.Instance.currentLevelIndex);
            txtCurrentScore.text = $"Score: {currentScore}";
            txtTapBonusScore.text = $"Bonus: {tapBonusScore}";
            txtTotalScore.text = $"Total: {totalScore}";
            txtBestScore.text = $"Best: {bestScore}";
        }

        void OnNextLevelClicked()
        {
            UIViewManager.Instance.Hide<PopupLevelWin>();
            GameManager.Instance.currentLevelIndex++;
            GameManager.Instance.currentLevelIndex = Mathf.Min(GameManager.Instance.currentLevelIndex, GameManager.Instance.levelsSO.levels.Length);
            Debug.Log("Next Level: " + GameManager.Instance.currentLevelIndex);

            GameManager.Instance.InitializeGame();
        }
        protected override void OnShow()
        {
            UIViewManager.Instance.Hide<PopupQuitGame>();
            Debug.Log("Level Win Popup Opened");
            GameManager.Instance.audioManager.PlaySound(AudioType.Win);
        }

        protected override void OnHide()
        {
            Debug.Log("Level Win Popup Closed");
        }

        void OnClickMainMenu()
        {
            EventBus.RaiseLevelExit();
            UIViewManager.Instance.Hide<PopupLevelWin>();
            UIViewManager.Instance.Show<ScreenMainMenu>();
        }

        public bool OnBackPressed()
        {
            //throw new System.NotImplementedException();
            OnClickMainMenu();
            return true;
        }
    }
}
