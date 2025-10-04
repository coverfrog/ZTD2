using System;
using TMPro;
using UnityEngine;

public class Test : MonoBehaviour, ITimerCallback
{
    public TMP_Text text;
    public TimerBase timer;

    private void Start()
    {
        timer.AddCallback(this);
    }

    public void OnTimerBegin(float currentSec, float targetSec)
    {
        
    }

    public void OnTimerProgress(float currentSec, float targetSec)
    {
        text.text = $"{currentSec:0}";
    }

    public void OnTimerComplete(float currentSec, float targetSec)
    {
        OnTimerProgress(currentSec, targetSec);
    }
}
