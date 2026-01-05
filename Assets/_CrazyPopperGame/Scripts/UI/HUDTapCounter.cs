using System.Collections;
using System.Collections.Generic;
using CrazyPopper.Events;
using UnityEngine;
using UnityEngine.UI;

public class HUDTapCounter : MonoBehaviour
{

    [SerializeField] private Text tapCountText;
    private int tapCount = 0;
    // Start is called before the first frame update


    void OnEnable()
    {
        //  tapCount = 2;
        EventBus.OnConsumedMove += OnConsumedMove;
        UpdateTapCounterText();
    }

    void OnDisable()
    {
        EventBus.OnConsumedMove -= OnConsumedMove;
    }

    void OnConsumedMove(int remainingMoves)
    {
        Debug.Log($"HUDTapCounter - OnConsumedMove received {remainingMoves}");
        tapCount = Mathf.Max(0, remainingMoves);
        UpdateTapCounterText();

        if (tapCount == 0)
        {
            //level failed logic can go here
        }
    }

    void UpdateTapCounterText()
    {
        tapCountText.text = $"Taps Left: {tapCount}";
    }
}
