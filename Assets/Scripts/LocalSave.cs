using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int highScore;
}

public static class LocalSave
{
    private static string localPath => Application.persistentDataPath + "savedata.json";

    public static void SaveLocal(int score)
    {
        int currentLocal = LoadLocal();
        if (score > currentLocal)
        {
            GameData data = new GameData { highScore = score };
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(localPath, json);
        }
    }

    public static int LoadLocal()
    {
        if (!File.Exists(localPath)) return 0;
        string json = File.ReadAllText(localPath);
        GameData data = JsonUtility.FromJson<GameData>(json);
        return data.highScore;
    }
}
