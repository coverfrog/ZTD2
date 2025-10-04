using UnityEngine;

[CreateAssetMenu]
public class StatSo : IdentifiedObject
{
    public delegate void OnValueChangedDelegate(float previous, float current);
    
    [Header("[ Stat ]")] 
    [SerializeField] private StatType _statType;
    [SerializeField] private bool _isPercentType = false;
    [SerializeField] private float _defaultValue = 100.0f;
    [SerializeField] private float _minValue = 0.0f;
    [SerializeField] private float _maxValue = 100.0f;
    
    public StatType StatType => _statType;
    public bool IsPercentType => _isPercentType;
    public float DefaultValue => _defaultValue;
    public float MinValue => _minValue;
    public float MaxValue => _maxValue;

    
    public event OnValueChangedDelegate OnValueChanged;

    public float SetDefaultValue(float value)
    {
        float previous = _defaultValue;
        
        _defaultValue = value; 
        
        OnValueChanged?.Invoke(previous, _defaultValue);

        return _defaultValue;
    }

    public float ReduceValue(float value)
    {
        float previous = _defaultValue;
        
        _defaultValue = Mathf.Clamp(_defaultValue - value, _minValue, _maxValue);
        
        OnValueChanged?.Invoke(previous, _defaultValue);
        
        return _defaultValue;
    }
    
    public float Value => _defaultValue;
}