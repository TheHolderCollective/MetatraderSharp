using MetatraderSharp.MTsocketAPI.Responses.Common;
using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.MetatraderClient;

public class MT5Client : MetatraderClient
{
    public MT5Client() : base(MetatraderClientType.MT5)
    {
    }

    public MT5Client(HttpClient client) : base(MetatraderClientType.MT5, client)
    {
    }

    public MT5Client(HttpClient client, string webSocketPort) : base(MetatraderClientType.MT5, client, webSocketPort)
    {
    }

    public MT5Client(string webSocketPort) : base(MetatraderClientType.MT5, webSocketPort)
    {
    }

    public async Task<Account> GetAccountInfoAsync()
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/account";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<Account>(_request);
    }

    public async Task<Calendar> GetCalendarAsync(string fromDate, string toDate, string countryCode = "", string currency = "")
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/calendar?from_date={fromDate}&to_date={toDate}&country_code={countryCode}&currency={currency}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<Calendar>(_request);
    }

    public async Task<TickHistory> GetTickHistoryAsync(string fromDate, string toDate, string symbol, string tickFlag)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/history/ticks?symbol={symbol}&flags={tickFlag}&from_date={fromDate}&to_date={toDate}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<TickHistory>(_request);
    }

    public async Task<OrderHistory> GetOrderHistoryAsync(string fromDate, string toDate, string mode)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/history/orders?from_date={fromDate}&to_date={toDate}&mode={mode}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<OrderHistory>(_request);
    }

    public async Task<Indicator> GetATRIndicatorValuesAsync(int period, int shift, string symbol, string timeframe)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/indicator/atr?symbol={symbol}&timeframe={timeframe}&period={period}&shift={shift}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<Indicator>(_request);
    }

    public async Task<Indicator> GetCustomIndicatorValuesAsync(string indicatorName, string symbol, string timeframe, int index, int count, string param1 = "", string param2 = "", string param3 = "", string param4 = "")
    {
        _requestedUri = UriBuilder.BuildMT5GetCustomIndicatorValuesUri(indicatorName, symbol, timeframe, index, count, param1, param2, param3, param4);
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<Indicator>(_request);
    }

    public async Task<Indicator> GetMAIndicatorValuesAsync(string appliedPrice, string ma_Method, int ma_Period, int count, int ma_Shift, string symbol, string timeframe)
    {
        _requestedUri = UriBuilder.BuildMT5MAIndicatorValuesUri(appliedPrice, ma_Method, ma_Period, count, ma_Shift, symbol, timeframe);
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<Indicator>(_request);
    }

    public async Task<OrderSendResponse> PlaceOrderAsync(string symbol, string orderType, double volume, bool async = false, double price = 0.0, double stopLoss = 0.0,
                                                         double takeProfit = 0.0, int magic = 0, string orderFillType = "", string comment = "", string expiration = "")
    {
        _requestedUri = UriBuilder.BuildMT5SendOrderUri(symbol, orderType, volume, async, price, stopLoss, takeProfit, magic, orderFillType, comment, expiration);
        _request = BuildHttpPostRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<OrderSendResponse>(_request);
    }

    public async Task<OrderModifyResponse> ModifyOrderAsync(long ticketNumber, double stopLoss, double takeProfit = 0.0, double price = 0.0, bool async = false, string expiration = "")
    {
        _requestedUri = UriBuilder.BuildMT5ModifyOrderUri(ticketNumber, stopLoss, takeProfit, price, async, expiration);
        _request = BuildHttpPostRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<OrderModifyResponse>(_request);
    }

    public async Task<OrderCloseResponse> CloseOrderAsync(long ticketNumber, double volume = 0.0, bool async = false)
    {
        _requestedUri = UriBuilder.BuildMT5CloseOrderUri(ticketNumber, volume, async);
        _request = BuildHttpPostRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<OrderCloseResponse>(_request);
    }

    public async Task<OrderList> GetOrderListAsync()
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/order/list";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<OrderList>(_request);
    }

    public async Task<OrderInfo> GetOrderInfoAsync(long ticketNumber)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/order/info?ticket={ticketNumber}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<OrderInfo>(_request);
    }

    public async Task<SymbolInformation> GetSymbolInformationAsync(string symbol)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/symbol/info?symbol={symbol}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<SymbolInformation>(_request);
    }

    public async Task<TrackOrderEventsResponse> TrackOrderEventsAsync(bool enabled)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/track/orders?enabled={enabled}";
        _request = BuildHttpPostRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<TrackOrderEventsResponse>(_request);
    }

    public async Task<TrackResponse> TrackMarketBookAsync(params string[] symbolList)
    {
        _requestedUri = UriBuilder.BuildMT5TrackMarketBookUri(symbolList);
        _request = BuildHttpPostRequest(_requestedUri);

        return await GetMTsocketApiResponseAsync<TrackResponse>(_request);
    }
}