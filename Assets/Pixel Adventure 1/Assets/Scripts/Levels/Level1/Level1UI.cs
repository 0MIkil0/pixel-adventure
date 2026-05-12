using TMPro;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level1
{
    public class Level1UI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;

        void Awake()
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
