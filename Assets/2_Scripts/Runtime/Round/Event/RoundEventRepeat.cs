using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class RoundEventRepeat : RoundEvent
{
    [Header("[ Repeat ]")]
    [Min(1)] public int executeCount = 1;
    [Min(0.1f)] public float executeInterval = 1.0f;

    public IReadOnlyList<RoundEvent> ToEventList()
    {
        List<RoundEvent> result = new();
        
        for (int i = 0; i < executeCount; i++)
        {
            float sec = executeSec + i * executeInterval;

            if (sec < 0)
                continue;

            if (Clone() is not RoundEventRepeat ins) 
                continue;
                    
            ins.executeSec = sec;
            ins.executeCount = 1;
            ins.executeInterval = 0;

            result.Add(ins);
        }
        
        return result;
    }
}