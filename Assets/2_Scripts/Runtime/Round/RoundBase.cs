using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class RoundBase : MonoBehaviour, ITimerCallback
{
    [Header("[ Options ]")] 
    [SerializeField] protected List<RoundSo> _soList = new List<RoundSo>();

    [Header("[ References ]")]
    [SerializeField] protected TimerBase _timer;

    #region Get

    public TimerBase Timer => _timer;

    #endregion
    
    [Header("[ Values ]")] 
    [SerializeField] protected int _currentRoundIdx = -1;
    [SerializeField] protected int _targetRoundIdx = 10;
    [Space]
    [SerializeReference, SubclassSelector] protected List<RoundEvent> _roundEventList = new List<RoundEvent>();

    protected readonly Queue<Action> _actionQueue = new Queue<Action>();

    #region Get

    public int CurrentRoundIdx => _currentRoundIdx;
    
    public int TargetRoundIdx => _targetRoundIdx;
    
    #endregion

    public virtual void BeginRound(int index)
    {
        List<RoundSo> temp = _soList.Where(so => so).ToList();

        _soList = temp;
        
        _currentRoundIdx = index;
        _targetRoundIdx = _soList.Count - 1;
    }
    
    private void OnEnable()
    {
        _timer?.AddCallback(this);
    }

    private void OnDisable()
    {
        _timer?.RemoveCallback(this);
    }
    
    private void Update()
    {
        if (_actionQueue.Count == 0)
            return;
        
        if (!_actionQueue.TryDequeue(out Action action))
            return;
        
        action?.Invoke();
    }

    public abstract void OnTimerProgress(float currentSec, float targetSec);

    public abstract void OnTimerComplete(float currentSec, float targetSec);

    protected abstract void OnAllEndRound();
}
