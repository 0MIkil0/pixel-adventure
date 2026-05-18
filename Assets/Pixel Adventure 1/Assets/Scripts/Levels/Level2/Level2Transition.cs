using System.Collections;
using Pixel_Adventure_1.Assets.Scripts.Levels.Levels;
using Pixel_Adventure_1.Assets.Scripts.Saves;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level2
{
    public class Level2Transition : MonoBehaviour
    {
        private int _timer = 10;
        private LevelsUI _levelsUI;
        private void Start()
        {
            _levelsUI = GetComponent<LevelsUI>();
        }

        public void StartTimerCoroutine()
        {
            StartCoroutine(nameof(TimerCoroutine));
        }

        private IEnumerator TimerCoroutine()
        {
            GetComponent<Level2Goal>().enabled = false;
            while (_timer > 0)
            {
                _timer = _timer - 1;
                string message = $"Вас телепортирует через: {_timer}";
                _levelsUI.UpdateText(message, Color.azure, 18);

                if (_timer == 0)
                {
                    PlayerPrefs.SetFloat(CheckpointSaveKeys.SaveX, 4.01f);
                    PlayerPrefs.SetFloat(CheckpointSaveKeys.SaveY, 0.679f);
                    PlayerPrefs.SetFloat(CheckpointSaveKeys.SaveZ, 0f);
                    SceneManager.LoadScene("Level2");
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}