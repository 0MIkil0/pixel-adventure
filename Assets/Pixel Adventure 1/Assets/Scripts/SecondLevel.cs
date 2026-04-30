using UnityEngine;
using TMPro;

namespace Pixel_Adventure_1.Assets.Scripts
{
    public class SecondLevel : MonoBehaviour
    {
        private TMP_Text _text;

        //2
        private int _secondLevelTarget = 5;
        private int _secondCurrentScore;
        private int _fstTarget;

        //меняем при триггере на сохранении второго уровня
        public int isSecondFloor;

        void Start()
        {
            int? fstTargetPref = PlayerPrefs.GetInt("FST_TARGET");
            _fstTarget = fstTargetPref.Value;
            Debug.Log("_fstTarget == "+_fstTarget);
            
            int? isSecondFloorPref = PlayerPrefs.GetInt("IS_SECOND");
            isSecondFloor = isSecondFloorPref.Value;
            Debug.Log("_secondLevelTarget = " + isSecondFloor);
            
            
            _text = GetComponent<TMP_Text>();
        }

        void Update()
        {
            if (_fstTarget == 1 && isSecondFloor == 1)
            {
                _text.text = $"Теперь съешь {_secondLevelTarget - _secondCurrentScore} яблок";
                _text.color = Color.cornflowerBlue;
                
            }
        }

        public void ChangeSecondLevel()
        {
            isSecondFloor = 1;
            PlayerPrefs.SetInt("IS_SECOND", 1);
        }

        public void GetFstTarget()
        {
            _fstTarget = GetComponent<LevelTarget1>().firstTarget;
            PlayerPrefs.SetInt("FST_TARGET", _fstTarget);
        }
    }
}
