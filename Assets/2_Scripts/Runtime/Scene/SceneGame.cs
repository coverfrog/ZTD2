using System;
using UnityEngine;

public class SceneGame : SceneBase
{
    [SerializeField] private RoundBase _round;

    private void Start()
    {
        _round.BeginRound(0);
    }
}
