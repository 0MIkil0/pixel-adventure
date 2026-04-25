using UnityEngine;

public class Score : MonoBehaviour
{
   public int playerScore;

   public void AddScore()
   {
      playerScore++;
      Debug.Log(playerScore);
   }
}
