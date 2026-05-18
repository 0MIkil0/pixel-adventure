using Pixel_Adventure_1.Assets.Scripts.Levels.Level1;
using Pixel_Adventure_1.Assets.Scripts.Levels.Levels;
using Pixel_Adventure_1.Assets.Scripts.Saves;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level2
{
    public class Level2Goal : MonoBehaviour
    {
        //меняем при триггере на сохранении второго уровня
        public int IsOnSecondLevel;
        
        [SerializeField] private AppleHeal[] _apples;
        [SerializeField]  private Level1Goal _level1Goal;
        [SerializeField] private Level2Transition _level2Transition;
         
        private LevelsUI _levelsUI;
        private const int SecondLevelTarget = 5;
        private int _collectedAppleCount;
        private int _isFirstLevelCompleted;

        private void Start()
        {
            _levelsUI = GetComponent<LevelsUI>();

            int isSecondFloorPref = PlayerPrefs.GetInt(CheckpointSaveKeys.IsSecondLevel);
            IsOnSecondLevel = isSecondFloorPref;

            foreach (var appleHeal in _apples)
            {
                appleHeal.OnCollected += AddScore;
            }
        }

        private void Update()
        {
            if (_isFirstLevelCompleted == 1 && IsOnSecondLevel == 1)
            {
                _level1Goal.enabled = false;
                string message = $"Теперь съешь {SecondLevelTarget - _collectedAppleCount} яблок";
                _levelsUI.UpdateText(message, Color.cornflowerBlue, 18);
            }
            if (_collectedAppleCount == SecondLevelTarget)
            {
                _level2Transition.StartTimerCoroutine();
            }
        }

        public void ChangeSecondLevel()
        {
            IsOnSecondLevel = 1;
            _isFirstLevelCompleted = PlayerPrefs.GetInt(CheckpointSaveKeys.FirstLevelCompleted);
            PlayerPrefs.SetInt(CheckpointSaveKeys.IsSecondLevel, 1);
        }

        private void AddScore()
        {
            _collectedAppleCount++;

            if (_collectedAppleCount == SecondLevelTarget)
            {
                foreach (var appleHeal in _apples)
                {
                    appleHeal.OnCollected -= AddScore;
                }
            }
        }
    }
}
