using UnityEngine;
using TMPro;

public class TextEditor : MonoBehaviour
{
    private TMP_Text _text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.fontMaterial.EnableKeyword("OUTLINE_ON");
        _text.outlineWidth = 0.1f;
        _text.fontSize = 18;
        _text.outlineColor = Color.black;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
