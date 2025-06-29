using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using UnityEngine;

public class CloudSaveSystem
{
    private static bool isInitialized = false;

    public static async Task InitializeServicesAsync()
    {
        if (isInitialized) return;
        try
        {
            await UnityServices.InitializeAsync();
            if (!AuthenticationService.Instance.IsSignedIn)
                await AuthenticationService.Instance.SignInAnonymouslyAsync();

            isInitialized = true;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error inicializando Cloud Save: " + ex.Message);
        }
    }

    public static async Task SaveScoreAsync(int score)
    {
        string levelKey = AudioManager.Instance.CurrentSong.SongName;

        LocalSave.SaveLocal(levelKey, score);
        await InitializeServicesAsync();

        int currentHighScore = await LoadHighScoreAsync();
        if (score > currentHighScore)
        {
            var data = new Dictionary<string, object>
            {
                { levelKey, score }
            };

            try
            {
                await CloudSaveService.Instance.Data.Player.SaveAsync(data);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error guardando datos en la nube: " + ex.Message);
            }
        }
    }

    public static async Task<int> LoadHighScoreAsync()
    {
        await InitializeServicesAsync();

        var levelKey = AudioManager.Instance.CurrentSong.SongName;

        try
        {
            var keys = new HashSet<string> { levelKey };
            var data = await CloudSaveService.Instance.Data.Player.LoadAsync(keys);

            if (data.TryGetValue(levelKey, out var value))
            {
                int score = value.Value.GetAs<int>();
                return score;
            }
        }
        catch (System.Exception)
        {
            return LocalSave.LoadLocal(levelKey);
        }

        return 0;
    }
}
