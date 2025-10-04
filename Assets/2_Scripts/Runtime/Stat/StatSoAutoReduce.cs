using System;
using System.Collections.Generic;
using UnityEngine;

public class StatSoAutoReduce : MonoBehaviour
{
    [Header("[ Options ]")] 
    [SerializeField] private List<StatReduce> _statReduceList = new();
    
    [Header("[ References ]")]
    [SerializeField] private Stats _stats;

    private void Update()
    {
        foreach (StatReduce statReduce in _statReduceList)
        {
            statReduce.Update(_stats);
        }
    }
}