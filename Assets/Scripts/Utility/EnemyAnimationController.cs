using Managers;
using UnityEngine;

namespace Utility
{
    public class EnemyAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Animator animator;
        [SerializeField] private EnemyManager enemyManager;

        #endregion

        #region Private Variables

        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Idle = Animator.StringToHash("Idle");

        #endregion

        #endregion

        private void Start()
        {
            enemyManager = GetComponent<EnemyManager>();

            enemyManager.onActivateEnemyMovementAnimation += OnActivateEnemyMovementAnimation;
            enemyManager.onDeactivateEnemyMovementAnimation += OnDeactivateEnemyMovementAnimation;

            enemyManager.onKillEnemy += OnKillEnemy;
        }

        private void OnDisable()
        {
            enemyManager.onActivateEnemyMovementAnimation -= OnActivateEnemyMovementAnimation;
            enemyManager.onDeactivateEnemyMovementAnimation -= OnDeactivateEnemyMovementAnimation;

            enemyManager.onKillEnemy -= OnKillEnemy;
        }

        private void OnActivateEnemyMovementAnimation()
        {
            animator.SetTrigger(Run);
        }

        private void OnDeactivateEnemyMovementAnimation()
        {
            animator.SetTrigger(Idle);
        }

        private void OnKillEnemy()
        {
            animator.SetTrigger(Idle);
            animator.enabled = false;
        }
    }
}