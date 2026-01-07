
using UnityEngine;
using CrazyPopper.Events;
public class ReactionTracker : MonoBehaviour
{
    public static ReactionTracker Instance;

    internal int activeReactions;
    public int CurrentChain { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        EventBus.OnRegisterReactionTracker += OnRegisterReactionTracker;
        EventBus.OnGameInitialized += (level) =>
        {
            activeReactions = 0;
            CurrentChain = 0;
        };
    }

    void OnDisable()
    {
        EventBus.OnRegisterReactionTracker -= OnRegisterReactionTracker;
    }

    public void OnRegisterReactionTracker(bool isRegistering)
    {
        if (activeReactions == 0)
            CurrentChain = 0;
        if (isRegistering)
            activeReactions++;
        else
            Unregister();
    }

    public void Unregister()
    {
        activeReactions--;
        if (activeReactions <= 0)
            CurrentChain = 0;
        TryResolveGameEnd();
    }

    public void IncrementChain()
    {
        CurrentChain++;
    }

    private void TryResolveGameEnd()
    {
        if (activeReactions <= 0)
        {
            Debug.Log("=========All reactions resolved, raising event==");
            EventBus.RaiseAllReactionsResolved();
        }
    }
}
