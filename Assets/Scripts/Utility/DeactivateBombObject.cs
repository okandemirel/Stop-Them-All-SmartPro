using DG.Tweening;
using UnityEngine;

namespace Utility
{
    public class DeactivateBombObject : MonoBehaviour
    {
        [SerializeField] private Collider boxCollider;

        public void DeactivateTNT()
        {
            gameObject.SetActive(false);
        }

        public void DeactivateBoxCollider()
        {
            boxCollider.enabled = false;
        }

        public void GiveExplosionForce()
        {
            DOVirtual.DelayedCall(.3f, () =>
            {
                Vector3 explosionPos = transform.GetChild(0).position;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, 5);
                foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                        rb.AddExplosionForce(2000, explosionPos, 1, 25.0F);
                }
            });
        }

        public void LateActivateBoxCollider()
        {
            DOVirtual.DelayedCall(.2f, () => boxCollider.enabled = true);
        }
    }
}