//это для того чтобы можно было выбраться со второго уровня когда коллизии загораживают выход

using Pixel_Adventure_1.Assets.Scripts.Enemy;
using Pixel_Adventure_1.Assets.Scripts.Player;
using Pixel_Adventure_1.Assets.Scripts.Saves;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pixel_Adventure_1.Assets.Scripts
{
    public class DebugKeys : MonoBehaviour
    { 
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {

                PlayerPrefs.SetFloat(CheckpointSaveKeys.SaveX, 4.01f);
                PlayerPrefs.SetFloat(CheckpointSaveKeys.SaveY, 0.679f);
                PlayerPrefs.SetFloat(CheckpointSaveKeys.SaveZ, 0f);
                Debug.Log("Чекпоинт сохранён на G");

                PlayerPrefs.SetInt(CheckpointSaveKeys.PlayerScore, 0);
                Debug.Log("счетчик = 0");


                PlayerPrefs.SetInt(CheckpointSaveKeys.FirstLevelCompleted, 0);
                PlayerPrefs.SetInt(CheckpointSaveKeys.FirstLevelCurrentKill, 0);
                PlayerPrefs.SetInt(CheckpointSaveKeys.IsSecondLevel, 0);

                PlayerPrefs.Save();
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                GetComponent<PlayerHealth>().Die();
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                FindFirstObjectByType<EnemyHealth>().Die();
            }
        }
    }
}