using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Singleton

        public static CameraManager Instance;

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

        #region Serialized Variables

        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        #endregion

        #endregion

        private void Start()
        {
            EventManager.Instance.onSetCinemachineTarget += CameraSetter;
            EventManager.Instance.onRestartLevel += DelayedCameraSetter;
            EventManager.Instance.onNextLevel += DelayedCameraSetter;

            DOVirtual.DelayedCall(.1f, CameraSetter);
        }

        private void OnDisable()
        {
            EventManager.Instance.onSetCinemachineTarget -= CameraSetter;
            EventManager.Instance.onRestartLevel -= DelayedCameraSetter;
            EventManager.Instance.onNextLevel -= DelayedCameraSetter;
        }

        private void DelayedCameraSetter()
        {
            DOVirtual.DelayedCall(.2f, CameraSetter);
        }

        private void CameraSetter()
        {
            var enemies = new List<EnemyManager>();
            enemies = FindObjectsOfType<EnemyManager>().ToList();


            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].IsKilled)
                    enemies.Remove(enemies[i]);
            }

            EnemyManager maxX = null;

            foreach (var t in enemies)
            {
                if (maxX == null) maxX = enemies[0];
                if (t.transform.localPosition.x > maxX.transform.localPosition.x) maxX = t;
            }

            var playerView = Object.FindObjectOfType<PlayerManager>();
            if (enemies.Count > 0)
            {
                if (maxX is { }) playerView.transform.position = maxX.gameObject.transform.position;
            }

            DOVirtual.DelayedCall(.02f,
                () => SetCameraTarget(playerView.gameObject));
        }

        private void SetCameraTarget(GameObject playerViewGameObject)
        {
            virtualCamera.Follow = playerViewGameObject.transform;
            virtualCamera.LookAt = playerViewGameObject.transform;
        }
    }
}