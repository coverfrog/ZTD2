using System.Collections;
using UnityEngine;

public class TimerInfinite : TimerBase
{
    private WaitForSeconds wfs = new WaitForSeconds(0.1f);
    
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

    protected override void BeginMethod()
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

        Callback(x => x.OnTimerBegin(_currentSec, _targetSec));
        
        while (_currentSec > 0)
        {
            Callback(x => x.OnTimerProgress(_currentSec, _targetSec));
            
            _currentSec -= 0.1f;

            yield return wfs;
        }

        _currentSec = 0;
        
        Callback(x => x.OnTimerComplete(_currentSec, _targetSec));

        _coTimer = null;
        
        BeginMethod();
    }
}