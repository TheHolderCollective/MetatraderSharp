using MetatraderSharp.MTsocketAPI.Responses;
using Newtonsoft.Json;
namespace MetatraderSharp.MetatraderClient;

public abstract class MetatraderClient
{
    #region Fields

    protected string _partialURI;

    #endregion

    #region Properties

    public bool StatusIsOK { get; protected set; }
    public int LastQueryStatus { get; protected set; }
    public string TerminalType { get; protected set; }
    public string LastQueryMessage { get; protected set; }
    public string WebSocketPort { get; set; }
    public HttpClient? Client { get; set; }

    #endregion

    public MetatraderClient(string terminalType)
    {
        TerminalType = terminalType;

        SetupRequestUriComponents();
        SetupHttpClient();
        VerifyHttpStatus();
    }

    public async Task<TerminalInfo> GetTerminalInfoAsync()
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/terminal");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var terminalInfo = (responseContent != null) ? JsonConvert.DeserializeObject<TerminalInfo>(responseContent) : null;

            SetQueryResult(terminalInfo.ErrorID, terminalInfo.ErrorDescription);
            return terminalInfo;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new TerminalInfo()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<Quote> GetQuoteAsync(string symbol)
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/quote?symbol={symbol}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var quote = (responseContent != null) ? JsonConvert.DeserializeObject<Quote>(responseContent) : null;

            SetQueryResult(quote.ErrorID, quote.ErrorDescription);
            return quote;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new Quote()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<SymbolList> GetSymbolListAsync()
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/symbol/list");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var symbolList = (responseContent != null) ? JsonConvert.DeserializeObject<SymbolList>(responseContent) : null;

            SetQueryResult(symbolList.ErrorID, symbolList.ErrorDescription);
            return symbolList;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new SymbolList()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<PriceHistory> GetPriceHistoryAsync(string symbol, string timeFrame, string fromDate, string toDate)
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/history/prices?symbol={symbol}&timeframe={timeFrame}&from_date={fromDate}&to_date={toDate}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var priceHistory = (responseContent != null) ? JsonConvert.DeserializeObject<PriceHistory>(responseContent) : null;

            SetQueryResult(priceHistory.ErrorID, priceHistory.ErrorDescription);
            return priceHistory;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new PriceHistory()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    #region Helpers - Constructor

    private void SetupRequestUriComponents()
    {
        _partialURI = "http://127.0.0.1";
        WebSocketPort = "81";
    }

    private void SetupHttpClient()
    {
        Client = new HttpClient();
    }

    private void VerifyHttpStatus()
    {
        try
        {
            string url = $"{_partialURI}:{WebSocketPort}";
            var response = Client.GetAsync(url).Result;
            StatusIsOK = response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            StatusIsOK = false;
        }
    }
    #endregion

    #region Helpers - Error Handling

    protected void SetQueryResult(int errorID, string errorDescription)
    {
        switch (errorID)
        {
            case 0:
                LastQueryStatus = QueryStatus.Ok;
                break;
            default:
                LastQueryStatus = QueryStatus.Error;
                break;
        }
        LastQueryMessage = errorDescription;
    }

    #endregion
}
