using UnityEngine;

namespace Utility
{
    public class ActivateFireParticleFireTrap : MonoBehaviour
    {
        [SerializeField] private ParticleSystem fireParticle;
        [SerializeField] private Collider boxCollider;

        public void ActivateFireTrap()
        {
            fireParticle.Play();
            boxCollider.enabled = true;
        }

        public void DeActivateFireTrap()
        {
            fireParticle.Stop();
            boxCollider.enabled = false;
        }
    }
}