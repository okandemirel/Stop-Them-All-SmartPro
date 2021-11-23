using DG.Tweening;
using UnityEngine;

namespace Utility
{
    public class RotateLeftRightRoad : MonoBehaviour
    {
        public GameObject leftRoadObject, rightRoadObject;

        public void ActivateFreeRoad()
        {
            leftRoadObject.transform.DOLocalRotate(new Vector3(0, 90, 0), 1).SetEase(Ease.OutBounce).SetRelative(true);
            rightRoadObject.transform.DOLocalRotate(new Vector3(0, -90, 0), 1).SetEase(Ease.OutBounce).SetRelative(true);
        }

        public void DeActivateFreeRoad()
        {
            leftRoadObject.transform.DOLocalRotate(new Vector3(0, -90, 0), 1).SetEase(Ease.Linear).SetRelative(true);
            rightRoadObject.transform.DOLocalRotate(new Vector3(0, 90, 0), 1).SetEase(Ease.Linear).SetRelative(true);
        }
    }
}