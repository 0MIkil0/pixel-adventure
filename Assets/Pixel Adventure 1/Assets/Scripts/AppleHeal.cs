using System;
using Pixel_Adventure_1.Assets.Scripts.Player;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts
{
    public class AppleHeal : MonoBehaviour
    {
        public event Action OnCollected;
        private const float _appleHeal = 20f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerHealth = other.GetComponent<PlayerHealth>();
            if (other.CompareTag("Player"))
            {
                playerHealth.Heal(_appleHeal);
                Destroy(gameObject);
                OnCollected?.Invoke();
            }
        }
    }
}