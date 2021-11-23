using UnityEngine;

namespace Utility
{
    public class BoobyTrapPanelDeactivator : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject boobyTrapPanel;

        #endregion

        #endregion

        private void Start()
        {
            UIManager.Instance.onDeactivateBoobyTrapPanel += OnDeactivateBoobyTrapPanel;
        }

        private void OnDisable()
        {
            UIManager.Instance.onDeactivateBoobyTrapPanel -= OnDeactivateBoobyTrapPanel;
        }

        private void OnDeactivateBoobyTrapPanel()
        {
            boobyTrapPanel.SetActive(false);
        }
    }
}