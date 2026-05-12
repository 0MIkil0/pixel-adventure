using Pixel_Adventure_1.Assets.Scripts.Saves;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level1
{
    public class Level1Goal : MonoBehaviour
    {
        public int IsFirstLevelCompleted;
        private Level1ScoreCounter _level1ScoreCounter;
        private Level1UI _level1UI;
        private string _messageForUi;
        private int _firstLevelCurrentKill;
        private readonly int _firstLevelTarget = 3;

        void Start()
        {
            _level1UI = GetComponent<Level1UI>();
            _level1ScoreCounter = GetComponent<Level1ScoreCounter>();
            _firstLevelCurrentKill = PlayerPrefs.GetInt(CheckpointSaveKeys.FirstLevelCurrentKill);
        }

        void Update()
        {
            //не идем дальше по if, если прошли второй уровень
            if (PlayerPrefs.GetInt(CheckpointSaveKeys.IsSecondLevel) == 1)
            {
                return;
            }

            //если не ретурн значит записываем значение
            _firstLevelCurrentKill = _level1ScoreCounter.FirstCurrentKill;
            if (_firstLevelCurrentKill < _firstLevelTarget)
            {
                _messageForUi =
                    $"Осталось победить {_firstLevelTarget - _firstLevelCurrentKill} врага для открытия следующего уровня.";
                _level1UI.UpdateText(_messageForUi, Color.cornflowerBlue, 18);
            }
            else if (_firstLevelCurrentKill == _firstLevelTarget && IsFirstLevelCompleted == 0)
            {
                _messageForUi = $"вы выполнили цель, проход на второй уровень открыт!";
                _level1UI.UpdateText(_messageForUi, Color.limeGreen, 16);
                IsFirstLevelCompleted = 1;
                Level1Event.InvokeFirstLevelCompleted();
                PlayerPrefs.SetInt(CheckpointSaveKeys.FirstLevelCompleted, IsFirstLevelCompleted);
                PlayerPrefs.SetInt(CheckpointSaveKeys.FirstLevelCurrentKill, _firstLevelCurrentKill);
            }
        }
    }
}