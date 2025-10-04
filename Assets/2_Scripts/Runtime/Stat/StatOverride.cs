using System;
using UnityEngine;

[Serializable]
public class StatOverride
{
    [SerializeField] private StatSo _so;
    [SerializeField] private float _defaultValue;
    
    public StatSo So => _so;
    public float DefaultValue => _defaultValue;
}