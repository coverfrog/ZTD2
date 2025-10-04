using TMPro;
using UnityEngine;

public class UIGoldText : MonoBehaviour
{
    [Header("[ References ]")]
    [SerializeField] private TMP_Text _goldText;
        
    [Header("[ External ]")] 
    [SerializeField] private ItemSo _goldItem;

    public void Init(ItemSo goldItem)
    {
        _goldItem = goldItem;
    }
}