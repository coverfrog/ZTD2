using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class QuoteBase : MonoBehaviour
{
    public delegate void OnReQuoteDelegate(List<QuoteItemSo> quotes);
    
    public OnReQuoteDelegate OnReQuote;
    
    private List<QuoteItemSo> _quoteItemSoList;
    
    private bool _isInitialized;

    public List<QuoteItemSo> ItemSoList
    {
        get
        {
            if (!_isInitialized)
                Initialize();
            
            return _quoteItemSoList;
        }
    }
    
    public virtual void ReQuote()
    {
        if (!_isInitialized)
            Initialize();
        
        foreach (QuoteItemSo so in _quoteItemSoList)
        {
            so.ReQuote();
        }
        
        OnReQuote?.Invoke(_quoteItemSoList);
    }
    
    private void Initialize()
    {
        if (_isInitialized) 
            return;
        
        _quoteItemSoList = Resources.LoadAll<QuoteItemSo>("Quote")
            .Select(x => x.Clone() as QuoteItemSo)
            .ToList();
    }

}