using TMPro;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Levels
{
    public class LevelsUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;
        
        private void Awake()
        {
            //базовые настройки текст
            _tmpText.fontMaterial.EnableKeyword("OUTLINE_ON");
            _tmpText.outlineWidth = 0.1f;
            _tmpText.fontSize = 18;
            _tmpText.outlineColor = Color.black;
        }
        public void UpdateText(string message, Color color, int fontSize)
        {
            _tmpText.text = message;
            _tmpText.color = color;
            _tmpText.fontSize = fontSize;
        }
    }
}
