using Key;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;


        Application.targetFrameRate = 60;
    }

    #endregion


    private void Start()
    {
        EventManager.Instance.onSaveGameData += OnSaveGameData;
    }

    private void OnDisable()
    {
        EventManager.Instance.onSaveGameData -= OnSaveGameData;
    }

    private void OnSaveGameData(GameSaveData saveData)
    {
        ES3.Save("Level", saveData.LevelData);
        ES3.Save("Coin", saveData.CoinData);
        ES3.Save("Haptic", saveData.HapticData);
        ES3.Save("SFX", saveData.SFX);
    }
}