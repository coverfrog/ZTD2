using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimerSimple : TimerBase
{
    private IEnumerator _coTimer;

    private void OnDisable()
    {
        Stop();
    }

    public override void Clear()
    {
        Stop();
    }

    public override void Stop()
    {
        if (_coTimer == null) 
            return;
        
        StopCoroutine(_coTimer);
        _coTimer = null;
    }

    protected override void Begin()
    {
        Stop();

        if (_targetSec <= 0)
        {
            _currentSec = 0;
            _targetSec = 0;
                
            Callback(x => x.OnTimerComplete(_currentSec, _targetSec));
            
            return;
        }
        
        _coTimer = CoTimer();
        StartCoroutine(_coTimer);
    }

    private IEnumerator CoTimer()
    {
        _currentSec = _targetSec;

        while (_currentSec > 0)
        {
            Callback(x => x.OnTimerProgress(_currentSec, _targetSec));
            
            _currentSec -= 0.1f;
            
            yield return new WaitForSeconds(0.1f);
        }

        _currentSec = 0;
        
        Callback(x => x.OnTimerComplete(_currentSec, _targetSec));

        _coTimer = null;
    }
}
