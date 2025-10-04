using System.Collections.Generic;

public interface IChangeQuoteCallback
{
    void OnQuoteChange(List<Quote> quoteList);
}