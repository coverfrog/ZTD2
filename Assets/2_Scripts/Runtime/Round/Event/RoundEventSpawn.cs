using System;
using UnityEngine;

[Serializable]
public class RoundEventSpawn : RoundEventRepeat
{
    [Header("[ Spawn ]")]
    public string spawnCodeName;
    [Min(1)] public int spawnCount = 1;

    public override object Clone() => new RoundEventSpawn()
    {
        label           = label,
        executeSec      = executeSec,
        executeCount    = executeCount,
        executeInterval = executeInterval,
        spawnCodeName   = spawnCodeName,
        spawnCount      = spawnCount
    };

    public override void Execute()
    {
        string objName = $"Unit <{spawnCodeName}>";

        _ = new GameObject(objName);
    }
}