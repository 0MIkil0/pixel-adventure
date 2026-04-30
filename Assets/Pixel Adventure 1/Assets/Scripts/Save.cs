using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{
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
                Debug.Log("Player entered");
                //координаты
                PlayerPrefs.SetFloat("SaveX", respawnPoint.position.x);
                PlayerPrefs.SetFloat("SaveY", respawnPoint.position.y);
                PlayerPrefs.SetFloat("SaveZ", respawnPoint.position.z);

                //очки
                int playerScore = FindFirstObjectByType<Score>().playerScore;
                PlayerPrefs.SetInt("playerScore", playerScore);
                
                //сейв
                PlayerPrefs.Save();

                //загрузка цели на второй уровень 
                FindFirstObjectByType<SecondLevel>().ChangeSecondLevel();
                
                _leftCollider.enabled = true;
                _rightCollider.enabled = true;
            }
        }
    }
}
