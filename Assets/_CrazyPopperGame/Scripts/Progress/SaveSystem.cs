using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string FilePath =>
        Path.Combine(Application.persistentDataPath, "scores.json");

    public static SaveData Load()
    {
        Debug.Log($"Loading level score  {FilePath}");
        if (!File.Exists(FilePath))
        {
            Debug.Log("Save file not found. Creating new.");
            return new SaveData();
        }

        string json = File.ReadAllText(FilePath);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(FilePath, json);
        Debug.Log($"Game saved at {FilePath}");
    }
}
