//это для того чтобы можно было выбраться со второго уровня когда коллизии загораживают выход

using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{
    public class DebugKeys : MonoBehaviour
    {
        public GameObject leftCollision;
        public GameObject rightCollision;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                PlayerPrefs.SetFloat("SaveX", 4.01f);
                PlayerPrefs.SetFloat("SaveY", 0.679f);
                PlayerPrefs.SetFloat("SaveZ", 0f);
                
                PlayerPrefs.Save();
                Debug.Log("Чекпоинт сохранён на G");
                
               // PlayerHealth Health = GetComponent<PlayerHealth>();
               // Health.Die();
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                GetComponent<PlayerHealth>().Die();
            }
        }
    }
}