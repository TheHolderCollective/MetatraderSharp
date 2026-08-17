using MetatraderSharp.MTsocketAPI.Responses;
using MetatraderSharp.MTsocketAPI.Responses.MT5;
using Newtonsoft.Json;

namespace MetatraderSharp.MetatraderClient;

public partial class MT5Client : MetatraderClient
{
    public MT5Client() : base(MetatraderTerminalType.MT5)
    {
    }

    public async Task<Account> GetAccountInfoAsync()
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/account");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var account = (responseContent != null) ? JsonConvert.DeserializeObject<Account>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(account);

            SetQueryResult(account.ErrorID, account.ErrorDescription);
            return account;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new Account()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }
   
    public async Task<Calendar> GetCalendarAsync(string fromDate, string toDate, string countryCode = "", string currency = "")
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/calendar?from_date={fromDate}&to_date={toDate}&country_code={countryCode}&currency={currency}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var calendar = (responseContent != null) ? JsonConvert.DeserializeObject<Calendar>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(calendar);

            SetQueryResult(calendar.ErrorID, calendar.ErrorDescription);
            return calendar;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new Calendar()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }
   
    public async Task<TickHistory> GetTickHistoryAsync(string fromDate, string toDate, string symbol, string tickFlag)
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/history/ticks?symbol={symbol}&flags={tickFlag}&from_date={fromDate}&to_date={toDate}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var tickHistory = (responseContent != null) ? JsonConvert.DeserializeObject<TickHistory>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(tickHistory);

            SetQueryResult(tickHistory.ErrorID, tickHistory.ErrorDescription);
            return tickHistory;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new TickHistory()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }
    
    public async Task<OrderHistory> GetOrderHistoryAsync(string fromDate, string toDate, string mode)
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/history/orders?from_date={fromDate}&to_date={toDate}&mode={mode}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var orderHistory = (responseContent != null) ? JsonConvert.DeserializeObject<OrderHistory>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(orderHistory);

            SetQueryResult(orderHistory.ErrorID, orderHistory.ErrorDescription);
            return orderHistory;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new OrderHistory()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }
    
    public async Task<Indicator> GetATRValues(int period, int shift, string symbol, string timeframe)
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/indicator/atr?symbol={symbol}&timeframe={timeframe}&period={period}&shift={shift}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var atrIndicator = (responseContent != null) ? JsonConvert.DeserializeObject<Indicator>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(atrIndicator);

            SetQueryResult(atrIndicator.ErrorID, atrIndicator.ErrorDescription);
            return atrIndicator;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new Indicator()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }

    public async Task<Indicator> GetCustomIndicatorValues(string indicatorName, string symbol, string timeframe, int index, int count, string param1 = "", string param2 = "", string param3 = "", string param4 = "")
    {
        try
        {
            string requestUri = BuildGetCustomIndicatorValuesUri(indicatorName, symbol, timeframe, index, count, param1, param2, param3, param4);

            var response = await Client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var customIndicator = (responseContent != null) ? JsonConvert.DeserializeObject<Indicator>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(customIndicator);

            SetQueryResult(customIndicator.ErrorID, customIndicator.ErrorDescription);
            return customIndicator;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new Indicator()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }
    
    public async Task<Indicator> GetMAValues(string appliedPrice, string ma_Method, int ma_Period, int count, int ma_Shift, string symbol, string timeframe)
    {
        try
        {
            string parameters = $"symbol={symbol}&timeframe={timeframe}&ma_period={ma_Period}&ma_shift={ma_Shift}&ma_method={ma_Method}&applied_price={appliedPrice}&num={count}";

            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/indicator/ma?{parameters}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var maIndicator = (responseContent != null) ? JsonConvert.DeserializeObject<Indicator>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(maIndicator);

            SetQueryResult(maIndicator.ErrorID, maIndicator.ErrorDescription);
            return maIndicator;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new Indicator()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }
    
    public async Task<OrderSendResponse> PlaceOrderAsync(string symbol, string orderType, double volume, bool async = false, double price = 0.0, double stopLoss = 0.0, 
                                                         double takeProfit = 0.0, int magic = 0, string orderFillType = "", string comment = "", string expiration = "")
    {
        try
        {
            string uri = BuildSendOrderUri(symbol, orderType, volume, async, price, stopLoss, takeProfit, magic, orderFillType, comment, expiration);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
                Headers = { { "Accept", "application/json" } }
            };

            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var orderResponse = (responseContent != null) ? JsonConvert.DeserializeObject<OrderSendResponse>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(orderResponse);

            SetQueryResult(orderResponse.ErrorID, orderResponse.ErrorDescription);
            return orderResponse;

        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new OrderSendResponse()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }

    public async Task<OrderModifyResponse> ModifyOrderAsync(long ticketNumber, double stopLoss, double takeProfit = 0.0, double price = 0.0, bool async = false, string expiration = "")
    {
        try
        {
            string uri = BuildModifyOrderUri(ticketNumber, stopLoss, takeProfit, price, async, expiration);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
                Headers = { { "Accept", "application/json" } }
            };

            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var orderResponse = (responseContent != null) ? JsonConvert.DeserializeObject<OrderModifyResponse>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(orderResponse);

            SetQueryResult(orderResponse.ErrorID, orderResponse.ErrorDescription);
            return orderResponse;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new OrderModifyResponse()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }
    
    public async Task<OrderCloseResponse> CloseOrderAsync(long ticketNumber, double volume = 0.0, bool async = false)
    {
        try
        {
            string uri = BuildCloseOrderUri(ticketNumber, volume, async);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
                Headers = { { "Accept", "application/json" } }
            };

            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var orderResponse = (responseContent != null) ? JsonConvert.DeserializeObject<OrderCloseResponse>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(orderResponse);

            SetQueryResult(orderResponse.ErrorID, orderResponse.ErrorDescription);
            return orderResponse;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new OrderCloseResponse()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }

    public async Task<OrderList> GetOrderListAsync()
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/order/list");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var orderList = (responseContent != null) ? JsonConvert.DeserializeObject<OrderList>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(orderList);

            SetQueryResult(orderList.ErrorID, orderList.ErrorDescription);
            return orderList;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new OrderList()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }
    
    public async Task<OrderInfo> GetOrderInfoAsync(long ticketNumber)
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/order/info?ticket={ticketNumber}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            bool ticketNotFound = responseContent.Contains("\"ERROR_ID\":-1"); // this check needs to be done because exception isn't thrown when ticket isn't found

            if (ticketNotFound)
            {
                string message = "TICKET not found";

                SetQueryResult(QueryStatus.Error, message);
                return new OrderInfo()
                {
                    Msg = "ORDER_INFO",
                    ErrorID = QueryStatus.Error,
                    ErrorDescription = message
                };
            }

            var orderInfo = (responseContent != null) ? JsonConvert.DeserializeObject<OrderInfo>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(orderInfo);

            SetQueryResult(orderInfo.ErrorID, orderInfo.ErrorDescription);
            return orderInfo;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new OrderInfo()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }
   
    public async Task<SymbolInformation> GetSymbolInformationAsync(string symbol)
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/symbol/info?symbol={symbol}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var symbolInfo = (responseContent != null) ? JsonConvert.DeserializeObject<SymbolInformation>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(symbolInfo);

            SetQueryResult(symbolInfo.ErrorID, symbolInfo.ErrorDescription);
            return symbolInfo;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new SymbolInformation()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<TrackOrderEventsResponse> TrackOrderEventsAsync(bool enabled)
    {
        try
        {
            RequestedUri = $"{_partialURI}:{WebSocketPort}/v1/track/orders?enabled={enabled}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(RequestedUri),
                Headers =
                {
                    {"Accept","application/json" }
                }
            };

            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var requestResponse = (responseContent != null) ? JsonConvert.DeserializeObject<TrackOrderEventsResponse>(responseContent) : null;

            ArgumentNullException.ThrowIfNull(requestResponse);

            SetQueryResult(requestResponse.ErrorID, requestResponse.ErrorDescription);
            return requestResponse;

        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new TrackOrderEventsResponse()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message,
            };
        }

    }

    public async Task<TrackResponse> TrackMarketBookAsync(params string[] symbolList)
    {
        try
        {
            RequestedUri = BuildTrackMarketBookUri(symbolList);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(RequestedUri),
                Headers =
                {
                    {"Accept","application/json" }
                }
            };

            var response = await Client.SendAsync(request);
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
                ErrorDescription = ex.Message,
            };
        }
    }
}