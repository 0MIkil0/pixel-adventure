using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Pixel_Adventure_1.Assets.Scripts
{
    public class SecondLevel : MonoBehaviour
    {
        [SerializeField] private AppleHeal[] _apples;
        private int _timer = 10;
        private TMP_Text _text;

        //2
        private int _secondLevelTarget = 5;
        private int _secondCurrentScore;
        private int _fstTarget;
        
        //меняем при триггере на сохранении второго уровня
        public int isSecondFloor;

        void Start()
        {
            int fstTargetPref = PlayerPrefs.GetInt("FST_TARGET");
            _fstTarget = fstTargetPref;
            Debug.Log("_fstTarget == "+_fstTarget);
            
            int isSecondFloorPref = PlayerPrefs.GetInt("IS_SECOND");
            isSecondFloor = isSecondFloorPref;
            Debug.Log("_secondLevelTarget = " + isSecondFloor);
            
            _text = GetComponent<TMP_Text>();
            
           foreach (var appleHeal in _apples)
           {
               appleHeal.OnCollected += AddScore;
           }
        }

        void Update()
        {
            if (_fstTarget == 1 && isSecondFloor == 1)
            {
                _text.text = $"Теперь съешь {_secondLevelTarget - _secondCurrentScore} яблок";
                _text.color = Color.cornflowerBlue;
                
                if (_secondCurrentScore == _secondLevelTarget)
                {
                    StartCoroutine(nameof(TimerCorrutine));
                }
            }
        }

        IEnumerator TimerCorrutine()
        {
            GetComponent<SecondLevel>().enabled = false;
            while (_timer > 0)
            {
                _timer = _timer - 1; 
                _text.text = $"Вас телепортирует через: {_timer}";
                if (_timer == 0)
                {
                        Debug.Log("second level timed out");
                }
                yield return new WaitForSeconds(1f);
            }
        }
        public void ChangeSecondLevel()
        {
            isSecondFloor = 1;
            PlayerPrefs.SetInt("IS_SECOND", 1);
        }

        public void SaveFirstTarget()
        {
            _fstTarget = GetComponent<LevelTarget1>().firstTarget;
            PlayerPrefs.SetInt("FST_TARGET", _fstTarget);
        }

        public void AddScore()
        {
            _secondCurrentScore++;

            if (_secondCurrentScore == _secondLevelTarget)
            {
                foreach (var appleHeal in _apples)
                {
                    appleHeal.OnCollected -= AddScore;
                }
            }
        }
    }
}
