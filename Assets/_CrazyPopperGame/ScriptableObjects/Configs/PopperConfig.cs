using UnityEngine;
using CrazyPopper.Poppers;

[CreateAssetMenu(menuName = "CrazyPopper/PopperConfig")]
public class PopperConfig : ScriptableObject
{
    public PopperState startState;

    public Sprite yellowSprite;
    public Sprite blueSprite;
    public Sprite purpleSprite;

    public GameObject leftEyePrefab;
    public GameObject rightEyePrefab;

    public Sprite GetSprite(PopperState state)
    {
        return state switch
        {
            PopperState.Yellow => yellowSprite,
            PopperState.Blue => blueSprite,
            PopperState.Purple => purpleSprite,
            _ => null
        };
    }
}