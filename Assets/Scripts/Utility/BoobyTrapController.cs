using Managers;
using UnityEngine;

namespace Utility
{
    public class BoobyTrapController : MonoBehaviour
    {
        public void OnActivateBoobyTrap()
        {
            EventManager.Instance.onActivateBoobyTrap?.Invoke(GameplayManager.Instance.StageID);
        }
    }
}