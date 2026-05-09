using System;
using System.Collections;
using Pixel_Adventure_1.Assets.Scripts.Levels.Level2;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level2
{
    public class Level2Transition : MonoBehaviour
    {
        private int _timer = 10;
        private UISecondLevel _ui;
        private void Start()
        {
            _ui = GetComponent<UISecondLevel>();

        }

        public void StartTimerCorutine()
        {
            StartCoroutine(nameof(TimerCorutine));
        }
       IEnumerator TimerCorutine()
        {
            GetComponent<Level2Goal>().enabled = false;
            while (_timer > 0)
            {
                _timer = _timer - 1;
                string message = $"Вас телепортирует через: {_timer}";
                _ui.UpdateText(message, Color.azure, 18);

                if (_timer == 0)
                {
                    PlayerPrefs.SetFloat(SaveKeys.SaveX, 4.01f);
                    PlayerPrefs.SetFloat(SaveKeys.SaveY, 0.679f);
                    PlayerPrefs.SetFloat(SaveKeys.SaveZ, 0f);
                    SceneManager.LoadScene("Level2");
                }

                yield return new WaitForSeconds(1f);
            }
        }
    }
}