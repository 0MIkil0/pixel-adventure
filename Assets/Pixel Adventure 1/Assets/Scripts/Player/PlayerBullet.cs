using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{
    public class PlayerBullet : MonoBehaviour
    {
        public float BulletDamage = 10f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player") && !other.CompareTag($"Apple"))
            {
                Destroy(gameObject);
            }
        }
    }
}
