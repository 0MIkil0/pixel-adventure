using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts
{
    public class ScoreCounter : MonoBehaviour
    {
        public int firstCurrentKill;
        public void AddScore()
        {
            firstCurrentKill++;
        }
    }
}