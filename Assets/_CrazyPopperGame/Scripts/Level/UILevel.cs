using System.Collections;
using System.Collections.Generic;
using CrazyPopper.UI;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UILevel : MonoBehaviour
{
    [SerializeField] private Text txtLevelNumber;
    private Button btnLevel;

    void Awake()
    {
        btnLevel = GetComponent<Button>();
        btnLevel.onClick.AddListener(OnLevelButtonClicked);
    }

    private void OnLevelButtonClicked()
    {
        // Handle level button click
        Debug.Log("Level " + txtLevelNumber.text + " button clicked.");
        UIViewManager.Instance.Show<ScreenInGame>();
    }

    public void SetLevelNumber(int levelNumber)
    {
        txtLevelNumber.text = "Level " + levelNumber.ToString();

    }
}
