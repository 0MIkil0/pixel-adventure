using Pixel_Adventure_1.Assets.Scripts.Player;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts
{
    public class DamageFire : MonoBehaviour
    {
        private readonly float _damage = 0.5f;
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(_damage);
                }
               
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.OnDamageAnimationEnd();
                }
               
            }
        }
    }
}