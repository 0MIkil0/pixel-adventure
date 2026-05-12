using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Saves
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
                PlayerPrefs.SetFloat(CheckpointSaveKeys.SaveX, respawnPoint.position.x);
                PlayerPrefs.SetFloat(CheckpointSaveKeys.SaveY, respawnPoint.position.y);
                PlayerPrefs.SetFloat(CheckpointSaveKeys.SaveZ, respawnPoint.position.z);
                //сейв
                PlayerPrefs.Save();
            }
        }
    }
}
