using UnityEngine;
using UnityEditor;
using System.IO;

public class ProjectStructure
{

    private static string gameName = "_CrazyPopperGame";
    private static readonly string root = "Assets/" + gameName;

    private static readonly string[] folders = new string[]
    {
        "Art",
            "Art/Sprites",
            "Art/Backgrounds",
            "Art/VFX",

            "Audio",
            "Audio/Music",
            "Audio/SFX",

            "Prefabs",
            "Prefabs/Poppers",
            "Prefabs/Projectiles",
            "Prefabs/UI",

            "ScriptableObjects",
            "ScriptableObjects/Levels",
            "ScriptableObjects/Configs",

            "Scripts",
            "Scripts/Core",
            "Scripts/Poppers",
            "Scripts/Input",
            "Scripts/Projectiles",
            "Scripts/Grid",
            "Scripts/Audio",
            "Scripts/UI",

            "Scenes",
            "Editor"
    };

    [MenuItem("Tools/Create Project Folders")]
    public static void CreateProjectFolders()
    {
        if (!AssetDatabase.IsValidFolder(root))
            AssetDatabase.CreateFolder("Assets", gameName);

        foreach (string folder in folders)
        {
            string path = $"{root}/{folder}";
            CreateFolder(path);
        }

        AssetDatabase.Refresh();
        Debug.Log("<color=green>Project folder structure created successfully!</color>");
    }

    private static void CreateFolder(string fullPath)
    {
        string parent = Path.GetDirectoryName(fullPath).Replace("\\", "/");
        string folderName = Path.GetFileName(fullPath);

        if (!AssetDatabase.IsValidFolder(fullPath))
        {
            AssetDatabase.CreateFolder(parent, folderName);
        }
    }
}
