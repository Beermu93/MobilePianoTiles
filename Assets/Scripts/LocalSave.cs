using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public Dictionary<string, int> levelHighScores = new();
}

public static class LocalSave
{
    private static string localPath => Application.persistentDataPath + "savedata.json";

    private static GameData cachedData;

    private static GameData LoadData()
    {
        if (cachedData != null)
            return cachedData;

        if (File.Exists(localPath))
        {
            string json = File.ReadAllText(localPath);
            cachedData = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            cachedData = new GameData();
        }

        return cachedData;
    }

    public static void SaveLocal(string levelId, int score)
    {
        GameData data = LoadData();

        if (!data.levelHighScores.ContainsKey(levelId) || score > data.levelHighScores[levelId])
        {
            data.levelHighScores[levelId] = score;
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(localPath, json);
        }
    }

    public static int LoadLocal(string levelId)
    {
        GameData data = LoadData();
        return data.levelHighScores.TryGetValue(levelId, out var score) ? score : 0;
    }

    public static Dictionary<string, int> GetAllLocalScores()
    {
        return LoadData().levelHighScores;
    }
}
