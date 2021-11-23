using UnityEngine;

namespace Utility
{
    public class BoobyTrapPanelActivator : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject boobyTrapPanel;

        #endregion

        #endregion

        private void Start()
        {
            UIManager.Instance.onActivateBoobyTrapPanel += OnActivateBoobyTrapPanel;
        }

        private void OnDisable()
        {
            UIManager.Instance.onActivateBoobyTrapPanel -= OnActivateBoobyTrapPanel;
        }


        private void OnActivateBoobyTrapPanel()
        {
            boobyTrapPanel.SetActive(true);
        }
    }
}