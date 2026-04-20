using System;
using System.Threading.Tasks;

namespace Pixel_Adventure_1.Assets.Scripts.Lesson
{
    public class TaskTest
    {
        private void Start()
        {
            TaskAsync();
        }
        
        private async Task TaskAsync()
        {
            // Do 1

            await Task.Delay(TimeSpan.FromSeconds(1f));

            // Do 2
        }
    }
}