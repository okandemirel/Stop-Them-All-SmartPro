using System;
using UnityEngine;

namespace Utility
{
    public class LevelEndPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject levelFailedPanel, levelSuccessPanel;

        #endregion

        #endregion

        private void Start()
        {
            UIManager.Instance.onActivateLevelSuccessPanel += OnActivateLevelSuccessPanel;
            UIManager.Instance.onActivateLevelFailedPanel += OnActivateLevelFailedPanel;
            UIManager.Instance.onDeactivateLevelFailedPanel += OnDeactivateLevelFailedPanel;
            UIManager.Instance.onDeactivateLevelSuccessPanel += OnDeactivateLevelSuccessPanel;
        }

        private void OnDisable()
        {
            UIManager.Instance.onActivateLevelSuccessPanel -= OnActivateLevelSuccessPanel;
            UIManager.Instance.onActivateLevelFailedPanel -= OnActivateLevelFailedPanel;
            UIManager.Instance.onDeactivateLevelFailedPanel -= OnDeactivateLevelFailedPanel;
            UIManager.Instance.onDeactivateLevelSuccessPanel -= OnDeactivateLevelSuccessPanel;
        }

        private void OnActivateLevelSuccessPanel()
        {
            levelSuccessPanel.SetActive(true);
        }

        private void OnActivateLevelFailedPanel()
        {
            levelFailedPanel.SetActive(true);
        }

        private void OnDeactivateLevelFailedPanel()
        {
            levelFailedPanel.SetActive(false);
        }

        private void OnDeactivateLevelSuccessPanel()
        {
            levelSuccessPanel.SetActive(false);
        }
    }
}