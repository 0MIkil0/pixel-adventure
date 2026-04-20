using System.Collections;
using UnityEngine;

namespace Pixel_Adventure_1.Assets.Scripts.Lesson
{
    public class CoroutineTest : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(Coroutine());
        }
        
        private IEnumerator Coroutine()
        {
            // Do 1

            yield return null;
            
            // Do 2
            
            yield return new WaitForSeconds(2f);
            
            Destroy(gameObject);
        }
        
        
        // во что раскладывается корутина
        private bool isRunning = false;
        private float timer = 0f;
        private int step = 0;

        // void Start()
        // {
        //     step = 1;
        //     isRunning = true;
        // }

        void Update()
        {
            if (!isRunning) return;
    
            switch (step)
            {
                case 1:
                    // Do 1
                    step = 2;
                    // Ждём 1 кадр — просто выходим
                    break;
            
                case 2:
                    // Do 2
                    step = 3;
                    timer = 0f;
                    break;
            
                case 3:
                    timer += Time.deltaTime;
                    if (timer >= 2f)
                    {
                        Destroy(gameObject);
                        isRunning = false;
                    }
                    break;
            }
        }
    }
}