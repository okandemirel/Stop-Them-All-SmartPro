using DG.Tweening;
using UnityEngine;

namespace Utility
{
    public class MoveBoxingStickForward : MonoBehaviour
    {
        public void MoveBoxingForward()
        {
            transform.DOLocalMove(new Vector3(0, 0, 0.04f), 1.2f).SetRelative(true).SetEase(Ease.OutQuad);
        }
    }
}