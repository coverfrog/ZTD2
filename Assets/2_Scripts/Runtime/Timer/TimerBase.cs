using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimerBase : MonoBehaviour
{
    public delegate void TimeDelegate(double currentSec, double targetSec);

    [Header("[ Values ]")]
    [SerializeField, Min(0)] protected double _targetSec;
    [SerializeField, Min(0)] protected double _currentSec;

    private List<ITimerCallback> _timerCallbackList = new();

    public void AddCallback(ITimerCallback timerCallback) => _timerCallbackList.Add(timerCallback);
    
    public void RemoveCallback(ITimerCallback timerCallback) => _timerCallbackList.Remove(timerCallback);

    protected void Callback(Action<ITimerCallback> callback)
    {
        foreach (ITimerCallback timerCallback in _timerCallbackList)
        {
            callback?.Invoke(timerCallback);
        }
    }
    
    public void Begin(double targetSec)
    {
        _targetSec = targetSec;
        
        Begin();
    }

    public abstract void Stop();
    
    protected abstract void Begin();
    
    public abstract void Clear();

}
