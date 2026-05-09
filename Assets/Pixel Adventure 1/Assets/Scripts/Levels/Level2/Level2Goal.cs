using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level2
{
    public class Level2Goal : MonoBehaviour
    {
        private UISecondLevel _ui;
        private Level2Transition _level2Transition;
        [SerializeField] private Level1Goal level1Goal;
        [SerializeField] private AppleHeal[] apples;

        //2
        private int _secondLevelTarget = 5;
        private int _collectedAppleCount;
        private int _ifFirstLevelCompleted;

        //меняем при триггере на сохранении второго уровня
        public int isOnSecondLevel;

        void Start()
        {
            _level2Transition = GetComponent<Level2Transition>();
            _ui = GetComponent<UISecondLevel>();

            int isSecondFloorPref = PlayerPrefs.GetInt(SaveKeys.IsSecondLevel);
            isOnSecondLevel = isSecondFloorPref;

            foreach (var appleHeal in apples)
            {
                appleHeal.OnCollected += AddScore;
            }
        }

        void Update()
        {
            if (_ifFirstLevelCompleted == 1 && isOnSecondLevel == 1)
            {
                level1Goal.enabled = false;
                string message = $"Теперь съешь {_secondLevelTarget - _collectedAppleCount} яблок";
                _ui.UpdateText(message, Color.cornflowerBlue, 18);
            }
            if (_collectedAppleCount == _secondLevelTarget)
            {
                _level2Transition.StartTimerCorutine();
            }
        }
        public void ChangeSecondLevel()
        {
            isOnSecondLevel = 1;
            _ifFirstLevelCompleted = PlayerPrefs.GetInt(SaveKeys.FirstLevelCompleted);
            PlayerPrefs.SetInt(SaveKeys.IsSecondLevel, 1);
        }
        void AddScore()
        {
            _collectedAppleCount++;

            if (_collectedAppleCount == _secondLevelTarget)
            {
                foreach (var appleHeal in apples)
                {
                    appleHeal.OnCollected -= AddScore;
                }
            }
        }
    }
}
