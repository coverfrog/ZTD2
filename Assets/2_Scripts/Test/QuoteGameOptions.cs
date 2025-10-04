using System;
using System.Collections.Generic;

[Serializable]
public class QuoteGameOptions
{
    public float quoteInterval = 5.0f;
    public List<ItemSo> quoteItemList = new();
}