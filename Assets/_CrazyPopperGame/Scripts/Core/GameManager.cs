using UnityEngine;
using CrazyPopper.Events;
using CrazyPopper.UI;
using CrazyPopper.Core;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public LevelsSO levelsSO;
    public AudioManager audioManager;
    [SerializeField] private GridSpawner gridSpawner;
    private int alivePoppers;
    internal int currentLevelIndex = 1;

    internal ScoreData scoreData = new ScoreData();


    Coroutine gameInitCoroutine;

    private void Awake()
    {
        Instance = this;
    }

    //public void RegisterPopper() => alivePoppers++;
    public void UnregisterPopper() => alivePoppers--;


    public void OnMoveConsumed(int remainingMoves)
    {
        if (remainingMoves == 0)
        {
            TryEndGame();
        }
    }

    public void InitializeGame()
    {
        Debug.Log("Initializing Level: " + currentLevelIndex);
        ResetAllCounters();
        LevelConfig level = levelsSO.levels[currentLevelIndex - 1];
        TurnManager.Instance.RemainingMoves = level.maxTaps;
        alivePoppers = level.popperLayout.FindAll(state => state != CrazyPopper.Poppers.PopperState.None).Count;
        if (gameInitCoroutine != null)
        {
            StopCoroutine(gameInitCoroutine);
        }
        gameInitCoroutine = StartCoroutine(DelayStartGame());
    }

    IEnumerator DelayStartGame()
    {
        yield return new WaitForSeconds(0.1f);
        LevelConfig level = levelsSO.levels[currentLevelIndex - 1];
        gridSpawner.Spawn(level);
        EventBus.RaiseGameInitialized(level);
    }

    void ResetAllCounters()
    {
        alivePoppers = 0;
    }

    void OnEnable()
    {
        EventBus.OnAllReactionsResolved += OnAllReactionsResolved;
        // EventBus.OnRegisterPopper += RegisterPopper;
        EventBus.OnConsumedMove += OnMoveConsumed;
        EventBus.OnUnRegisterPopper += UnregisterPopper;
        EventBus.OnClickLevel += (levelIndex) =>
        {
            scoreData.currentScore = 0;
            currentLevelIndex = levelIndex;
            InitializeGame();
        };
    }

    void OnDisable()
    {
        EventBus.OnAllReactionsResolved -= OnAllReactionsResolved;
        EventBus.OnConsumedMove -= OnMoveConsumed;
        // EventBus.OnRegisterPopper -= RegisterPopper;
        EventBus.OnUnRegisterPopper -= UnregisterPopper;
        EventBus.OnClickLevel -= (levelIndex) =>
       {

       };
    }

    public void OnAllReactionsResolved()
    {
        TryEndGame();
    }

    private void TryEndGame()
    {
        Debug.Log("ReactionTracker.Instance.activeReactions  : " + ReactionTracker.Instance.activeReactions);
        //check for no projectile is alive
        if (ReactionTracker.Instance.activeReactions > 0)
            return;
        Debug.Log("alivePoppers: " + alivePoppers);
        if (TurnManager.Instance.RemainingMoves > 0 && alivePoppers > 0)
            return;

        if (alivePoppers <= 0)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    private void Win()
    {
        Debug.Log("LEVEL COMPLETE");
        // UI, audio, next level
        scoreData.tapBonusScore = TurnManager.Instance.RemainingMoves * GameConstants.SCORE_PER_REMAINING_TAP;
        scoreData.totalScore = scoreData.currentScore + scoreData.tapBonusScore;
        ProgressManager.Instance.TrySetLevelBest(currentLevelIndex, scoreData.totalScore);
        UIViewManager.Instance.Show<PopupLevelWin>();

    }

    private void Lose()
    {
        Debug.Log("LEVEL FAILED");
        // UI, retry
        UIViewManager.Instance.Show<PopupLevelLose>();
        EventBus.RaiseLevelFailed();
    }
}


public class ScoreData
{
    public int currentScore;
    public int tapBonusScore;
    public int totalScore;
}
