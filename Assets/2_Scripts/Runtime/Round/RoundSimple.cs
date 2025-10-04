using System;
using System.Collections.Generic;
using UnityEngine;

public class RoundSimple : RoundBase, ITimerCallback
{
    [Header("[ References ]")]
    [SerializeField] private QuoteBase _quote;
    
    public override void BeginRound(int index)
    {
        base.BeginRound(index);

        _roundEventList.Clear();

        RoundSo so = _soList[_currentRoundIdx];
        float targetSec = so.TargetSec;
        
        foreach (RoundEvent roundEvent in so.RoundEvents)
        {
            if (roundEvent is RoundEventRepeat rer)
            {
                _roundEventList.AddRange(rer.ToEventList());
            }
            else
            {
                _roundEventList.Add(roundEvent);
            }
        }
        
        _timer.Clear();
        _timer.Begin(targetSec);
        
        _quote.ReQuote();
    }

    public override void OnTimerProgress(float currentSec, float targetSec)
    {
        List<RoundEvent> removeList = new List<RoundEvent>();
        
        foreach (RoundEvent roundEvent in _roundEventList)
        {
            float delta = targetSec - currentSec;
            
            if (delta < roundEvent.executeSec)
                continue;

            removeList.Add(roundEvent);
            
            _actionQueue.Enqueue(() => roundEvent.Execute());
        }
        
        foreach (RoundEvent roundEvent in removeList)
        {
            _roundEventList.Remove(roundEvent);
        }
    }

    public override void OnTimerComplete(float currentSec, float targetSec)
    {
        _actionQueue.Enqueue(() =>
        {
            if (_currentRoundIdx < _targetRoundIdx)
                BeginRound(_currentRoundIdx + 1);
            else
                OnAllEndRound();
        });
    }
    
    protected override void OnAllEndRound()
    {
        Debug.Log("All End");
    }
}
