using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   public int playerScore;
   [SerializeField] private TMP_Text scoreText;
   
   void Update()
   {
      if (scoreText != null)
      {
         scoreText.text = $"Очки: {playerScore}";
      }
   }
   public void AddScore()
   {
      playerScore++;
      Debug.Log(playerScore);
   }
   private void OnTriggerEnter2D(Collider2D collision)
   {
      PlayerPrefs.SetInt(SaveKeys.PlayerScore, playerScore);
   }
}
