using Cinemachine;
using GameAnalyticsSDK;
using GameAnalyticsSDK.Setup;
using Key;
using Managers;
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
        LevelManager.Instance.onInitializeLevel += OnLevelStarted;
        EventManager.Instance.onLevelFailed += OnLevelFailed;
        EventManager.Instance.onLevelSuccess += OnLevelSuccess;
    }

    private void OnDisable()
    {
        EventManager.Instance.onSaveGameData -= OnSaveGameData;
        LevelManager.Instance.onInitializeLevel -= OnLevelStarted;
        EventManager.Instance.onLevelFailed -= OnLevelFailed;
        EventManager.Instance.onLevelSuccess -= OnLevelSuccess;
    }

    private void OnSaveGameData(GameSaveData saveData)
    {
        ES3.Save("Level", saveData.LevelData);
        ES3.Save("Coin", saveData.CoinData);
        ES3.Save("Haptic", saveData.HapticData);
        ES3.Save("SFX", saveData.SFX);
    }

    private void OnLevelStarted(int levelID)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, levelID.ToString());
    }

    private void OnLevelSuccess()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, LevelManager.Instance.LevelID.ToString());
    }

    private void OnLevelFailed()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, LevelManager.Instance.LevelID.ToString());
    }
}