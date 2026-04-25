using System.Collections;
using Pixel_Adventure_1.Assets.Scripts.Player;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Enemy
{
    public class EnemyHeal : MonoBehaviour
    {
        private static readonly int IsDie = Animator.StringToHash("isDie");
        private static readonly int IsMoving = Animator.StringToHash("isMoving");
        private float _health = 100f;
        public Bullet bullet;
        public Shot shot;
        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private EnemyAi _enemyAi;
        private ShotEnemy _shotEnemy;
        private bool isDead = false;

        void Start()
        {
            _enemyAi = GetComponent<EnemyAi>();
            _shotEnemy = GetComponent<ShotEnemy>();
            _rigidbody =  GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _animator.SetBool(IsDie, false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isDead)
            {
                return;
            }

            if (collision.gameObject.CompareTag($"Bullet"))
            {
                StartCoroutine(ForceBullet());
                StartCoroutine(TakeDamage(bullet.bulletDamage));
            }
        }

        private IEnumerator TakeDamage(float damage)
        {
            if (isDead)
            {
                yield break;
            }

            _health -= damage;

            if (_health <= 0)
            {
                isDead = true;
                Die();
                yield break;
            }
            yield return null;
        }

        private void Die()
        {
            StopAllCoroutines();
            _enemyAi.CancelInvoke();
            _enemyAi.enabled = false;
            
            if (_shotEnemy != null)
            {
                _shotEnemy.enabled = false;
            }

            Vector2 deathVelocity = _rigidbody.linearVelocity;
            deathVelocity.y = 0f;
            _rigidbody.linearVelocity = deathVelocity * 0.95f;
            _rigidbody.gravityScale = 0f;
            _rigidbody.angularVelocity = 0f;
            _rigidbody.freezeRotation = true;
            _rigidbody.linearDamping = 8f;

            _animator.SetBool(IsDie, true);
            _animator.SetBool(IsMoving, false);

            FindFirstObjectByType<Score>().AddScore();
            
            Destroy(gameObject, 3f);
        }
        private IEnumerator ForceBullet()
        {
                if (isDead)
                {
                    yield break;
                }

                _enemyAi.enabled = false;
                _rigidbody.AddForce(shot.shootDirection * 1f, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.15f);
                if (!isDead)
                {
                    _enemyAi.enabled = true;
                }
        }
    }
    
}
