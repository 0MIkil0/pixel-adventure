using Pixel_Adventure_1.Assets.Scripts.Player;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts
{
    public class DethZone : MonoBehaviour
    {
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(100);
                }

            }
        }
    }
}
