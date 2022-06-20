using System;
using DG.Tweening;
using UnityEngine;

namespace Characters
{
    public class Ghost : MonoBehaviour
    {
        public delegate void GhostDeathEvent(float score);
        public static event GhostDeathEvent OnGhostDeathScore;

        public static event Action OnGhostDeath;

        [Header("Params")]
        [SerializeField]
        private float speedMovement = 5f;
        [SerializeField]
        private float deathScore;
        [SerializeField]
        private GameObject deathParticles;

        private void Start()
        {
            Movement();
        }

        private void Movement()
        {
            transform.DOMoveY(8, speedMovement)
                .SetSpeedBased().SetEase(Ease.Linear)
                .OnComplete(GhostDestroy);
        }

        private void GhostDestroy()
        {
            OnGhostDeath?.Invoke();

            DOTween.Kill(transform);
            Destroy(gameObject);
        }

        public void GhostDeath()
        {
            OnGhostDeathScore?.Invoke(deathScore);
            OnGhostDeath?.Invoke();

            DOTween.Kill(transform);
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}