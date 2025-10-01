using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoundSo : ScriptableObject
{
    [SerializeReference, SubclassSelector] private List<RoundEvent> _roundEvents = new List<RoundEvent>();
    
    public IReadOnlyList<RoundEvent> RoundEvents => _roundEvents;
}