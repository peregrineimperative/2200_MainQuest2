using UnityEngine;
using System.IO;
using System;

public class SaveSystem
{
    private static readonly string FilePath =
        Application.persistentDataPath + "/GameSaveData.json";

    public static void Save(GameData data)
    {
        //metadata
        //data.Version = Application.version; //exists in project settings
        //data.LastSavedTime = DateTime.UtcNow.ToString("o");
        
        string json = JsonUtility.ToJson(data, true); //serialize
        
        File.WriteAllText(FilePath, json); //write file
        
        Debug.Log($"[SaveManager] Saved game data to {FilePath}");
    }
    
    public static bool TryLoad(out GameData data)
    {
        try
        {
            if (!File.Exists(FilePath))
            {
                data = new GameData();
                return false;
            }

            string json = File.ReadAllText(FilePath); //read file

            Debug.Log($"[SaveManager] Loaded game data from {FilePath}");

            data = JsonUtility.FromJson<GameData>(json); //deserialize
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"[SaveManager] Failed to load save file: {e.Message}");
            data = new GameData();
            return false;
        }
    }
}

public class GameData
{
    
}

