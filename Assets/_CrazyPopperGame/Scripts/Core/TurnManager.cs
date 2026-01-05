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
        RemainingMoves = Random.Range(3, 6);
        EventBus.RaiseConsumedMove(RemainingMoves);
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
