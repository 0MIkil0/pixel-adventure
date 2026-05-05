using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

namespace Pixel_Adventure_1.Assets.Scripts
{
    public class LevelTarget1 : MonoBehaviour
    {
        private TMP_Text _text;
        
        private int _firstLevelTarget = 3;
        private int _firstCurrentScore;
        public int firstTarget;
        
        public GameObject leftCollision;
        public GameObject rightCollision;
        private BoxCollider2D _rightCollider;
        private BoxCollider2D _leftCollider;
        
        void Start()
        {
            _rightCollider = rightCollision.GetComponent<BoxCollider2D>();
            _leftCollider = leftCollision.GetComponent<BoxCollider2D>();
            _text = GetComponent<TMP_Text>();
            _firstCurrentScore = PlayerPrefs.GetInt("FST_CURRENT_SCORE");
            Invoke(nameof(ColliderTrue), 0.2f);
          
        }
        void Update()
        {
            
            if (_firstCurrentScore < _firstLevelTarget)
            {
                _text.text = $"Осталось победить {_firstLevelTarget - _firstCurrentScore} врага для открытия следующего уровня.";
                _text.color = Color.cornflowerBlue;

            }
            else if (_firstCurrentScore == _firstLevelTarget && firstTarget == 0)
            {
                _text.text = $"вы выполнили цель, проход на второй уровень открыт!";
                _text.color = Color.limeGreen;
                _text.fontSize = 16;
                
                _rightCollider.enabled = false;
                _leftCollider.enabled = false;
                
                firstTarget = 1;
                
                PlayerPrefs.SetInt("FST_CURRENT_SCORE", _firstCurrentScore);
                GetComponent<SecondLevel>().SaveFirstTarget();
            }
        }

        void ColliderTrue()
        {
            _rightCollider.enabled = true;
            _leftCollider.enabled = true;
        }
        
        public void AddScore()
        {
            _firstCurrentScore++;
        }
    }

}