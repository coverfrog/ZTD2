using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMove : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("[ Options ]")] 
    [SerializeField] private bool _isLock;
    [SerializeField] private Color _lockedColor = Color.dodgerBlue;
    [SerializeField] private Color _unlockedColor = Color.black;
    
    [Header("[ References ]")] 
    [SerializeField] private RectTransform _eventRt;
    [SerializeField] private RectTransform _moveRt;
    [SerializeField] private Button _btnLocked;

    [Header("[ Values ]")]
    [SerializeField] private Vector2 _clickRatio;

    private void Awake()
    {
        if (_btnLocked)
        {
            _btnLocked.onClick.AddListener(ToggleLock);
            ApplyLock();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isLock)
            return;
        
        Vector2 clickPoint = eventData.position;
        Vector2 moveSize = _moveRt.sizeDelta * new Vector2(_moveRt.pivot.x, _moveRt.pivot.y * -1.0f);
        Vector2 reduceEventSize = _eventRt.sizeDelta * _clickRatio * -1;

        Vector2 result = clickPoint + moveSize + reduceEventSize;

        _moveRt.position = result;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isLock)
            return;
        
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _eventRt,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPoint))
        {
            return;
        }
        
        Rect rect = _eventRt.rect;
        
        float xPercent = (localPoint.x - rect.xMin) / rect.width;
        float yPercent = (localPoint.y - rect.yMin) / rect.height;
        
        _clickRatio = new Vector2(xPercent, yPercent);
    }

    private void ToggleLock()
    {
        _isLock = !_isLock;

        ApplyLock();
    }

    private void ApplyLock()
    {
        _btnLocked.image.color = _isLock ? _lockedColor : _unlockedColor;
    }
}