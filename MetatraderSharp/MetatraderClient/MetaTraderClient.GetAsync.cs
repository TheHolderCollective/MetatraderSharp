using MetatraderSharp.MTsocketAPI.Responses;
using Newtonsoft.Json;
namespace MetatraderSharp;

public partial class MetatraderClient
{
    private async Task<Account> GetAccountInfoAsync()
    {
        try
        {
            var response = await _client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/account");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var account = (responseContent != null) ? JsonConvert.DeserializeObject<Account>(responseContent) : null;

            SetQueryResult(account.ErrorID, account.ErrorDescription);
            return account;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new Account()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    private async Task<TerminalInfo> GetTerminalInfoAsync()
    {
        try
        {
            var response = await _client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/terminal");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var terminalInfo = (responseContent != null) ? JsonConvert.DeserializeObject<TerminalInfo>(responseContent) : null;

            SetQueryResult(terminalInfo.ErrorID, terminalInfo.ErrorDescription);
            return terminalInfo;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new TerminalInfo()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    private async Task<SymbolList> GetSymbolListResponseAsync()
    {
        try
        {
            var response = await _client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/symbol/list");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var symbolList = (responseContent != null) ? JsonConvert.DeserializeObject<SymbolList>(responseContent) : null;

            SetQueryResult(symbolList.ErrorID, symbolList.ErrorDescription);
            return symbolList;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new SymbolList()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    private async Task<Quote> GetQuoteAsync(string symbol)
    {
        try
        {
            var response = await _client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/quote?symbol={symbol}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var quote = (responseContent != null) ? JsonConvert.DeserializeObject<Quote>(responseContent) : null;

            SetQueryResult(quote.ErrorID, quote.ErrorDescription);
            return quote;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new Quote()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    private async Task<PriceHistory> GetPriceHistoryAsync(string symbol, string timeFrame, string fromDate, string toDate)
    {
        try
        {
            var response = await _client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/history/prices?symbol={symbol}&timeframe={timeFrame}&from_date={fromDate}&to_date={toDate}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var priceHistory = (responseContent != null) ? JsonConvert.DeserializeObject<PriceHistory>(responseContent) : null;

            SetQueryResult(priceHistory.ErrorID, priceHistory.ErrorDescription);
            return priceHistory;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new PriceHistory()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }

    }
}
