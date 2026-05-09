using Pixel_Adventure_1.Assets.Scripts.Levels.Level1;
using UnityEngine;
namespace Pixel_Adventure_1.Assets.Scripts
{
    public class Level1Goal : MonoBehaviour
    {
        private ScoreCounter _scoreCounter;
        private UI _ui;
        private string _messageForUi;
        private int _firstLevelCurrentKill;
        private readonly int _firstLevelTarget = 3;
        public int isFirstLevelCompleted;
        void Start()
        {
            _ui = GetComponent<UI>();
            _scoreCounter = GetComponent<ScoreCounter>();
            _firstLevelCurrentKill = PlayerPrefs.GetInt(SaveKeys.FirstLevelCurrentKill);
        }
        void Update()
        {
            //не идем дальше по if, если прошли второй уровень
            if (PlayerPrefs.GetInt(SaveKeys.IsSecondLevel) == 1)
            {
                return;
            }
            //если не ретурн значит записываем значение
            _firstLevelCurrentKill = _scoreCounter.firstCurrentKill;
            if (_firstLevelCurrentKill < _firstLevelTarget)
            {
                _messageForUi = $"Осталось победить {_firstLevelTarget - _firstLevelCurrentKill} врага для открытия следующего уровня.";
                _ui.UpdateText(_messageForUi, Color.cornflowerBlue, 18);
            }
            else if (_firstLevelCurrentKill == _firstLevelTarget && isFirstLevelCompleted == 0)
            {
                _messageForUi = $"вы выполнили цель, проход на второй уровень открыт!";
                _ui.UpdateText(_messageForUi, Color.limeGreen, 16);
                isFirstLevelCompleted = 1;
                EventOfLevel.InvokeFirstLevelCompleted();
                PlayerPrefs.SetInt(SaveKeys.FirstLevelCompleted, isFirstLevelCompleted);
                PlayerPrefs.SetInt(SaveKeys.FirstLevelCurrentKill, _firstLevelCurrentKill);
            }
        }
    }
}