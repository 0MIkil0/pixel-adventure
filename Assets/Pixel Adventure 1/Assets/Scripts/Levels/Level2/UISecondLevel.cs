using TMPro;
using UnityEngine;

public class UISecondLevel : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;
   public void UpdateText(string message, Color color, int fontSize)
    {
        tmpText.text = message;
        tmpText.color = color;
        tmpText.fontSize = fontSize;
    }
   
}
