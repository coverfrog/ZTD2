using System;
using UnityEngine;

[CreateAssetMenu]
public class IdentifiedObject : ScriptableObject, ICloneable
{
    [Header("[ Base ]")]
    [SerializeField] private int _id = -1;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _codeName;
    [SerializeField] private string _displayName;
    [SerializeField, TextArea] private string _description;

    public int Id => _id;
    public Sprite Icon => _icon;
    public string CodeName => _codeName;
    public string DisplayName => _displayName;
    public string Description => _description;
    
    public virtual object Clone() => Instantiate(this);
}