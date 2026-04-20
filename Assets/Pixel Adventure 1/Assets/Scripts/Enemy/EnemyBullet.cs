using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Enemy
{
    public class EnemyBullet : MonoBehaviour
    {
        public float enemyBulletDamage = 15f;
        private Rigidbody2D _rb;
        public Vector2 directionBullet;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag($"Enemy") && !other.CompareTag($"Apple")) 
            {
                Vector2 currentVelocity = _rb.linearVelocity;
                if (currentVelocity.x < 0)
                {
                    directionBullet = Vector2.left;
                }
                else if (currentVelocity.x > 0)
                {
                    directionBullet = Vector2.right;
                }
                Destroy(this.gameObject);
            }
        }
    }
}

