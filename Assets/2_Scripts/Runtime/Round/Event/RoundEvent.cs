using System;
using UnityEngine;

[Serializable]
public abstract class RoundEvent : ICloneable
{
    [Header("[ Event ]")]
    public string label;
    [Min(0)] public float executeSec = 0;

    public abstract object Clone();
    
    public abstract void Execute();
}