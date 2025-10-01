using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class RoundEventRepeat : RoundEvent
{
    [Header("[ Repeat ]")]
    [Min(1)] public int executeCount = 1;
    [Min(0.1f)] public float executeInterval = 1.0f;
}