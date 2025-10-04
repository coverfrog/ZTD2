using UnityEngine;

[CreateAssetMenu]
public class ItemSo : IdentifiedObject
{
    [Header("[ Item ]")] 
    [SerializeField] private int _sellValue = 20;
    
    public int SellValue => _sellValue;
    
    public void SetSellValue(int value) => _sellValue = value;
}
