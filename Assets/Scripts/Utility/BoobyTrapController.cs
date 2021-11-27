using DG.Tweening;
using Managers;
using UnityEngine;

namespace Utility
{
    public class BoobyTrapController : MonoBehaviour
    {
        public void OnActivateBoobyTrap()
        {
            EventManager.Instance.onActivateBoobyTrap?.Invoke(GameplayManager.Instance.StageID);
            GameplayManager.Instance.StageID++;
            DOVirtual.DelayedCall(1, () => EventManager.Instance.onSetCinemachineTarget?.Invoke());
        }
    }
}