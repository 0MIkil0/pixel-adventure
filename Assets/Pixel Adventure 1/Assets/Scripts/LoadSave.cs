using UnityEngine;

public class LoadSave : MonoBehaviour
{
    void Start()
    {
        //СОХРАНЕНИЕ
        if (PlayerPrefs.HasKey("SaveX"))
        {
            float x = PlayerPrefs.GetFloat("SaveX");
            float y = PlayerPrefs.GetFloat("SaveY");
            float z = PlayerPrefs.GetFloat("SaveZ");
                
            transform.position = new Vector3(x, y, z);
        }

        if (PlayerPrefs.HasKey("playerScore"))
        {
            int playerScoreLoad = PlayerPrefs.GetInt("playerScore");
            FindFirstObjectByType<Score>().playerScore = playerScoreLoad;
            Debug.Log("Player Score: " + playerScoreLoad);
        }
    }

}
