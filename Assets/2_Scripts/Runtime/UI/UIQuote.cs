using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIQuote : MonoBehaviour
{
    [Header("[ Options ]")] 
    [SerializeField] private UIQuoteElement _prefab;
    [SerializeField] private RectTransform _content;

    [Header("[ Dynamic ]")]
    [SerializeField] private QuoteBase _quote;

    private List<UIQuoteElement> _elements = new();
    
    private void Awake()
    {
        _quote.OnReQuote += OnReQuote;
    }

    public void Start()
    {
        // OnReQuote();
    }

    private void OnReQuote(List<QuoteItemSo> quotes)
    {
        foreach (QuoteItemSo so in quotes)
        {
            UIQuoteElement element = _elements.FirstOrDefault(x => x.So.CodeName == so.CodeName);

            if (!element)
            {
                element = Instantiate(_prefab, _content);
                element.Initialize(so);
                
                _elements.Add(element);
            }
            
            element.Apply();
        }
    }
}