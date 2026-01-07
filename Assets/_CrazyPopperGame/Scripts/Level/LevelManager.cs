using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform levelsContainer;
    [SerializeField] LevelsSO levelsSO;
    [SerializeField] UILevel uiLevelPrefab;
    void Awake()
    {
        DrawLevels();
    }

    void DrawLevels()
    {
        int i = 1;
        foreach (var item in levelsSO.levels)
        {
            Debug.Log("Level: " + item.maxTaps);
            UILevel uiLevel = Instantiate(uiLevelPrefab, levelsContainer);
            uiLevel.SetLevelNumber(i, item);
            i++;
        }
    }
}
