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
        tapCount = 2;
        EventBus.OnTapPopper += OnTapPopper;
        UpdateTapCounterText();
    }

    void OnDisable()
    {
        EventBus.OnTapPopper -= OnTapPopper;
    }

    void OnTapPopper()
    {
        Debug.Log("HUDTapCounter - OnTapPopper received");
        tapCount = Mathf.Max(0, tapCount - 1);
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
