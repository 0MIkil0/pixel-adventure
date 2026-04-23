using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    //добавил коллизию при входе в зону второго уровня
    public GameObject leftCollision;
    public GameObject rightCollision;
    private BoxCollider2D _rightCollider;
    private BoxCollider2D _leftCollider;
    public Transform respawnPoint;


    private void Start()
    {
        _rightCollider = rightCollision.GetComponent<BoxCollider2D>();
        _leftCollider = leftCollision.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ЗАГРУЗКА СЕйВА В Movement
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("SaveX", respawnPoint.position.x);
            PlayerPrefs.SetFloat("SaveY", respawnPoint.position.y);
            PlayerPrefs.SetFloat("SaveZ", respawnPoint.position.z);
            PlayerPrefs.Save();

            _leftCollider.enabled = true;
            _rightCollider.enabled = true;
        }
    }
}
