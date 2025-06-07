using UnityEngine;

namespace HouseStage.Effects
{
    public class EffectZone: MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particles;

        private void OnTriggerEnter(Collider other)
        {
            foreach (var particle in particles)
            {
                particle.Play();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            gameObject.SetActive(false);
        }
    }
}