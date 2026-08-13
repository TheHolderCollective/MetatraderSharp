using MetatraderSharp.MTsocketAPI.Responses.MT4;
using Newtonsoft.Json;

namespace MetatraderSharp.MetatraderClient;

public partial class MT4Client : MetatraderClient
{
    public MT4Client() : base(MetatraderTerminalType.MT4)
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

    public async Task<Indicator> GetATRValues(int period, int shift, string symbol, string timeframe)
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/indicator/atr?symbol={symbol}&timeframe={timeframe}&period={period}&shift={shift}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var atrIndicator = (responseContent != null) ? JsonConvert.DeserializeObject<Indicator>(responseContent) : null;

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

    public async Task<Indicator> GetMAValues(string appliedPrice, string ma_Method, int ma_Period, int ma_Shift, string symbol, string timeframe)
    {
        try
        {
            string parameters = $"symbol={symbol}&timeframe={timeframe}&ma_period={ma_Period}&ma_shift={ma_Shift}&ma_method={ma_Method}&applied_price={appliedPrice}";

            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/indicator/ma?{parameters}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var maIndicator = (responseContent != null) ? JsonConvert.DeserializeObject<Indicator>(responseContent) : null;

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

    public async Task<Indicator> GetCustomIndicatorValues(string indicatorName, int mode, int shift, string symbol, string timeframe, string param1 = "", string param2 = "", string param3 = "", string param4 = "")
    {
        try
        {
            string parameters = $"symbol={symbol}&timeframe={timeframe}&indicator_name={indicatorName}&param1={param1}&param2={param2}&param3={param3}&param4={param4}&mode={mode}&shift={shift}";

            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/indicator/custom?{parameters}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var customIndicator = (responseContent != null) ? JsonConvert.DeserializeObject<Indicator>(responseContent) : null;

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
    
    public async Task<OrderList> GetOrderListAsync()
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/order/list");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var orderList = (responseContent != null) ? JsonConvert.DeserializeObject<OrderList>(responseContent) : null;

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

    /// <summary>
    /// Used to send market, limit or stop orders to the market.
    /// </summary>
    /// <param name="symbol">Symbol name (Check your broker's symbol name format)</param>
    /// <param name="orderType">Order type</param>
    /// <param name="volume">Order volume</param>
    /// <param name="price">Price for limit or stop orders</param>
    /// <param name="stopLoss">Stop loss</param>
    /// <param name="takeProfit">Take profit</param>
    /// <param name="magic">Order magic number</param>
    /// <param name="comment">Order comment</param>
    /// <param name="expiration">Order expiration time</param>
    /// <returns></returns>
    public async Task<OrderSendResponse> PlaceOrderAsync(string symbol, string orderType, double volume, double price = 0.0, double stopLoss = 0.0, double takeProfit = 0.0, int magic = 0, string comment = "", string expiration = "")
    {
        try
        {
            string uri = BuildSendOrderUri(symbol, orderType, volume, price, stopLoss, takeProfit, magic, comment, expiration);

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

    public async Task<OrderModifyResponse> ModifyOrderAsync(long ticketNumber, double stopLoss, double takeProfit = 0.0, double price = 0.0, string expiration = "")
    {
        try
        {
            string uri = BuildModifyOrderUri(ticketNumber, stopLoss, takeProfit, price, expiration);

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

    public async Task<OrderCloseResponse> CloseOrderAsync(long ticketNumber, double volume = 0.0)
    {
        try
        {
            string uri = $"{_partialURI}:{WebSocketPort}/v1/order/close?ticket={ticketNumber}";

            if (volume != 0.0)
            {
                uri = $"{_partialURI}:{WebSocketPort}/v1/order/close?ticket={ticketNumber}&volume={volume}";
            }

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

    public async Task<SymbolInformation> GetSymbolInformationAsync(string symbol)
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/symbol/info?symbol={symbol}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var symbolInfo = (responseContent != null) ? JsonConvert.DeserializeObject<SymbolInformation>(responseContent) : null;

            SetQueryResult(symbolInfo.ErrorID, symbolInfo.ErrorDescription);
            return symbolInfo;
        }
        catch (Exception ex)
        {
            SetQueryResult(QueryStatus.Error, ex.Message);
            return new SymbolInformation()
            {
                ErrorID = QueryStatus.Error,
                ErrorDescription = ex.Message
            };
        }
    }
    
    public async Task<OrderHistory> GetOrderHistoryAsync(string fromDate, string toDate)
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/history/orders?from_date={fromDate}&to_date={toDate}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var orderHistory = (responseContent != null) ? JsonConvert.DeserializeObject<OrderHistory>(responseContent) : null;

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
    
    /// <summary>
    /// Searches for new order ticket created when an order with the given ticket number was partially closed
    /// Returns 0 if no match found
    /// </summary>
    /// <returns></returns>
    public async Task<long> FindNewTicketNumber(long ticketNumber)
    {
        try
        {
            string matchTicket = Convert.ToString(ticketNumber);
            long newTicketNumber = 0;

            OrderList orderList = await this.GetOrderListAsync();

            foreach (var trade in orderList.Trades)
            {
                if (trade.Comment.Contains(matchTicket))
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
