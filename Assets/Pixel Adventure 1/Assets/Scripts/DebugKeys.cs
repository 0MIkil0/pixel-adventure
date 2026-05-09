//это для того чтобы можно было выбраться со второго уровня когда коллизии загораживают выход

using Pixel_Adventure_1.Assets.Scripts.Enemy;
using Pixel_Adventure_1.Assets.Scripts.Player;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts
{
    public class DebugKeys : MonoBehaviour
    {
        public GameObject leftCollision;
        public GameObject rightCollision;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {

                PlayerPrefs.SetFloat(SaveKeys.SaveX, 4.01f);
                PlayerPrefs.SetFloat(SaveKeys.SaveY, 0.679f);
                PlayerPrefs.SetFloat(SaveKeys.SaveZ, 0f);
                Debug.Log("Чекпоинт сохранён на G");

                PlayerPrefs.SetInt(SaveKeys.PlayerScore, 0);
                Debug.Log("счетчик = 0");


                PlayerPrefs.SetInt(SaveKeys.FirstLevelCompleted, 0);
                PlayerPrefs.SetInt(SaveKeys.FirstLevelCurrentKill, 0);
                PlayerPrefs.SetInt(SaveKeys.IsSecondLevel, 0);

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