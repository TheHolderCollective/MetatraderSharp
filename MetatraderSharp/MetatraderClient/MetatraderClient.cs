using MetatraderSharp.MTsocketAPI.Responses.Base;
using MetatraderSharp.MTsocketAPI.Responses.Common;
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
    protected HttpRequestMessage _request;
    protected bool _clientStatusIsOK;

    #endregion

    #region Properties

    public string ClientType { get { return _clientType; } }
    public string ClientStatusMessage { get { return _clientStatusMessage; } }
    public string WebSocketPort { get { return _webSocketPort; } }
    public string LastRequestedUri { get { return _requestedUri; } }

    #endregion

    #region Constructors

    public MetatraderClient()
    {
        _partialURI = "http://127.0.0.1";
        _webSocketPort = "81";
        _lastQueryMessage = string.Empty;
        _requestedUri = string.Empty;
        _clientType = string.Empty;
        _clientStatusMessage = string.Empty;
        _client = new HttpClient();
        _request = new HttpRequestMessage();
    }

    public MetatraderClient(string clientType) : this()
    {
        _clientType = clientType;
        VerifyHttpStatus(_client);
    }

    public MetatraderClient(string clientType, HttpClient client) : this()
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

    public MetatraderClient(string clientType, string webSocketPort) : this()
    {
        _clientType = clientType;
        _webSocketPort = webSocketPort;
        VerifyHttpStatus(_client);
    }

    #endregion

    #region Generic method for getting api responses

    protected async Task<T> GetMTsocketApiResponseAsync<T>(HttpRequestMessage request) where T : MTsocketApiResponse, new()
    {
        try
        {
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var deserializedObject = (responseContent != null) ? JsonConvert.DeserializeObject<T>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(deserializedObject);

            SetQueryResult(deserializedObject.ErrorID, deserializedObject.ErrorDescription);
            return deserializedObject;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new T()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }

    #endregion

    #region Async methods common to both terminal types

    public async Task<TerminalInfo> GetTerminalInfoAsync()
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/terminal";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<TerminalInfo>(_request);
    }

    public async Task<Quote> GetQuoteAsync(string symbol)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/quote?symbol={symbol}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<Quote>(_request);
    }

    public async Task<SymbolList> GetSymbolListAsync()
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/symbol/list";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<SymbolList>(_request);
    }

    public async Task<PriceHistory> GetPriceHistoryAsync(string symbol, string timeFrame, string fromDate, string toDate)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/history/prices?symbol={symbol}&timeframe={timeFrame}&from_date={fromDate}&to_date={toDate}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<PriceHistory>(_request);
    }

    public async Task<TrackResponse> TrackPricesAsync(TrackingCommand trackCommand, params string[] symbols)
    {
        _requestedUri = BuildTrackPricesUri(trackCommand, symbols);
        _request = BuildHttpPostRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<TrackResponse>(_request);
    }

    public async Task<TrackResponse> TrackOHLCsAsync(TrackOHLCRequest ohlcRequest)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/track/ohlc";
        _request = BuildHttpPostRequest(_requestedUri, ohlcRequest.ToString());

        return await GetMTsocketApiResponseAsync<TrackResponse>(_request);
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

    #region Helper methods for building HttpRequestMessages

    protected HttpRequestMessage BuildHttpGetRequest(string uri)
    {
        return new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uri),
            Headers = { { "Accept", "application/json" } }
        };
    }

    protected HttpRequestMessage BuildHttpPostRequest(string uri)
    {
        return new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_requestedUri),
            Headers = { { "Accept", "application/json" } }
        };
    }

    protected HttpRequestMessage BuildHttpPostRequest(string uri, string requestContent)
    {
        return new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri),
            Headers = { { "Accept", "application/json" } },
            Content = new StringContent(requestContent)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            }
        };
    }

    #endregion
}
