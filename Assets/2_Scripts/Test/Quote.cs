using UnityEngine;

public class Quote
{
    private ItemSo _item;

    private int _min = 1;
    private int _max = 100;
    
    public int Value { get; private set; }
    
    public Quote(ItemSo item)
    {
        _item = item;
    }

    public void ChangeQuote()
    {
        Value = Random.Range(_min, _max);
    }
}