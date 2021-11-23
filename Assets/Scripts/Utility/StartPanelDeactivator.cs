using UnityEngine;

namespace Utility
{
    public class StartPanelDeactivator : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject startPanel;

        #endregion

        #endregion

        private void Start()
        {
            UIManager.Instance.onDeactivateStartPanel += OnDeactivateStartPanel;
        }

        private void OnDisable()
        {
            UIManager.Instance.onDeactivateStartPanel -= OnDeactivateStartPanel;
        }

        private void OnDeactivateStartPanel()
        {
            startPanel.SetActive(false);
        }
    }
}