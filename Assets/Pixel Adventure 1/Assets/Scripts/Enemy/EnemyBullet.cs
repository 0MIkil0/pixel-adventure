using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Enemy
{
    public class EnemyBullet : MonoBehaviour
    {
        public float EnemyBulletDamage = 15f;
        public Vector2 DirectionBullet;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag($"Enemy") || other.CompareTag($"Apple")) return;
            var currentVelocity = _rb.linearVelocity;
            switch (currentVelocity.x)
            {
                case < 0:
                    DirectionBullet = Vector2.left;
                    break;
                case > 0:
                    DirectionBullet = Vector2.right;
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}

