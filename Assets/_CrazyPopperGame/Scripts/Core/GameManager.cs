using UnityEngine;
using CrazyPopper.Events;
using CrazyPopper.UI;
using CrazyPopper.Core;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public LevelsSO levelsSO;
    public AudioManager audioManager;
    [SerializeField] private GridSpawner gridSpawner;
    private int alivePoppers;
    internal int currentLevelIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterPopper() => alivePoppers++;
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
        ResetAllCounters();
        LevelConfig level = levelsSO.levels[currentLevelIndex];
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
        EventBus.OnRegisterPopper += RegisterPopper;
        EventBus.OnConsumedMove += OnMoveConsumed;
        EventBus.OnUnRegisterPopper += UnregisterPopper;
    }

    void OnDisable()
    {
        EventBus.OnAllReactionsResolved -= OnAllReactionsResolved;
        EventBus.OnConsumedMove -= OnMoveConsumed;
        EventBus.OnRegisterPopper -= RegisterPopper;
        EventBus.OnUnRegisterPopper -= UnregisterPopper;
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
        UIViewManager.Instance.Show<PopupLevelWin>();
    }

    private void Lose()
    {
        Debug.Log("LEVEL FAILED");
        // UI, retry
        UIViewManager.Instance.Show<PopupLevelLose>();
    }
}
