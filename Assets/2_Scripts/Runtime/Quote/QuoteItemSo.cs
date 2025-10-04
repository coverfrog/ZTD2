using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class QuoteItemSo : IdentifiedObject
{
    [Header("[ Quote ]")]
    [SerializeField] private int _defaultValue = 20;
    [SerializeField] private int _minValue = 10;
    [SerializeField] private int _maxValue = 100;
    
    public int DefaultValue => _defaultValue;
    public int MinValue => _minValue;
    public int MaxValue => _maxValue;
    
    public void ReQuote()
    {
        _defaultValue = Random.Range(_minValue, _maxValue);
    }
}