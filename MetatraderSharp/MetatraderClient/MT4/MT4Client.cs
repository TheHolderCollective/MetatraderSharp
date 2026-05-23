using MetatraderSharp.MTsocketAPI.Responses;
namespace MetatraderSharp.MetatraderClient;

public partial class MT4Client
{
    #region Fields

    private HttpClient _client;
    private string _partialURI;

    #endregion

    #region Properties

    public string TerminalType { get; protected set; }
    public bool StatusIsOK { get; protected set; }
    public QueryStatus LastQueryStatus { get; protected set; }
    public string LastQueryMessage { get; protected set; }
    public string WebSocketPort { get; set; }
    public HttpClient? Client
    {
        set
        {
            _client = value;
        }
    }

    #endregion

    public MT4Client()
    {
        TerminalType = MetatraderTerminalType.MT4;
        SetupRequestUriComponents();
        SetupHttpClient();
        VerifyHttpStatus();
    }

    public Account GetAccountInfo()
    {
        return GetAccountInfoAsync().Result;
    }

    public TerminalInfo? GetTerminalInfo()
    {
        return GetTerminalInfoAsync().Result;
    }

    public SymbolList? GetSymbolListResponse()
    {
        return GetSymbolListResponseAsync().Result;
    }

    public List<Symbol> GetSymbolList()
    {
        var response = GetSymbolListResponseAsync();

        if (LastQueryStatus == QueryStatus.OK)
        {
            return response.Result.Symbols;
        }
        else
        {
            return new List<Symbol>();
        }
    }

    public Quote GetQuote(string symbol)
    {
        return GetQuoteAsync(symbol).Result;
    }

    public PriceHistory GetPriceHistoryResponse(string symbol, string timeFrame, string fromDate, string toDate)
    {
        return GetPriceHistoryAsync(symbol, timeFrame, fromDate, toDate).Result;
    }

    public List<Rate> GetOHLCs(string symbol, string timeFrame, string fromDate, string toDate)
    {
        var response = GetPriceHistoryAsync(symbol, timeFrame, fromDate, toDate);

        if (LastQueryStatus == QueryStatus.OK)
        {
            return response.Result.Rates;
        }
        else
        {
            return new List<Rate>();
        }
    }

    public TrackPricesResponse PriceTracker(TrackingCommand trackCommand, string symbol1 = "", string symbol2 = "", string symbol3 = "", string symbol4 = "", string symbol5 = "")
    {
        return TrackPricesAsync(trackCommand, symbol1, symbol2, symbol3, symbol4, symbol5).Result;
    }
}
