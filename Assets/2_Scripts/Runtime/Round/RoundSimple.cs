using System;
using System.Collections.Generic;
using UnityEngine;

public class RoundSimple : RoundBase, ITimerCallback
{
    [Header("[ Options ]")] 
    [SerializeField] private double _targetSec = 15;
    [SerializeField] private List<RoundSo> _soList = new List<RoundSo>();
    
    [Header("[ References ]")]
    [SerializeField] private TimerBase _timer;

    [Header("[ Values ]")] 
    [SerializeField] private int _currentRoundIdx = -1;
    [SerializeField] private int _targetRoundIdx = 10;
    [Space]
    [SerializeReference, SubclassSelector] private List<RoundEvent> _roundEventList = new List<RoundEvent>();

    private readonly Queue<Action> _actionQueue = new Queue<Action>();

    private void OnEnable()
    {
        _timer.AddCallback(this);
    }

    private void OnDisable()
    {
        _timer.RemoveCallback(this);
    }

    private void Update()
    {
        if (_actionQueue.Count == 0)
            return;
        
        if (!_actionQueue.TryDequeue(out Action action))
            return;
        
        action?.Invoke();
    }

    public override void BeginRound(int index)
    {
        _currentRoundIdx = index;
        _targetRoundIdx = _soList.Count - 1;

        _roundEventList.Clear();
        foreach (RoundEvent roundEvent in _soList[_currentRoundIdx].RoundEvents)
        {
            if (roundEvent is RoundEventRepeat rer)
            {
                for (int i = 0; i < rer.executeCount; i++)
                {
                    float sec = rer.executeSec - i * rer.executeInterval;

                    if (sec < 0)
                        continue;

                    if (rer.Clone() is not RoundEventRepeat ins) 
                        continue;
                    
                    ins.executeSec = sec;
                    ins.executeCount = 1;

                    _roundEventList.Add(ins);
                }
            }
            else
            {
                _roundEventList.Add(roundEvent);
            }
        }
        
        _timer.Clear();
        _timer.Begin(_targetSec);
    }

    public void OnTimerProgress(double currentSec, double targetSec)
    {
        // Debug.Log($"currentSec: {currentSec}, targetSec: {targetSec}");
        
        List<RoundEvent> removeList = new List<RoundEvent>();
        
        foreach (RoundEvent roundEvent in _roundEventList)
        {
            if (currentSec > roundEvent.executeSec)
                continue;

            removeList.Add(roundEvent);
            
            Action action = roundEvent switch
            {
                RoundEventSpawn eSpawn => () => OnSpawn(eSpawn, currentSec),
                _ => null
            };
            
            if (action == null)
                continue;
            
            _actionQueue.Enqueue(action);
        }
        
        foreach (RoundEvent roundEvent in removeList)
        {
            _roundEventList.Remove(roundEvent);
        }
    }

    public void OnTimerComplete(double currentSec, double targetSec)
    {
        _actionQueue.Enqueue(() =>
        {
            if (_currentRoundIdx < _targetRoundIdx)
                BeginRound(_currentRoundIdx + 1);
            else
                OnAllEndRound();
        });
    }

    private void OnSpawn(RoundEventSpawn e, double currentSec)
    {
        string objName = $"Unit < {_currentRoundIdx} > <{e.spawnCodeName} > < {currentSec:.0} >";

        new GameObject(objName);
    }
    
    private void OnAllEndRound()
    {
        Debug.Log("All End");
    }
}
