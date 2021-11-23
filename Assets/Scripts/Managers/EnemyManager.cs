using Data;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class EnemyManager : MonoBehaviour
    {

        #region Unity Actions

        public UnityAction onActivateEnemyMovementAnimation = delegate { };
        public UnityAction<float> onActivateEnemyMovementRigidbody = delegate { };
        public UnityAction onDeactivateEnemyMovementAnimation = delegate { };
        public UnityAction onDeactivateEnemyMovementRigidbody = delegate { };

        public UnityAction onKillEnemy = delegate { };

        #endregion

        #region Self Variables

        #region Public Variables

        [Header("Data")] public EnemyData Data;

        #endregion

        #endregion


        private void Start()
        {
            EventManager.Instance.onLevelFailed += LevelFailed;

            EventManager.Instance.onActivateEnemyMovement += ActivateEnemyMovement;
            EventManager.Instance.onDeactivateEnemyMovement += DeactivateEnemyMovement;

            AssignEnemyData();
        }

        private void OnDisable()
        {
            EventManager.Instance.onLevelFailed -= LevelFailed;


            EventManager.Instance.onActivateEnemyMovement -= ActivateEnemyMovement;
            EventManager.Instance.onDeactivateEnemyMovement -= DeactivateEnemyMovement;
        }

        private void AssignEnemyData()
        {
            Data = Resources.Load<EnemyScriptable>("Data/EnemyData").EnemyData;
        }

        private void LevelFailed()
        {
            DeactivateEnemyMovement();
        }

        private void ActivateEnemyMovement()
        {
            onActivateEnemyMovementAnimation?.Invoke();
            onActivateEnemyMovementRigidbody?.Invoke(Data.ForwardMovementSpeed);
        }

        private void DeactivateEnemyMovement()
        {
            onDeactivateEnemyMovementAnimation?.Invoke();
            onDeactivateEnemyMovementRigidbody?.Invoke();
        }
    }
}