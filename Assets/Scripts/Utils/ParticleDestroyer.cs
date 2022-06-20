using UnityEngine;

namespace Utils
{
    public class ParticleDestroyer : MonoBehaviour
    {
        // Private vars
        private ParticleSystem _particleSystem;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();

            DestroyParticle();
        }

        private void DestroyParticle()
        {
            Destroy(gameObject, _particleSystem.main.duration + 0.1f);
        }
    }
}