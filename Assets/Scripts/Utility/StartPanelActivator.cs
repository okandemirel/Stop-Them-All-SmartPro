using UnityEngine;

namespace Utility
{
    public class StartPanelActivator : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject startPanel;

        #endregion

        #endregion

        private void Start()
        {
            UIManager.Instance.onActivateStartPanel += OnActivateStartPanel;
        }

        private void OnDisable()
        {
            UIManager.Instance.onActivateStartPanel -= OnActivateStartPanel;
        }

        private void OnActivateStartPanel()
        {
            startPanel.SetActive(true);
        }
    }
}