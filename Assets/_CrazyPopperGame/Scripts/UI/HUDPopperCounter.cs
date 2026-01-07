using System.Collections;
using System.Collections.Generic;
using CrazyPopper.Events;
using CrazyPopper.Poppers;
using UnityEngine;
using UnityEngine.UI;

public class HUDPopperCounter : MonoBehaviour
{

    [SerializeField] private Text popperCountText;
    private int popperCount = 0;
    void OnEnable()
    {
        EventBus.OnRegisterPopper += OnRegisterPopper;
        EventBus.OnUnRegisterPopper += OnUnRegisterPopper;
        EventBus.OnLevelRetry += OnLevelRetry;
        EventBus.OnGameInitialized += (level) =>
        {

            int popperCount = level.popperLayout.FindAll(state => state != PopperState.None).Count;
            Debug.Log("HUDPopperCounter - OnGameInitialized received popperCount: " + popperCount);
            this.popperCount = popperCount;
            UpdatePopperCounterText();
        };
        UpdatePopperCounterText();
    }

    void OnLevelRetry()
    {
        popperCount = 0;
        UpdatePopperCounterText();
    }

    void OnRegisterPopper()
    {
        popperCount++;
        UpdatePopperCounterText();
    }

    void OnUnRegisterPopper()
    {
        popperCount--;
        Debug.Log("popperCount : " + popperCount);
        popperCount = Mathf.Max(0, popperCount);
        UpdatePopperCounterText();
    }

    void UpdatePopperCounterText()
    {
        popperCountText.text = $"Poppers Alive: {popperCount}";
    }

    void OnDisable()
    {
        EventBus.OnRegisterPopper -= OnRegisterPopper;
        EventBus.OnUnRegisterPopper -= OnUnRegisterPopper;
        EventBus.OnLevelRetry -= OnLevelRetry;
        EventBus.OnGameInitialized -= (level) =>
       {

       };
    }
}
