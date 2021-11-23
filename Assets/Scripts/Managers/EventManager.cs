using Key;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    #region Singleton

    public static EventManager Instance;

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

    #region Core Behaviour

    public UnityAction<GameSaveData> onSaveGameData = delegate { };
    public UnityAction onNextLevel = delegate { };
    public UnityAction onRestartLevel = delegate { };

    #endregion

    #region Game Behaviour

    public UnityAction onPlay = delegate { };
    public UnityAction onLevelSuccess = delegate { };
    public UnityAction onLevelFailed = delegate { };
    public UnityAction onSetCinemachineTarget = delegate { };

    #endregion

    #region UI Behaviour

    public UnityAction onActivateBoobyTrapActivatorButton = delegate { };

    #endregion

    #region Gameplay Behaviour

    public UnityAction onActivateEnemyMovement = delegate { };
    public UnityAction<int> onActivateBoobyTrap = delegate { };
    public UnityAction onDeactivateEnemyMovement = delegate { };
    public UnityAction onIncreaseKilledEnemyCount = delegate { };
    public UnityAction<int> onSetKilledEnemyCountToUI = delegate { };

    #endregion

    #endregion
}