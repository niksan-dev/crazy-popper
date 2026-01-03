using UnityEngine;
using CrazyPopper.Poppers;

[CreateAssetMenu(menuName = "CrazyPopper/Level")]
public class LevelConfig : ScriptableObject
{
    public int maxTaps;
    public Vector2Int size;
    public PopperState[] layout;
}
