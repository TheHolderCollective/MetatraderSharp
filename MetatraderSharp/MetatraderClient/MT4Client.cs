using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.MetatraderClient;

public partial class MT4Client : MetatraderClient
{
    public MT4Client() : base(MetatraderClientType.MT4)
    {
    }

    public MT4Client(HttpClient client) : base(MetatraderClientType.MT4, client)
    {
    }

    public MT4Client(HttpClient client,string webSocketPort) : base(MetatraderClientType.MT4, client, webSocketPort)
    {
    }

    public MT4Client(string webSocketPort): base(MetatraderClientType.MT4, webSocketPort)
    {
    }

    public async Task<Account> GetAccountInfoAsync()
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/account";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponse<Account>(_request);
    }

    public async Task<Indicator> GetATRValuesAsync(int period, int shift, string symbol, string timeframe)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/indicator/atr?symbol={symbol}&timeframe={timeframe}&period={period}&shift={shift}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponse<Indicator>(_request);
    }

    public async Task<Indicator> GetMAValuesAsync(string appliedPrice, string ma_Method, int ma_Period, int ma_Shift, string symbol, string timeframe)
    {
        string parameters = $"symbol={symbol}&timeframe={timeframe}&ma_period={ma_Period}&ma_shift={ma_Shift}&ma_method={ma_Method}&applied_price={appliedPrice}";
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/indicator/ma?{parameters}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponse<Indicator>(_request);
    }

    public async Task<Indicator> GetCustomIndicatorValuesAsync(string indicatorName, int mode, int shift, string symbol, string timeframe, string param1 = "", string param2 = "", string param3 = "", string param4 = "")
    {
        string parameters = $"symbol={symbol}&timeframe={timeframe}&indicator_name={indicatorName}&param1={param1}&param2={param2}&param3={param3}&param4={param4}&mode={mode}&shift={shift}";
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/indicator/custom?{parameters}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponse<Indicator>(_request);
    }

    public async Task<OrderInfo> GetOrderInfoAsync(long ticketNumber)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/order/info?ticket={ticketNumber}";
        _request = BuildHttpGetRequest(_requestedUri);

        return UpdateErrorDescription(await GetMTsocketApiResponse<OrderInfo>(_request));
    }

    public async Task<OrderList> GetOrderListAsync()
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/order/list";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponse<OrderList>(_request);
    }

    public async Task<OrderSendResponse> PlaceOrderAsync(string symbol, string orderType, double volume, double price = 0.0, double stopLoss = 0.0, double takeProfit = 0.0, int magic = 0, string comment = "", string expiration = "")
    {
        _requestedUri = BuildSendOrderUri(symbol, orderType, volume, price, stopLoss, takeProfit, magic, comment, expiration);
        _request = BuildHttpPostRequest(_requestedUri);

        return await GetMTsocketApiResponse<OrderSendResponse>(_request);
    }

    public async Task<OrderModifyResponse> ModifyOrderAsync(long ticketNumber, double stopLoss, double takeProfit = 0.0, double price = 0.0, string expiration = "")
    {
        _requestedUri = BuildModifyOrderUri(ticketNumber, stopLoss, takeProfit, price, expiration);
        _request = BuildHttpPostRequest(_requestedUri);

        return await GetMTsocketApiResponse<OrderModifyResponse>(_request);
    }

    public async Task<OrderCloseResponse> CloseOrderAsync(long ticketNumber, double volume = 0.0)
    {
        _requestedUri = BuildCloseOrderUri(ticketNumber, volume);
        _request = BuildHttpPostRequest(_requestedUri);

        return await GetMTsocketApiResponse<OrderCloseResponse>(_request);
    }

    public async Task<SymbolInformation> GetSymbolInformationAsync(string symbol)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/symbol/info?symbol={symbol}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponse<SymbolInformation>(_request);
    }

    public async Task<OrderHistory> GetOrderHistoryAsync(string fromDate, string toDate)
    {
        _requestedUri = $"{_partialURI}:{_webSocketPort}/v1/history/orders?from_date={fromDate}&to_date={toDate}";
        _request = BuildHttpGetRequest(_requestedUri);

        return await GetMTsocketApiResponse<OrderHistory>(_request);
    }

    /// <summary>
    /// Searches for new order ticket created when an order with the given ticket number was partially closed
    /// Returns 0 if no match found
    /// </summary>
    public async Task<long> FindNewTicketNumber(long ticketNumber)
    {
        try
        {
            string matchTicket = Convert.ToString(ticketNumber);
            long newTicketNumber = 0;

            OrderList orderList = await this.GetOrderListAsync();

            foreach (var trade in orderList.Trades)
            {
                if (trade.Comment is not null &&  trade.Comment.Contains(matchTicket))
                {
                    newTicketNumber = trade.Ticket;
                    break;
                }
            }

            return newTicketNumber;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            SetQueryResult(QueryStatus.Error, ex.Message);
            return 0;
        }
    }
}
