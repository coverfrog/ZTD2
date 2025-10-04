using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

// public class UIQuote : MonoBehaviour, ITimerCallback
// {
//     [Header("[ Options ]")] 
//     [SerializeField] private UIQuoteElement _prefab;
//     
//     [Header("[ References ]")]
//     [SerializeField] private RectTransform _content;
//     [SerializeField] private TMP_Text _timerText;
//     
//     [Header("[ External ]")]
//     [SerializeField] private QuoteBase _quote;
//     [SerializeField] private TimerBase _timer;
//
//     private List<UIQuoteElement> _elements = new();
//     
//     private void Awake()
//     {
//         _quote.OnReQuote += OnReQuote;
//     }
//
//     private void OnEnable()
//     {
//         _timer.AddCallback(this);
//     }
//
//     private void OnDisable()
//     {
//         _timer.RemoveCallback(this);
//     }
//
//     private void OnReQuote(List<QuoteSo> quotes)
//     {
//         foreach (QuoteSo so in quotes)
//         {
//             UIQuoteElement element = _elements.FirstOrDefault(x => x.So.CodeName == so.CodeName);
//
//             if (!element)
//             {
//                 element = Instantiate(_prefab, _content);
//                 
//                 _elements.Add(element);
//             }
//             
//             element.Apply(so);
//         }
//     }
//
//     public void OnTimerProgress(float currentSec, float targetSec)
//     {
//         _timerText.text = $"{currentSec:0}";
//     }
//
//     public void OnTimerComplete(float currentSec, float targetSec)
//     {
//         OnTimerProgress(currentSec, targetSec);
//     }
// }