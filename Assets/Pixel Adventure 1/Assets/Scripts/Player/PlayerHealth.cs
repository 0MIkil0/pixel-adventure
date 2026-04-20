using System.Collections;
using Pixel_Adventure_1.Assets.Scripts.Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{

    public class PlayerHealth : MonoBehaviour
    {
        private static readonly int IsGetHit = Animator.StringToHash("isGetHit");
        private static readonly int IsDeath = Animator.StringToHash("isDeath");
        public float maxHealth = 100f;
        public float currentHealth = 100f;
        public HealthBar fullHelthBar;
        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.SetBool(IsGetHit, false);
        }
        public void TakeDamage(float damage)
        {
            _animator.SetBool(IsGetHit, true);
            currentHealth -= damage;
            fullHelthBar.UpdateHealthOnBar(currentHealth/maxHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
        public void Heal(float health)
        {
            if (currentHealth >= 100)
            {
                return;
            }
            currentHealth += health;
            fullHelthBar.UpdateHealthOnBar(currentHealth / maxHealth);
        }

        void Die()
        {
           GetComponent<PlayerMovement2D>().enabled = false;
            _animator.SetBool(IsGetHit, false);
            _animator.SetBool(IsDeath, true);

            StartCoroutine(Restart());
        }

        private IEnumerator Restart()
        {
            yield return new WaitForSeconds(3f);
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        public void OnDamageAnimationEnd()
        {
            _animator.SetBool(IsGetHit, false);
            _animator.ResetTrigger(IsGetHit); 
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("BulletEnemy"))
            {
                EnemyBullet bullet = collision.GetComponent<EnemyBullet>();
                if (bullet != null)
                {
                    TakeDamage(bullet.enemyBulletDamage);
                    StartCoroutine(ShotCoroutine(bullet.directionBullet));
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
            GetComponent<Rigidbody2D>().AddForce(shotDirection *3f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);
            playerMovement.enabled = true;
            
        }
    }
    }
