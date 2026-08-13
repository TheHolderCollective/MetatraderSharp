using MetatraderSharp.MTsocketAPI.Responses;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MetatraderSharp.MetatraderClient;

public abstract partial class MetatraderClient
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
    public HttpClient Client { get; set; }

    #endregion

    public MetatraderClient(string terminalType)
    {
        _partialURI = "http://127.0.0.1";
        TerminalType = terminalType;
        LastQueryMessage = "";
        WebSocketPort = "81";
        Client = new HttpClient();

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

    public async Task<TrackPricesResponse> TrackPricesAsync(TrackingCommand trackCommand, params string[] symbols)
    {
        try
        {
            string uri = BuildTrackPricesUri(trackCommand, symbols);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
                Headers =
                {
                    {"Accept","application/json" }
                }
            };

            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var requestResponse = (responseContent != null) ? JsonConvert.DeserializeObject<TrackPricesResponse>(responseContent) : null;

            SetQueryResult(requestResponse.ErrorID, requestResponse.ErrorDescription);
            return requestResponse;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new TrackPricesResponse()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }

    public async Task<TrackOHLCResponse> TrackOHLCsAsync(TrackOHLCRequest ohlcRequest)
    {
        try
        {
            string requestContent = ohlcRequest.ToString();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://127.0.0.1:81/v1/track/ohlc"),
                Headers = { { "Accept", "application/json" } },
                Content = new StringContent(requestContent)
                {
                    Headers =
                      {
                         ContentType = new MediaTypeHeaderValue("application/json")
                      }
                }
            };

            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var requestResponse = (responseContent != null) ? JsonConvert.DeserializeObject<TrackOHLCResponse>(responseContent) : null;

            SetQueryResult(requestResponse.ErrorID, requestResponse.ErrorDescription);
            return requestResponse;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new TrackOHLCResponse()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }

    }
   
}
