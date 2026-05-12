using System;

namespace Pixel_Adventure_1.Assets.Scripts.Levels.Level1
{
    public abstract class Level1Event
    {
        public static event Action OnFirstLevelCompleted;
    
        public static void InvokeFirstLevelCompleted()
        {
            OnFirstLevelCompleted?.Invoke();
        }
    }
}
