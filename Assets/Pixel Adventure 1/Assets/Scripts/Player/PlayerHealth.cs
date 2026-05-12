using System.Collections;
using Pixel_Adventure_1.Assets.Scripts.Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{

    public class PlayerHealth : MonoBehaviour
    {
        public PlayerHealthBar FullHealthBar;
        public float MaxHealth = 100f;
        public float CurrentHealth = 100f;
        private static readonly int IsGetHit = Animator.StringToHash("isGetHit");
        private static readonly int IsDeath = Animator.StringToHash("isDeath");
        private Animator _animator;
        private Collider2D _collider;
        private Rigidbody2D _rb;

        void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.SetBool(IsGetHit, false);
            _collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Die()
        {
            _animator.SetBool(IsGetHit, false);
            _animator.SetBool(IsDeath, true);
            _collider.enabled = false;

            _rb.linearVelocity = Vector2.zero;
            _rb.gravityScale = 0f;
            _rb.bodyType = RigidbodyType2D.Kinematic;

            StartCoroutine(Restart());
            GetComponent<PlayerMovement2D>().enabled = false;
        }

        public void TakeDamage(float damage)
        {
            _animator.SetBool(IsGetHit, true);
            CurrentHealth -= damage;
            FullHealthBar.UpdateHealthOnBar(CurrentHealth / MaxHealth);
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        public void Heal(float health)
        {
            if (CurrentHealth >= 100)
            {
                return;
            }

            CurrentHealth += health;
            FullHealthBar.UpdateHealthOnBar(CurrentHealth / MaxHealth);
        }

        public void OnDamageAnimationEnd()
        {
            _animator.SetBool(IsGetHit, false);
            _animator.ResetTrigger(IsGetHit);
        }


        private IEnumerator Restart()
        {
            yield return new WaitForSeconds(3f);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("BulletEnemy"))
            {
                EnemyBullet bullet = collision.GetComponent<EnemyBullet>();
                if (bullet != null)
                {
                    TakeDamage(bullet.EnemyBulletDamage);
                    StartCoroutine(ShotCoroutine(bullet.DirectionBullet));
                    StartCoroutine(TakeDamageAnimationEnd());
                }
            }
        }

        IEnumerator TakeDamageAnimationEnd()
        {
            yield return new WaitForSeconds(0.3f);
            OnDamageAnimationEnd();
        }

        IEnumerator ShotCoroutine(Vector2 shotDirection)
        {
            PlayerMovement2D playerMovement = GetComponent<PlayerMovement2D>();
            playerMovement.enabled = false;
            GetComponent<Rigidbody2D>().AddForce(shotDirection * 3f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);
            if (CurrentHealth > 0)
            {
                playerMovement.enabled = true;
            }
        }
    }
}
