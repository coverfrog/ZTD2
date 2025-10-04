using System;
using System.Collections.Generic;
using UnityEngine;

public class QuoteGame : MonoBehaviour, ITimerCallback
{
    [SerializeField] private QuoteGameOptions _options;
    [Space]
    [SerializeField] private TimerInfinite _timer;
    
    private uint _quoteIndex;

    private List<Quote> _quoteList;
    
    #region On Change Quote Callbacks

    private readonly List<IChangeQuoteCallback> _onChangeQuoteCallbacks = new List<IChangeQuoteCallback>();
    
    public void AddQuoteCallback(IChangeQuoteCallback callback)
        => _onChangeQuoteCallbacks.Add(callback);
    
    public void RemoveQuoteCallback(IChangeQuoteCallback callback)
        => _onChangeQuoteCallbacks.Remove(callback);

    #endregion

    private void Awake()
    {
        // So 에서 함수는 실행시킨다 해도 Clone 은 하지 말자 
        // 처음부터 모든 구조가 확실한게 아니라면 위험 부담이 크다.
        // 차라리 값을 무조건 초기화 시키기
        
        // 초기 값을 0으로 강제 설정
        // 찌거기 값 제거 용도
        _options.quoteItemList.ForEach(x => x.SetSellValue(0));
        
        // 옵션에 등록된 아이템 가지고 옵션에 등록
        _quoteList = new List<Quote>(3);
        _options.quoteItemList.ForEach(x => _quoteList.Add(new Quote(x)));
    }

    private void OnEnable()
    {
        _timer.AddCallback(this);
    }

    private void OnDisable()
    {
        _timer.RemoveCallback(this);
    }

    private void Start()
    {
        _quoteIndex = 0;
        
        _timer.Begin(_options.quoteInterval);
    }

    public void OnTimerBegin(float currentSec, float targetSec)
    {
        // 라운드 역할을 대신 진행
        // 특정 라운드에서 이벤트 추가 하고 싶을 시 이곳에 이벤트 추가
        
        // 시세 변경
        ChangeQuote();
    }

    public void OnTimerProgress(float currentSec, float targetSec)
    {
       
    }

    public void OnTimerComplete(float currentSec, float targetSec)
    {
        _quoteIndex += 1;
    }

    private void ChangeQuote()
    {
        // 시세 담당자들에게 변경 요청
        // *** 현재는 클래스 내부에서 임의의 값을 통해 변수 값 결정, 이후에 변경 필요
        _quoteList.ForEach(x => x.ChangeQuote());
        
        // 콜백
        _onChangeQuoteCallbacks.ForEach(x => x.OnQuoteChange(_quoteList));
    }
}