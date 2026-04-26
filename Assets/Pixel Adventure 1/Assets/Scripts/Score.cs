using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
   public int playerScore;
   private TMP_Text _scoreText;
    
   void Start()
   {
      _scoreText = GetComponent<TMP_Text>();
   }
   void Update()
   {
      _scoreText.text = $"Очки: {playerScore}";
   }
   public void AddScore()
   {
      playerScore++;
      Debug.Log(playerScore);
   }
}
