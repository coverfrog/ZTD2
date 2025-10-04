using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoundSo : IdentifiedObject
{
    [Header("[ Round ]")] 
    [SerializeField] private float _targetSec = 30;
    [SerializeReference, SubclassSelector] private List<RoundEvent> _roundEvents = new List<RoundEvent>();
    
    public float TargetSec => _targetSec;
    
    public IReadOnlyList<RoundEvent> RoundEvents => _roundEvents;
}