using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UIStatSlider : MonoBehaviour
{
    [Header("[ Options ]")] 
    [SerializeField] private bool _isAwake;
    [SerializeField] private float _duration = 0.2f;
    
    [Header("[ Dynamic ]")]
    [SerializeField] private Stats _stats;
    [SerializeField] private StatSo _target;

    [Header("[ References ]")]
    [SerializeField] private Slider _slider;

    private StatSo _bind;
    
    private void Awake()
    {
        if (!_isAwake)
            return;
        
        if (_stats && _target)
            Initialize(_stats, _target);
    }

    private void OnDestroy()
    {
        if (_bind)
            _bind.OnValueChanged -= OnValueChanged;
    }

    public void Initialize(Stats stats, StatSo target)
    {
        if (!stats || !target)
        {
            return;
        }
        
        _slider ??= GetComponent<Slider>();
        _stats = stats;
        _target = target;

        if (_bind)
        {
            _bind.OnValueChanged -= OnValueChanged;
        }
        
        _bind = stats[target.StatType];
        _bind.OnValueChanged += OnValueChanged;
    }

    private void OnValueChanged(float previous, float current)
    {
        float min = _bind.MinValue;
        float max = _bind.MaxValue;

        float delta = max - min;

        float scale01 = (current - min) / delta;
        
        Vector3 trScale = _slider.transform.localScale;
        trScale.x *= scale01;

        _slider.transform.DOKill();
        _slider.transform.DOScaleX(scale01, _duration).SetEase(Ease.Linear);
    }
}