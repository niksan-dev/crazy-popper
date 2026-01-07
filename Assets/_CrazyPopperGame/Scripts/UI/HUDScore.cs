
using System.Collections;
using System.Collections.Generic;
using CrazyPopper.Events;
using UnityEngine;
using UnityEngine.UI;

public class HUDScore : MonoBehaviour
{

    [SerializeField] private Text scoreCountText;
    private int score = 0;
    // Start is called before the first frame update


    void OnEnable()
    {
        EventBus.OnUpdateScore += (newScore) =>
        {
            GameManager.Instance.scoreData.currentScore = newScore;
            score = newScore;
            UpdateScoreCounterText();
            Debug.Log($"HUDScore - OnUpdateScore received {score}");
        };
        EventBus.OnGameInitialized += (level) =>
        {
            score = 0;
            UpdateScoreCounterText();
            Debug.Log($"HUDScore - OnGameInitialized Unsubscribe {score}");
        };
    }

    void OnDisable()
    {
        EventBus.OnGameInitialized -= (level) =>
        {
            Debug.Log("HUDScore - OnGameInitialized Unsubscribe");
        };

        EventBus.OnUpdateScore -= (newScore) =>
        {
            Debug.Log("HUDScore - OnUpdateScore Unsubscribe");
        };
    }


    void UpdateScoreCounterText()
    {
        scoreCountText.text = $"Score: {score}";
    }
}

