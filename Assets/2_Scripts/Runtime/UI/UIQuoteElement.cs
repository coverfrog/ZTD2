using TMPro;
using UnityEngine;

public class UIQuoteElement : MonoBehaviour
{
    [Header("[ References ]")]
    [SerializeField] private TMP_Text _elementText;

    [Header("[ Values ]")]
    [SerializeField] private int _value;
    [SerializeField] private QuoteSo _so;
    
    public QuoteSo So => _so;
    
    public void Apply(QuoteSo so)
    {
        _so = so;
        
        string n = _so.Item.DisplayName;
        string v = _so.SellValue.ToString();

        _elementText.text = $"{n} ( {v} )";
    }
}