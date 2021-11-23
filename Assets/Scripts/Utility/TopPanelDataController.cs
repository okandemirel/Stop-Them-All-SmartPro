using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Utility
{
    public class TopPanelDataController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject topPanel;
        [SerializeField] private Image fillabledImage;
        [SerializeField] private TextMeshProUGUI levelText, enemyCountLeft, enemyCountRight;

        #endregion

        #region Private Variables

        private int _levelEnemyCount;

        #endregion

        #endregion

        private void Start()
        {
            UIManager.Instance.onActivateTopBar += OnActivateTopBar;
            UIManager.Instance.onDeactivateTopBar += OnDeactivateTopBar;
            UIManager.Instance.onSetLevelValueToText += OnSetLevelValueToText;
            UIManager.Instance.onSetLevelEnemyCountToBar += OnSetLevelEnemyCountToBar;
            UIManager.Instance.onSetKilledEnemyCountToUI += OnSetKilledEnemyCountToUI;
        }

        private void OnDisable()
        {
            UIManager.Instance.onActivateTopBar -= OnActivateTopBar;
            UIManager.Instance.onDeactivateTopBar -= OnDeactivateTopBar;
            UIManager.Instance.onSetLevelValueToText -= OnSetLevelValueToText;
            UIManager.Instance.onSetLevelEnemyCountToBar -= OnSetLevelEnemyCountToBar;
            UIManager.Instance.onSetKilledEnemyCountToUI -= OnSetKilledEnemyCountToUI;
        }

        private void OnActivateTopBar()
        {
            topPanel.SetActive(true);
        }

        private void OnDeactivateTopBar()
        {
            topPanel.SetActive(false);
        }

        private void OnSetLevelValueToText(int levelValue)
        {
            levelText.text = "LEVEL " + levelValue;
        }

        private void OnSetLevelEnemyCountToBar(int enemyCount)
        {
            _levelEnemyCount = enemyCount;
            enemyCountLeft.text = 0.ToString();
            enemyCountRight.text = enemyCount.ToString();
        }

        private void OnSetKilledEnemyCountToUI(int killedEnemyCount)
        {
            fillabledImage.DOFillAmount((float) killedEnemyCount / _levelEnemyCount, .5f);
            enemyCountLeft.text = killedEnemyCount.ToString();
        }
    }
}