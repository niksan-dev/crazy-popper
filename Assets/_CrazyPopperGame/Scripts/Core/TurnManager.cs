using UnityEngine;
using CrazyPopper.Events;
public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    public int RemainingMoves { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        EventBus.OnGameInitialized += (level) =>
         {
             Debug.Log($"TurnManager - OnGameInitialized received  {level.maxTaps}");
             RemainingMoves = level.maxTaps;
             EventBus.RaiseConsumedMove(RemainingMoves);
         };
    }

    void OnDisable()
    {
        EventBus.OnGameInitialized -= (level) =>
        {
            RemainingMoves = 0;
        };
    }



    public void Init(int moves)
    {
        RemainingMoves = moves;
    }

    public bool ConsumeMove()
    {
        if (RemainingMoves <= 0)
            return false;

        RemainingMoves--;
        EventBus.RaiseConsumedMove(RemainingMoves);
        return true;
    }
}
