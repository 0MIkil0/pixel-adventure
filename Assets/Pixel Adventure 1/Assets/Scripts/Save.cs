using UnityEngine;

public class Save : MonoBehaviour
{
public Transform respawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ЗАГРУЗКА СЕйВА В Movement
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetFloat("SaveX", respawnPoint.position.x);
            PlayerPrefs.SetFloat("SaveY", respawnPoint.position.y);
            PlayerPrefs.SetFloat("SaveZ", respawnPoint.position.z);
            PlayerPrefs.Save();
        
            Debug.Log("Сохранено в точке: " + respawnPoint.position);
        }
    }
}
