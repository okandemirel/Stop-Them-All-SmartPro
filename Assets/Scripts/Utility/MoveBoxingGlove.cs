using DG.Tweening;
using UnityEngine;

namespace Utility
{
    public class MoveBoxingGlove : MonoBehaviour
    {
        public void MoveBoxingGloveBackwards()
        {
            transform.DOLocalMove(new Vector3(0, 0, 4), 1).SetRelative(true).SetEase(Ease.Linear);
        }
    }
}