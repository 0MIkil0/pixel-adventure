using Pixel_Adventure_1.Assets.Scripts;
using Pixel_Adventure_1.Assets.Scripts.Saves;
using UnityEngine;

public class CheckpointLoader : MonoBehaviour
{
    private void Start()
    {
        //СОХРАНЕНИЕ
        if (PlayerPrefs.HasKey(CheckpointSaveKeys.SaveX))
        {
            float x = PlayerPrefs.GetFloat(CheckpointSaveKeys.SaveX);
            float y = PlayerPrefs.GetFloat(CheckpointSaveKeys.SaveY);
            float z = PlayerPrefs.GetFloat(CheckpointSaveKeys.SaveZ);
                
            transform.position = new Vector3(x, y, z);
        }

        if (PlayerPrefs.HasKey("playerScore"))
        {
            var playerScoreLoad = PlayerPrefs.GetInt("playerScore");
            FindFirstObjectByType<ScoreManager>().PlayerScore = playerScoreLoad;
        }
    }

}
