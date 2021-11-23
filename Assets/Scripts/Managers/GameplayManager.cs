using Data;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;

namespace Managers
{
    public class GameplayManager : MonoBehaviour
    {
        #region Singleton

        public static GameplayManager Instance;

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

        #region Self Variables

        #region Public Variables

        [Header("Data")] public LevelData Data;

        public int StageID;

        #endregion

        #region Serialized Variables

        [SerializeField] private int killedEnemyCount;

        #endregion

        #endregion

        private void Start()
        {
            EventManager.Instance.onPlay += OnPlay;

            EventManager.Instance.onIncreaseKilledEnemyCount += OnIncreaseKilledEnemyCount;

            GetLevelData();
        }

        private void OnDisable()
        {
            EventManager.Instance.onPlay -= OnPlay;

            EventManager.Instance.onIncreaseKilledEnemyCount -= OnIncreaseKilledEnemyCount;
        }

        private void GetLevelData()
        {
            Data = Resources.Load<LevelScriptable>("Data/Level Data")
                .LevelData[LevelManager.Instance.LevelID];
        }

        private void OnPlay()
        {
            EventManager.Instance.onActivateEnemyMovement?.Invoke();
            EventManager.Instance.onSetCinemachineTarget?.Invoke(); //Çalışmıyor
            EventManager.Instance.onActivateBoobyTrapActivatorButton?.Invoke();
            //Başka şeyler de eklenebilir
        }

        private void OnIncreaseKilledEnemyCount()
        {
            killedEnemyCount++;
            EventManager.Instance.onSetKilledEnemyCountToUI?.Invoke(killedEnemyCount);
            if (killedEnemyCount >= Data.EnemyCount)
            {
                DOVirtual.DelayedCall(1, () => EventManager.Instance.onLevelSuccess?.Invoke());
            }
        }
    }
}