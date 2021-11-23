using DG.Tweening;
using UnityEngine;

namespace Utility
{
    public class MoveSledgeBackwards : MonoBehaviour
    {
        public void MoveBackwards()
        {
            transform.DOLocalRotate(new Vector3(-90, 0, 0), .8f, RotateMode.Fast).SetRelative(true).SetEase(Ease.Linear);
        }

        public void DownwardsForce()
        {
            Vector3 explosionPos = -transform.up;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, 5);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(4500, explosionPos, 3, -100.0F);
            }
        }
    }
} 