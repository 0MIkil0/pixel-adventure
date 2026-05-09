using System;
using UnityEngine;

public class EventOfLevel
{
    public static event Action OnFirstLevelCompleted;
    
    public static void InvokeFirstLevelCompleted()
    {
        OnFirstLevelCompleted?.Invoke();
    }
}
