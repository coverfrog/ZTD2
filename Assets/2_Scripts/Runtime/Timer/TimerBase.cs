using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimerBase : MonoBehaviour
{
    [Header("[ Values ]")]
    [SerializeField, Min(0)] protected float _targetSec;
    [SerializeField, Min(0)] protected float _currentSec;

    private List<ITimerCallback> _timerCallbackList = new();

    public void AddCallback(ITimerCallback timerCallback) => 
        _timerCallbackList.Add(timerCallback);
    
    public void RemoveCallback(ITimerCallback timerCallback) => 
        _timerCallbackList.Remove(timerCallback);

    protected void Callback(Action<ITimerCallback> callback)
    {
        foreach (ITimerCallback timerCallback in _timerCallbackList)
        {
            callback?.Invoke(timerCallback);
        }
    }
    
    public void Begin(float targetSec)
    {
        _targetSec = targetSec;
        
        Begin();
    }

    public abstract void Stop();
    
    protected abstract void Begin();
    
    public abstract void Clear();

}
