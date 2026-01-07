using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    private SaveData saveData;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        saveData = SaveSystem.Load();
    }
    // -------- Level Best --------

    public int GetLevelBest(int level)
    {
        return saveData.levelBestScores.TryGetValue(level, out int best)
            ? best
            : 0;
    }

    public bool TrySetLevelBest(int level, int score)
    {
        int currentBest = GetLevelBest(level);

        if (score > currentBest)
        {
            saveData.levelBestScores[level] = score;
            SaveSystem.Save(saveData);
            return true;
        }
        return false;
    }
}
