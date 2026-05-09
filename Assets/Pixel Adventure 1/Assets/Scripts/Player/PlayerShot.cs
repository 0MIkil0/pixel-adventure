using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{
   
    public class PlayerShot : MonoBehaviour
    {
        private Rigidbody2D _rb;
        public GameObject bulletPrefab;
        public float bulletSpeed = 10;
        private bool _isShot ;
        public Image reloadImage;
        public Vector2 shootDirection; //используется в EnemyHeal
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && transform.localScale.x > 0)
            {
                StartCoroutine(ShootCorrutine(Vector2.right));
                shootDirection =  Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.F) && transform.localScale.x < 0)
            {
                StartCoroutine(ShootCorrutine(Vector2.left));
                shootDirection =  Vector2.left;
            }
        }

        IEnumerator ShootCorrutine(Vector2 direction)
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
        
        void Shoot(Vector2 transition)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            _rb = bullet.GetComponent<Rigidbody2D>(); 
            _rb.AddForce(transition * bulletSpeed, ForceMode2D.Impulse);
            Destroy(bullet, 2f);
            
            reloadImage.fillAmount = 0;
            StartCoroutine(ReloadShootCorrutine(1));
        }

        IEnumerator ReloadShootCorrutine(float duration)
        {
            float time = 0; 
            while (reloadImage.fillAmount < 1)
            {
                time += Time.deltaTime; 
                reloadImage.fillAmount = time / duration;
                yield return null;
            }
        }
    }
}
