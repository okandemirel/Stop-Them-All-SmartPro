using System.Collections.Generic;
using Data;
using Key;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    #region Singleton

    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    #endregion

    #region Unity Actions

    public UnityAction<int> onInitializeLevel = delegate { };
    public UnityAction onClearActiveLevel = delegate { };

    #endregion

    #region Self Variables

    #region Public Variables

    [Header("Data")] public List<LevelData> Data;

    public int LevelID;

    #endregion

    #region Serialized Variables

    [SerializeField] private int totalLevelCount;

    #endregion

    #endregion

    private void Start()
    {
        EventManager.Instance.onNextLevel += OnNextLevel;
        EventManager.Instance.onRestartLevel += OnRestartLevel;

        GetLevelData();
        totalLevelCount = Data.Count;

        LevelID = GetLevelValue();
        onInitializeLevel?.Invoke(LevelID);
    }

    private void OnDisable()
    {
        EventManager.Instance.onNextLevel -= OnNextLevel;
        EventManager.Instance.onRestartLevel -= OnRestartLevel;
    }

    private void GetLevelData()
    {
        Data = Resources.Load<LevelScriptable>("Data/Level Data")
            .LevelData;
    }

    private int GetLevelValue()
    {
        if (ES3.FileExists())
        {
            if (ES3.KeyExists("Level"))
            {
                return ES3.Load<int>("Level") % totalLevelCount;
            }
        }

        return 0;
    }


    private void OnNextLevel()
    {
        LevelID++;
        onClearActiveLevel?.Invoke();
        onInitializeLevel?.Invoke(LevelID);
        EventManager.Instance.onSaveGameData.Invoke(new GameSaveData()
        {
            LevelData = LevelID
        });
    }

    private void OnRestartLevel()
    {
        onClearActiveLevel?.Invoke();
        onInitializeLevel?.Invoke(LevelID);
        EventManager.Instance.onSaveGameData.Invoke(new GameSaveData()
        {
            LevelData = LevelID
        });
    }
}