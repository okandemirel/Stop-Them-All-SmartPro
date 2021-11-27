using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    #region Singleton

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    #endregion

    #region Unity Actions

    public UnityAction onActivateLevelFailedPanel = delegate { };
    public UnityAction onActivateLevelSuccessPanel = delegate { };
    public UnityAction onDeactivateLevelFailedPanel = delegate { };
    public UnityAction onDeactivateLevelSuccessPanel = delegate { };

    public UnityAction onActivateTopBar = delegate { };
    public UnityAction onDeactivateTopBar = delegate { };
    public UnityAction<int> onSetLevelEnemyCountToBar = delegate { };
    public UnityAction<int> onSetLevelValueToText = delegate { };
    public UnityAction onActivateBoobyTrapPanel = delegate { };
    public UnityAction onDeactivateBoobyTrapPanel = delegate { };
    public UnityAction onActivateStartPanel = delegate { };
    public UnityAction onDeactivateStartPanel = delegate { };

    public UnityAction<int> onSetKilledEnemyCountToUI = delegate { };
    public UnityAction onResetFillBar = delegate { };

    #endregion

    #region Self Variables

    #region Serialized Variables

    #endregion

    #endregion

    private void Start()
    {
        EventManager.Instance.onLevelFailed += LevelFailed;
        EventManager.Instance.onLevelSuccess += LevelSuccess;


        EventManager.Instance.onPlay += OnPlay;
        EventManager.Instance.onActivateBoobyTrapActivatorButton += OnActivateBoobyTrapActivatorButton;

        EventManager.Instance.onSetKilledEnemyCountToUI += OnSetKilledEnemyCountToUI;
    }

    private void OnDisable()
    {
        EventManager.Instance.onLevelFailed -= LevelFailed;
        EventManager.Instance.onLevelSuccess -= LevelSuccess;

        EventManager.Instance.onPlay -= OnPlay;
        EventManager.Instance.onActivateBoobyTrapActivatorButton -= OnActivateBoobyTrapActivatorButton;

        EventManager.Instance.onSetKilledEnemyCountToUI -= OnSetKilledEnemyCountToUI;
    }

    public void Play()
    {
        EventManager.Instance.onPlay?.Invoke();
    }

    private void OnPlay()
    {
        onActivateTopBar?.Invoke();
        onSetLevelValueToText?.Invoke(LevelManager.Instance.LevelID + 1);
        onSetLevelEnemyCountToBar?.Invoke(Resources.Load<LevelScriptable>("Data/Level Data")
            .LevelData[LevelManager.Instance.LevelID].EnemyCount);
    }

    private void OnActivateBoobyTrapActivatorButton()
    {
        onActivateBoobyTrapPanel?.Invoke();
    }

    private void OnActivateStartPanel()
    {
        onActivateStartPanel?.Invoke();
    }

    public void OnDeactivateBoobyTrapPanel()
    {
        onDeactivateBoobyTrapPanel?.Invoke();
    }

    public void OnDeactivateStartPanel()
    {
        onDeactivateStartPanel?.Invoke();
    }

    private void OnSetKilledEnemyCountToUI(int killedEnemyCount)
    {
        onSetKilledEnemyCountToUI?.Invoke(killedEnemyCount);
    }

    private void LevelFailed()
    {
        onDeactivateTopBar?.Invoke();
        onDeactivateStartPanel?.Invoke();
        onDeactivateBoobyTrapPanel?.Invoke();
        onActivateLevelFailedPanel?.Invoke();
        onResetFillBar?.Invoke();
    }

    private void LevelSuccess()
    {
        onDeactivateTopBar?.Invoke();
        onDeactivateStartPanel?.Invoke();
        onDeactivateBoobyTrapPanel?.Invoke();
        onActivateLevelSuccessPanel?.Invoke();
        onResetFillBar?.Invoke();
    }

    public void OnNextLevel()
    {
        onDeactivateLevelFailedPanel?.Invoke();
        onDeactivateLevelSuccessPanel?.Invoke();
        onActivateStartPanel?.Invoke();
        EventManager.Instance.onNextLevel?.Invoke();
    }

    public void OnRestartLevel()
    {
        onDeactivateLevelFailedPanel?.Invoke();
        onDeactivateLevelSuccessPanel?.Invoke();
        onActivateStartPanel?.Invoke();
        EventManager.Instance.onRestartLevel?.Invoke();
    }
}