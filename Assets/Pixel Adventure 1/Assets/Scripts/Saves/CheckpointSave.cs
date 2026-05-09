using System;
using Pixel_Adventure_1.Assets.Scripts.Levels.Level2;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{
    public class CheckpointSave : MonoBehaviour
    {
        public Transform respawnPoint;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //ЗАГРУЗКА СЕйВА В Movement
            if (collision.gameObject.CompareTag("Player"))
            {
                //координаты
                PlayerPrefs.SetFloat(SaveKeys.SaveX, respawnPoint.position.x);
                PlayerPrefs.SetFloat(SaveKeys.SaveY, respawnPoint.position.y);
                PlayerPrefs.SetFloat(SaveKeys.SaveZ, respawnPoint.position.z);
                //сейв
                PlayerPrefs.Save();
            }
        }
    }
}
