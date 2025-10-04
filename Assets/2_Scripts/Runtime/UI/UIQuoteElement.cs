using TMPro;
using UnityEngine;

public class UIQuoteElement : MonoBehaviour
{
    [Header("[ References ]")]
    [SerializeField] private TMP_Text _elementText;

    [Header("[ Values ]")]
    [SerializeField] private int _value;
    [SerializeField] private QuoteItemSo _so;
    
    public QuoteItemSo So => _so;
    
    public void Initialize(QuoteItemSo so)
    {
        _so = so;
    }

    public void Apply()
    {
        string n = _so.DisplayName;
        string v = _so.DefaultValue.ToString();

        _elementText.text = $"{n} ( {v} )";
    }
}