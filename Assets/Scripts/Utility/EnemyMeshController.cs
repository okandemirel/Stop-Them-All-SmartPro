using Managers;
using UnityEngine;

namespace Utility
{
    public class EnemyMeshController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Renderer skinnedMeshRenderer;
        [SerializeField] private Material deadMaterial;
        [SerializeField] private EnemyManager enemyManager;

        #endregion

        #endregion

        private void Start()
        {
            enemyManager = GetComponent<EnemyManager>();

            enemyManager.onKillEnemy += OnKillEnemy;
        }

        private void OnDisable()
        {
            enemyManager.onKillEnemy -= OnKillEnemy;
        }

        private void OnKillEnemy()
        {
            skinnedMeshRenderer.material = deadMaterial;
        }
    }
}