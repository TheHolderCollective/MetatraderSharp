using MetatraderSharp.MTsocketAPI.Responses;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MetatraderSharp.MetatraderClient;

public abstract partial class MetatraderClient
{
    #region Fields

    protected string _partialURI;
    protected string _webSocketPort;
    protected string _requestedUri;
    protected string _clientType;
    protected string _clientStatusMessage;
    protected string? _lastQueryMessage;
    protected int _lastQueryStatus;
    protected int _lastErrorCode;
    protected HttpClient _client;
    protected bool _clientStatusIsOK;

    #endregion

    #region Properties

    public string ClientType { get { return _clientType; } }
    public string ClientStatusMessage { get { return _clientStatusMessage; } }
    public string WebSocketPort { get { return _webSocketPort; } }
    public string LastRequestedUri { get { return _requestedUri; } }

    #endregion

    public MetatraderClient()
    {
        _partialURI = "http://127.0.0.1";
        _webSocketPort = "81";
        _lastQueryMessage = string.Empty;
        _requestedUri = string.Empty;
        _clientType = string.Empty;
        _clientStatusMessage = string.Empty;
        _client = new HttpClient();
    }

    public MetatraderClient(string clientType): this()
    {
        _clientType = clientType;
        VerifyHttpStatus(_client);
    }

    public MetatraderClient(string clientType, HttpClient client): this()
    {
        _clientType = clientType;
        _client = client;
        VerifyHttpStatus(_client);
    }

    public MetatraderClient(string clientType, HttpClient client, string webSocketPort) : this()
    {
        _clientType = clientType;
        _webSocketPort = webSocketPort;
        _client = client;
        VerifyHttpStatus(_client);
    }

    public MetatraderClient(string clientType, string webSocketPort): this()
    {
        _clientType = clientType;
        _webSocketPort = webSocketPort;
        VerifyHttpStatus(_client);
    }

    #region Async methods common to both terminal types

    public async Task<TerminalInfo> GetTerminalInfoAsync()
    {
        try
        {
            _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/terminal";

            var response = await _client.GetAsync(_requestedUri);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var terminalInfo = (responseContent != null) ? JsonConvert.DeserializeObject<TerminalInfo>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(terminalInfo);

            SetQueryResult(terminalInfo.ErrorID, terminalInfo.ErrorDescription);
            return terminalInfo;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new TerminalInfo()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<Quote> GetQuoteAsync(string symbol)
    {
        try
        {
            _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/quote?symbol={symbol}";

            var response = await _client.GetAsync(_requestedUri);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var quote = (responseContent != null) ? JsonConvert.DeserializeObject<Quote>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(quote);

            SetQueryResult(quote.ErrorID, quote.ErrorDescription);
            return quote;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new Quote()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<SymbolList> GetSymbolListAsync()
    {
        try
        {
            _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/symbol/list";

            var response = await _client.GetAsync(_requestedUri);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var symbolList = (responseContent != null) ? JsonConvert.DeserializeObject<SymbolList>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(symbolList);

            SetQueryResult(symbolList.ErrorID, symbolList.ErrorDescription);
            return symbolList;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new SymbolList()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<PriceHistory> GetPriceHistoryAsync(string symbol, string timeFrame, string fromDate, string toDate)
    {
        try
        {
            _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/history/prices?symbol={symbol}&timeframe={timeFrame}&from_date={fromDate}&to_date={toDate}";

            var response = await _client.GetAsync(_requestedUri);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var priceHistory = (responseContent != null) ? JsonConvert.DeserializeObject<PriceHistory>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(priceHistory);

            SetQueryResult(priceHistory.ErrorID, priceHistory.ErrorDescription);
            return priceHistory;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new PriceHistory()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<TrackResponse> TrackPricesAsync(TrackingCommand trackCommand, params string[] symbols)
    {
        try
        {
            _requestedUri = BuildTrackPricesUri(trackCommand, symbols);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_requestedUri),
                Headers =
                {
                    {"Accept","application/json" }
                }
            };

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var requestResponse = (responseContent != null) ? JsonConvert.DeserializeObject<TrackResponse>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(requestResponse);

            SetQueryResult(requestResponse.ErrorID, requestResponse.ErrorDescription);
            return requestResponse;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new TrackResponse()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }

    public async Task<TrackResponse> TrackOHLCsAsync(TrackOHLCRequest ohlcRequest)
    {
        try
        {
            string requestContent = ohlcRequest.ToString();
            _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/track/ohlc";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_requestedUri),
                Headers = { { "Accept", "application/json" } },
                Content = new StringContent(requestContent)
                {
                    Headers =
                      {
                         ContentType = new MediaTypeHeaderValue("application/json")
                      }
                }
            };

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var requestResponse = (responseContent != null) ? JsonConvert.DeserializeObject<TrackResponse>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(requestResponse);

            SetQueryResult(requestResponse.ErrorID, requestResponse.ErrorDescription);
            return requestResponse;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new TrackResponse()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }

    }

    #endregion

    #region Methods for getting statuses

    public bool ClientStatusIsOK()
    {
        return _clientStatusIsOK;
    }

    public bool ClientStatusIsError()
    {
        return !_clientStatusIsOK;
    }

    public bool LastQuerySuccessful()
    {
        return (_lastQueryStatus == QueryStatus.Ok);
    }

    public bool LastQueryFailed()
    {
        return (_lastQueryStatus == QueryStatus.Error);
    }

    public string? LastQueryMessage()
    {
        return _lastQueryMessage;
    }

    public int LastQueryStatus()
    {
        return _lastQueryStatus;
    }

    public int LastErrorCode()
    {
        return _lastErrorCode;
    }

    #endregion
}
