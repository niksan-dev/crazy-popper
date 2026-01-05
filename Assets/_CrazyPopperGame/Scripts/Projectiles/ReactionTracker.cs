
using UnityEngine;
using CrazyPopper.Events;
public class ReactionTracker : MonoBehaviour
{
    public static ReactionTracker Instance;

    internal int activeReactions;

    private void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        EventBus.OnRegisterReactionTracker += OnRegisterReactionTracker;
    }

    void OnDisable()
    {
        EventBus.OnRegisterReactionTracker -= OnRegisterReactionTracker;
    }

    public void OnRegisterReactionTracker(bool isRegistering)
    {
        if (isRegistering)
            activeReactions++;
        else
            Unregister();
    }

    public void Unregister()
    {
        activeReactions--;
        TryResolveGameEnd();
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
