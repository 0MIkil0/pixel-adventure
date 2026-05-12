using UnityEngine;
namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level1
{
    public class Level1ScoreCounter : MonoBehaviour
    {
        public int FirstCurrentKill;

        public void AddScore()
        {
            FirstCurrentKill++;
        }
    }
}