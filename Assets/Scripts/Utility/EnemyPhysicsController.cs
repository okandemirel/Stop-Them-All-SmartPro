using Managers;
using UnityEngine;

namespace Utility
{
    public class EnemyPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Collider collider;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float speedForward;
        [SerializeField] private EnemyManager enemyManager;

        #endregion

        #region Private Variables

        private bool _isReadyToMove;

        #endregion

        #endregion

        private void Start()
        {
            enemyManager = GetComponent<EnemyManager>();

            enemyManager.onActivateEnemyMovementRigidbody += OnActivateEnemyMovementRigidbody;
            enemyManager.onDeactivateEnemyMovementRigidbody += OnDeactivateEnemyMovementRigidbody;

            enemyManager.onKillEnemy += OnKillEnemy;
        }

        private void OnDisable()
        {
            enemyManager.onActivateEnemyMovementRigidbody -= OnActivateEnemyMovementRigidbody;
            enemyManager.onDeactivateEnemyMovementRigidbody -= OnDeactivateEnemyMovementRigidbody;

            enemyManager.onKillEnemy -= OnKillEnemy;
        }

        private void FixedUpdate()
        {
            if (_isReadyToMove)
            {
                ForwardMovement();
            }
            else
            {
                StopMovement();
            }
        }


        private void ForwardMovement()
        {
            rigidbody.velocity = new Vector3(0, 0, speedForward);
        }

        private void StopMovement()
        {
            rigidbody.velocity = Vector3.zero;
        }

        private void OnActivateEnemyMovementRigidbody(float speedValue)
        {
            speedForward = speedValue;
            _isReadyToMove = true;
        }

        private void OnDeactivateEnemyMovementRigidbody()
        {
            _isReadyToMove = false;
        }

        private void OnKillEnemy()
        {
            _isReadyToMove = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Finishline"))
            {
                EventManager.Instance.onLevelFailed?.Invoke();
            }

            if (other.CompareTag("Obstacle"))
            {
                collider.enabled = false;
                enemyManager.onKillEnemy?.Invoke();
                EventManager.Instance.onIncreaseKilledEnemyCount?.Invoke();
            }
        }
    }
}