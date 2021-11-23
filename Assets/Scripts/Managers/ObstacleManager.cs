using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Managers
{
    public class ObstacleManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<DOTweenAnimation> tweenAnimations = new List<DOTweenAnimation>();

        [Tooltip("Sırasıyla dizilen objelerin ID'leride sırasıyla olamalı, burada ID Stage'i temsil ediyor.")]
        [SerializeField]
        private int ID;

        #endregion

        #endregion

        private void Start()
        {
            EventManager.Instance.onActivateBoobyTrap += OnActivateBoobyTrap;
        }

        private void OnDisable()
        {
            EventManager.Instance.onActivateBoobyTrap -= OnActivateBoobyTrap;
        }

        private void OnActivateBoobyTrap(int activatedObstacleCount)
        {
            if (ID != activatedObstacleCount) return;
            foreach (var tweenAnimation in tweenAnimations)
            {
                tweenAnimation.DOPlay();
            }
        }
    }
}