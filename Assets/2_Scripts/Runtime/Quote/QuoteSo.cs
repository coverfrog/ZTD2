using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu]
public class QuoteSo : IdentifiedObject
{
    [Header("[ Quote ]")] 
    [SerializeField] private ItemSo _item;
    [SerializeField] private int _sellMinValue = 10;
    [SerializeField] private int _sellMaxValue = 100;

    public ItemSo Item => _item;

    public int SellValue => _item.SellValue;
    public int SellMinValue => _sellMinValue;
    public int SellMaxValue => _sellMaxValue;
    
    public void ReQuote()
    {
        int sellValue = Random.Range(_sellMinValue, _sellMaxValue);
        
        _item.SetSellValue(sellValue);
    }
}