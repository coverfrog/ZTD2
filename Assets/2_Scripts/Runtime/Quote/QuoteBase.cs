using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class QuoteBase : MonoBehaviour
{
    public delegate void OnReQuoteDelegate(List<QuoteSo> quotes);
    
    public OnReQuoteDelegate OnReQuote;
    
    private List<QuoteSo> _quoteItemSoList;
    
    private bool _isInitialized;

    public virtual void ReQuote()
    {
        if (!_isInitialized)
            Initialize();
        
        foreach (QuoteSo so in _quoteItemSoList)
        {
            so.ReQuote();
        }
        
        OnReQuote?.Invoke(_quoteItemSoList);
    }
    
    private void Initialize()
    {
        if (_isInitialized) 
            return;
        
        _quoteItemSoList = Resources.LoadAll<QuoteSo>("Quote")
            .Select(x => x.Clone() as QuoteSo)
            .ToList();
    }

}