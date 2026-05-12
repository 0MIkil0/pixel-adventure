using TMPro;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level2
{
    public class Level2UI : MonoBehaviour
    {
        private TMP_Text _tmpText;

        public void UpdateText(string message, Color color, int fontSize)
        {
            _tmpText.text = message;
            _tmpText.color = color;
            _tmpText.fontSize = fontSize;
        }
    }
}
