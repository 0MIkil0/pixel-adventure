using UnityEngine;

public class CheckpointLoader : MonoBehaviour
{
    void Start()
    {
        //СОХРАНЕНИЕ
        if (PlayerPrefs.HasKey(SaveKeys.SaveX))
        {
            float x = PlayerPrefs.GetFloat(SaveKeys.SaveX);
            float y = PlayerPrefs.GetFloat(SaveKeys.SaveY);
            float z = PlayerPrefs.GetFloat(SaveKeys.SaveZ);
                
            transform.position = new Vector3(x, y, z);
        }

        if (PlayerPrefs.HasKey("playerScore"))
        {
            int playerScoreLoad = PlayerPrefs.GetInt("playerScore");
            FindFirstObjectByType<ScoreManager>().playerScore = playerScoreLoad;
        }
    }

}
