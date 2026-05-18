using UnityEngine;
using UnityEngine.UI;

namespace Pixel_Adventure_1.Assets.Scripts.Player
{
    public class PlayerHealthBar : MonoBehaviour
    {
        public Image HealthBarImage;

        public void UpdateHealthOnBar(float currentHealth)
        {
            HealthBarImage.fillAmount = currentHealth;
        }
    }
}
