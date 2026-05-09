using System.Collections.Generic;
using Pixel_Adventure_1.Assets.Scripts;
using System.Collections;
using UnityEngine;


public class EnemyShoot : MonoBehaviour
{
    private Rigidbody2D _rb;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public LayerMask playerLayer;
    public Transform bulletSpawn;
   

    void FixedUpdate()
    {
        if (transform.localScale.x > 0)
        {
            Raycast(transform.right, 20);
        }
        else if (transform.localScale.x < 0)
        {
            Raycast(transform.right * -1, 20);
        }
        
    }
    private bool _canShoot = true;
    void Raycast(Vector2 direction, float rayLength)
    {
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, direction, rayLength, playerLayer);
       
        if (hit.collider != null && _canShoot)
        {
            if (transform.localScale.x > 0)
            {
                StartCoroutine(ShotCoroutine(transform.right));
            }
            else if (transform.localScale.x < 0)
            {
                StartCoroutine(ShotCoroutine(transform.right * -1));
            }
        }
    }

    IEnumerator ShotCoroutine(Vector2 x)
    {
        _canShoot = false;
        GameObject enemyBullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        _rb = enemyBullet.GetComponent<Rigidbody2D>();
        _rb.AddForce(x * bulletSpeed, ForceMode2D.Impulse);
        
        yield return new WaitForSeconds(1.8f);
        _canShoot = true;
     
        Destroy(enemyBullet, 2f); 
    }
}
