using System;
using UnityEngine;

[Serializable]
public class StatReduce
{
    [SerializeField] private StatSo _so;
    [SerializeField] private bool _isReduce = true;
    [SerializeField] private float _reduceInterval;
    [SerializeField] private float _reduceValue;
    
    public StatSo So => _so;
    
    public bool IsReduce => _isReduce;
    
    public float ReduceValue => _reduceValue;
    
    public float ReduceInterval => _reduceInterval;

    private float _reduceStopwatch;

    public void SetIsReduce(bool value)
    {
        _reduceStopwatch = 0;
        _isReduce = value;
    }
    
    public void Update(Stats stats)
    {
        if (!_isReduce)
            return;

        if (_reduceStopwatch >= _reduceInterval)
        {
            Reduce(stats);
            
            _reduceStopwatch = 0;
            
            return;
        }
        
        _reduceStopwatch += Time.deltaTime;
    }

    private void Reduce(Stats stats)
    {
        StatSo target = stats[_so.StatType];
        
        float now = target.ReduceValue(_reduceValue);

        if (!Mathf.Approximately(now, target.MinValue))
        {
            return;
        }

        _isReduce = false;
    }
}