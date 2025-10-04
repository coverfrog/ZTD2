using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("[ Options ]")]
    [SerializeField] private List<StatOverride> _statOverrides = new();

    private bool _initialized;
    
    private Dictionary<StatType, StatSo> _statDict = new();

    public StatSo this[StatType type]
    {
        get
        {
            if (!_initialized)
                Initialize();
            
            return _statDict[type];
        }
    }
    
    private void Awake()
    {
        if (_initialized)
            return;
        
        Initialize();
    }

    private void Initialize()
    {
        if (_initialized)
            return;
        
        _statDict.Clear();
        
        foreach (StatSo source in Resources.LoadAll<StatSo>("Stat"))
        {
            if (source.Clone() is not StatSo ins)
                continue;
            
            _statDict.Add(ins.StatType, ins);
        }
        
        foreach (StatOverride o in _statOverrides)
        {
            StatType type = o.So.StatType;

            _statDict[type].SetDefaultValue(o.DefaultValue);
        }

        _initialized = true;
    }

    public void Report()
    {
        string msg = $"{gameObject.name} Stats\n";

        foreach ((StatType type, StatSo stat) in _statDict)
        {
            msg += $"{type} : {stat.Value}\n";
        }
        
        Debug.Log(msg);
    }
}