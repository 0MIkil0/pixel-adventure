using System;
using Pixel_Adventure_1.Assets.Scripts.Enemy;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{
    public class Bullet : MonoBehaviour
    {
        public float bulletDamage = 10f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player") && !other.CompareTag($"Apple"))
            {
                Destroy(gameObject);
            }
        }
    }
}