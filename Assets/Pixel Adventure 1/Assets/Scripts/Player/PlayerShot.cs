using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{

    public class PlayerShot : MonoBehaviour
    {
        public GameObject BulletPrefab;
        public float BulletSpeed = 10;
        public Image ReloadImage;
        public Vector2 ShootDirection; //используется в EnemyHeal

        private Rigidbody2D _rb;
        private bool _isShot;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && transform.localScale.x > 0)
            {
                StartCoroutine(ShootCoroutine(Vector2.right));
                ShootDirection = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.F) && transform.localScale.x < 0)
            {
                StartCoroutine(ShootCoroutine(Vector2.left));
                ShootDirection = Vector2.left;
            }
        }

        private IEnumerator ShootCoroutine(Vector2 direction)
        {
            if (_isShot)
            {
                yield break;
            }

            _isShot = true;
            Shoot(direction);
            yield return new WaitForSeconds(0.025f);
            Shoot(direction);
            yield return new WaitForSeconds(0.025f);
            Shoot(direction);

            yield return new WaitForSeconds(1);
            _isShot = false;
        }

        private void Shoot(Vector2 transition)
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            _rb = bullet.GetComponent<Rigidbody2D>();
            _rb.AddForce(transition * BulletSpeed, ForceMode2D.Impulse);
            Destroy(bullet, 2f);

            ReloadImage.fillAmount = 0;
            StartCoroutine(ReloadShootCoroutine(1));
        }

        private IEnumerator ReloadShootCoroutine(float duration)
        {
            float time = 0;
            while (ReloadImage.fillAmount < 1)
            {
                time += Time.deltaTime;
                ReloadImage.fillAmount = time / duration;
                yield return null;
            }
        }
    }
}
