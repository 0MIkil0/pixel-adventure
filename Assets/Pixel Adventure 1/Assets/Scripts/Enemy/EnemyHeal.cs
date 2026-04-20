using System.Collections;
using Pixel_Adventure_1.Assets.Scripts.Player;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Enemy
{
    public class EnemyHeal : MonoBehaviour
    {
        private static readonly int IsDie = Animator.StringToHash("isDie");
        private float _health = 100f;
        public Bullet bullet;
        public Shot shot;
        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private EnemyAi _enemyAi;

        void Start()
        {
            _enemyAi = GetComponent<EnemyAi>();
            _rigidbody =  GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _animator.SetBool(IsDie, false);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag($"Bullet"))
            {
                StartCoroutine(ForceBullet());
                StartCoroutine(TakeDamage(bullet.bulletDamage));
            }
        }
        private IEnumerator TakeDamage(float damage)
        {
                _health -= damage;
                yield return new WaitForSeconds(0.2f);
                if (_health <= 0)
                {
                   StartCoroutine(Die());
                }
        }
        private IEnumerator Die()
        {
            _enemyAi.enabled = false;
            GetComponent<ShotEnemy>().enabled = false;
            _animator.SetBool(IsDie, true);
            Destroy(this.gameObject, 3f);
            yield return new WaitForSeconds(1f);
            _rigidbody.linearVelocity = new Vector2(0 * 0, _rigidbody.linearVelocity.y);
            
        }

        private IEnumerator ForceBullet()
        {
                _enemyAi.enabled = false;
                _rigidbody.AddForce(shot.shootDirection * 1f, ForceMode2D.Impulse);
                yield return new WaitForSeconds(0.15f);
                _enemyAi.enabled = true;
            
        }
    }
    
}