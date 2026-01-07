using UnityEngine;
using CrazyPopper.Events;
using System;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int Score { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        EventBus.OnGameInitialized += (level) =>
        {
            ResetScore();
        };
    }
    void OnDisable()
    {
        EventBus.OnGameInitialized -= (level) =>
        {
            ResetScore();
        };
    }

    public void ResetScore()
    {
        Score = 0;
        Notify();
    }

    public void Add(int amount)
    {
        Score += amount;
        Notify();
    }

    private void Notify()
    {
        // UI update event later if needed
        Debug.Log($"Score: {Score}");

        EventBus.RaiseUpdateScore(Score);
    }
}


[Serializable]
public class LevelScoreData
{
    public int currentScore = 0;
    public int bestScore = 0;
}
