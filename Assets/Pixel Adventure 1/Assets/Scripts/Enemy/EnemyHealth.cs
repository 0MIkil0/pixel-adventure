using System.Collections;
using Pixel_Adventure_1.Assets.Scripts.Levels.Level1;
using Pixel_Adventure_1.Assets.Scripts.Player;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public PlayerBullet PlayerBullet;
        public PlayerShot PlayerShot;
        private Animator _animator;
        private Rigidbody2D _rb;
        private EnemyAi _enemyAi;
        private EnemyShoot _enemyShoot;
        private static readonly int IsDie = Animator.StringToHash("isDie");
        private static readonly int IsMoving = Animator.StringToHash("isMoving");
        private float _health = 100f;
        private bool _isDead = false;

        private void Start()
        {
            _enemyAi = GetComponent<EnemyAi>();
            _enemyShoot = GetComponent<EnemyShoot>();
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _animator.SetBool(IsDie, false);
        }

        public void Die()
        {
            StopAllCoroutines();
            _enemyAi.CancelInvoke();
            _enemyAi.enabled = false;
            if (_enemyShoot != null)
            {
                _enemyShoot.enabled = false;
            }

            Vector2 deathVelocity = _rb.linearVelocity;
            deathVelocity.y = 0f;
            _rb.linearVelocity = deathVelocity * 0.95f;
            _rb.gravityScale = 0f;
            _rb.angularVelocity = 0f;
            _rb.freezeRotation = true;
            _rb.linearDamping = 8f;
            _animator.SetBool(IsDie, true);
            _animator.SetBool(IsMoving, false);
            FindFirstObjectByType<ScoreManager>().AddScore();
            FindFirstObjectByType<Level1ScoreCounter>().AddScore();
            Destroy(gameObject, 3f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isDead)
            {
                return;
            }

            if (collision.gameObject.CompareTag($"Bullet"))
            {
                StartCoroutine(ForceBullet());
                StartCoroutine(TakeDamage(PlayerBullet.BulletDamage));
            }
        }

        private IEnumerator TakeDamage(float damage)
        {
            if (_isDead)
            {
                yield break;
            }

            _health -= damage;

            if (_health <= 0)
            {
                _isDead = true;
                Die();
                yield break;
            }

            yield return null;
        }

        private IEnumerator ForceBullet()
        {
            if (_isDead)
            {
                yield break;
            }

            _enemyAi.enabled = false;
            _rb.AddForce(PlayerShot.ShootDirection * 1f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.15f);
            if (!_isDead)
            {
                _enemyAi.enabled = true;
            }
        }
    }
}
