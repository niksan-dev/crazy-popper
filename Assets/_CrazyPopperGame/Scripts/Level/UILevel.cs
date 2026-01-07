
using CrazyPopper.UI;
using UnityEngine;
using UnityEngine.UI;
using CrazyPopper.Events;
[RequireComponent(typeof(Button))]
public class UILevel : MonoBehaviour
{
    [SerializeField] private Image imgBackground, textBackground;
    [SerializeField] private Text txtLevelNumber, txtNumTaps;
    private Button btnLevel;
    int levelNumber;

    void Awake()
    {
        btnLevel = GetComponent<Button>();
        btnLevel.onClick.AddListener(OnLevelButtonClicked);
    }

    private void OnLevelButtonClicked()
    {
        // Handle level button click
        Debug.Log("Level " + txtLevelNumber.text + " button clicked.");
        EventBus.RaiseClickLevel(levelNumber);
        UIViewManager.Instance.Show<ScreenInGame>();
    }

    void SetColors(LevelConfig levelConfig)
    {
        if (levelConfig != null)
        {
            imgBackground.color = levelConfig.bgColor;
            textBackground.color = levelConfig.textColor;
            txtNumTaps.color = levelConfig.textColor;
            txtNumTaps.text = "Taps Available: " + levelConfig.maxTaps.ToString();
        }
    }

    public void SetLevelNumber(int _levelNumber, LevelConfig levelConfig)
    {
        levelNumber = _levelNumber;
        txtLevelNumber.text = "Level " + levelNumber.ToString();
        SetColors(levelConfig);

    }
}
