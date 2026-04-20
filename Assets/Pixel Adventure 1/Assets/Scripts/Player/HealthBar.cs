using UnityEngine;
using UnityEngine.UI;
namespace Pixel_Adventure_1.Assets.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        public Image healthBarImage;
        public void UpdateHealthOnBar(float currentHealth)
        {
            healthBarImage.fillAmount = currentHealth;
        }
    }
}