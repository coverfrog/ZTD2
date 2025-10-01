using System;
using UnityEngine;

[Serializable]
public abstract class RoundEvent : ICloneable
{
    [Header("[ Event ]")]
    public string label;

    [Min(1)] public float executeSec = 15;

    public abstract object Clone();
}