using DG.Tweening;
using UnityEngine;

namespace Utility
{
    public class GiveForwardExplosionForceOnBoxingBobbyTrap : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void GiveExplosionForce()
        {
            DOVirtual.DelayedCall(.5f,
                () =>
                {
                    Vector3 forward;
                    Vector3 explosionPos = transform.forward;
                    Collider[] colliders = Physics.OverlapSphere(explosionPos, 5);
                    foreach (Collider hit in colliders)
                    {
                        Rigidbody rb = hit.GetComponent<Rigidbody>();

                        if (rb != null)
                            rb.AddExplosionForce(2000, explosionPos, 1, 25.0F);
                    }
                });
        }
    }
}