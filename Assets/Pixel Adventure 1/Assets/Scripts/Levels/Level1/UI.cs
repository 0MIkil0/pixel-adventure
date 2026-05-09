using TMPro;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level1
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TMP_Text tmpText;

        void Awake()
        {
            //базовые настройки текст
            tmpText.fontMaterial.EnableKeyword("OUTLINE_ON");
            tmpText.outlineWidth = 0.1f;
            tmpText.fontSize = 18;
            tmpText.outlineColor = Color.black;   
        }
        public void UpdateText(string message, Color color, int fontSize)
        {
            tmpText.text = message;
            tmpText.color = color;
            tmpText.fontSize = fontSize;
        }
    }
}
