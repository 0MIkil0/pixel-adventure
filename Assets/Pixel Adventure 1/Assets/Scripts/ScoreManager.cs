using Pixel_Adventure_1.Assets.Scripts.Saves;
using TMPro;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts
{
   public class ScoreManager : MonoBehaviour
   {
      public int PlayerScore;
      private TMP_Text _scoreText;

      void Update()
      {
         if (_scoreText != null)
         {
            _scoreText.text = $"Очки: {PlayerScore}";
         }
      }

      private void OnTriggerEnter2D(Collider2D collision)
      {
         PlayerPrefs.SetInt(CheckpointSaveKeys.PlayerScore, PlayerScore);
      }

      public void AddScore()
      {
         PlayerScore++;
         Debug.Log(PlayerScore);
      }

   }
}
