using UnityEngine;
using CrazyPopper.Poppers;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "CrazyPopper/Level")]
public class LevelConfig : ScriptableObject
{
    public int maxTaps;
    public Vector2Int size;
    public Color bgColor;
    public Color textColor;
    // public PopperState[] layout;
    public List<PopperState> popperLayout;
}


public enum LevelType
{
    Easy,
    Medium,
    Hard,
    Expert
}
