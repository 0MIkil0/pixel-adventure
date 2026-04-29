using UnityEngine;
using TMPro;
namespace Pixel_Adventure_1.Assets.Scripts
{
    public class LevelTarget1 : MonoBehaviour
    {
        private TMP_Text _text;
        
        //1
        private int _firstLevelTarget = 3;
        private int _firstCurrentScore;
        private int _firstTarget;
      
        
        //2
        private int _secondLevelTarget = 5;
        private int _secondCurrentScore;
        //меняем при триггере на сохранении творого уровня
        public bool isSecondFloor;
        
       
        public GameObject leftCollision;
        public GameObject rightCollision;
        private BoxCollider2D _rightCollider;
        private BoxCollider2D _leftCollider;
        
        void Start()
        {
            _rightCollider = rightCollision.GetComponent<BoxCollider2D>();
            _leftCollider = leftCollision.GetComponent<BoxCollider2D>();
            
            _text = GetComponent<TMP_Text>();
            
            _text.fontMaterial.EnableKeyword("OUTLINE_ON");
            _text.outlineWidth = 0.1f;
            _text.outlineColor = Color.black;
        }
        void Awake()
        {
            //загружаем 1 чтобы при смерте на втором уровне наша цель не откатывалась
            // _firstTarget = PlayerPrefs.GetInt("fstTarget");
        }
        void Update()
        {
            if (_firstCurrentScore < _firstLevelTarget)
            {
                _text.text = $"Осталось победить {_firstLevelTarget - _firstCurrentScore} врага для открытия следующего уровня.";
                _text.fontSize = 18;
                _text.color = Color.cornflowerBlue;
               
            }
            else if (_firstCurrentScore == _firstLevelTarget && _firstTarget == 0)
            {
                _text.text = $"вы выполнили цель, проход на второй уровень открыт!";
                _text.color = Color.limeGreen;
                _text.fontSize = 16;
                
                _rightCollider.enabled = false;
                _leftCollider.enabled = false;
                
                _firstTarget = 1;
                // PlayerPrefs.SetInt("fstTarget", _firstTarget);
              
            }
            else if (_firstTarget == 1 && isSecondFloor)
            {
                _text.text = $"Теперь съешь {_secondLevelTarget - _secondCurrentScore} яблок";
                _text.fontSize = 18;
                _text.color = Color.cornflowerBlue;
            }
        }
        public void AddScore()
        {
            _firstCurrentScore++;
        }
    }

}