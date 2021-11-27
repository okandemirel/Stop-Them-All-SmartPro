using Data;
using ScriptableObjects;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        [Header("Data")] public PlayerData Data;

        #endregion

        #region Serialized Variables

        [SerializeField] private Rigidbody rigidbody;

        #endregion

        #region Private Variables

        private bool _isReadyToMove;

        #endregion

        #endregion

        private void Awake()
        {
            if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            EventManager.Instance.onLevelSuccess += Reset;
            EventManager.Instance.onLevelFailed += Reset;
            EventManager.Instance.onNextLevel += Reset;
            EventManager.Instance.onRestartLevel += Reset;
            EventManager.Instance.onPlay += OnLevelStart;

            Data = GetPlayerData();

            Reset();
        }

        private void OnDisable()
        {
            EventManager.Instance.onLevelSuccess -= Reset;
            EventManager.Instance.onLevelFailed -= Reset;
            EventManager.Instance.onNextLevel -= Reset;
            EventManager.Instance.onRestartLevel -= Reset;
            EventManager.Instance.onPlay -= OnLevelStart;
        }

        private PlayerData GetPlayerData()
        {
            return Resources.Load<PlayerScriptable>("Data/Player Data").Data;
        }

        private void OnLevelStart()
        {
            StartMovement();
        }

        private void StartMovement()
        {
            _isReadyToMove = true;
        }

        private void StopMovement()
        {
            _isReadyToMove = false;
        }

        private void FixedUpdate()
        {
            rigidbody.velocity = _isReadyToMove ? new Vector3(0, 0, Data.ForwardMovementSpeed) : Vector3.zero;
        }

        private void Reset()
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            _isReadyToMove = false;
        }
    }
}