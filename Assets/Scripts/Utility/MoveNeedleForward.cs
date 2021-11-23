using DG.Tweening;
using UnityEngine;

namespace Utility
{
    public class MoveNeedleForward : MonoBehaviour
    {
        public GameObject Needle;

        public void MoveUpwards()
        {
            Needle.transform.DOLocalMoveY(.061f, .3f).SetEase(Ease.OutBounce).SetRelative(true);
        }

        public void MoveBackwards()
        {
            Needle.transform.DOLocalMoveY(-.061f, .3f).SetEase(Ease.Linear).SetRelative(true);
        }

        public void GiveUpwardsForce()
        {
            Vector3 explosionPos = transform.up;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, 5);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(4500, explosionPos, 3, 100.0F);
            }
        }
    }
}