using MetatraderSharp.MTsocketAPI.Responses;
using MetatraderSharp.MTsocketAPI.Responses.MT5;
using Newtonsoft.Json;
namespace MetatraderSharp.MetatraderClient;

public partial class MT5Client : MetatraderClient
{
    public MT5Client() : base(MetatraderTerminalType.MT5)
    {
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

                SetQueryResult(-1, message);
                return new OrderInfo()
                {
                    Msg = "ORDER_INFO",
                    ErrorID = -1,
                    ErrorDescription = message
                };
            }

            var orderInfo = (responseContent != null) ? JsonConvert.DeserializeObject<OrderInfo>(responseContent) : null;

            SetQueryResult(orderInfo.ErrorID, orderInfo.ErrorDescription);
            return orderInfo;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new OrderInfo()
            {
                ErrorID = -1,
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
            SetQueryResult(-1, ex.Message);
            return new OrderList()
            {
                ErrorID = -1,
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

            SetQueryResult(orderHistory.ErrorID, orderHistory.ErrorDescription);
            return orderHistory;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new OrderHistory()
            {
                ErrorID = -1,
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

            SetQueryResult(tickHistory.ErrorID, tickHistory.ErrorDescription);
            return tickHistory;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new TickHistory()
            {
                ErrorID = -1,
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

            SetQueryResult(calendar.ErrorID, calendar.ErrorDescription);
            return calendar;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new Calendar()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message
            };
        }
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
            SetQueryResult(-1, ex.Message);
            return new Account()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message
            };
        }
    }

    public async Task<SymbolInformation> GetSymbolInformationResponseAsync(string symbol)
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
            SetQueryResult(-1, ex.Message);
            return new SymbolInformation()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
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
            SetQueryResult(-1, ex.Message);
            return new Indicator()
            {
                ErrorID = -1,
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

            SetQueryResult(maIndicator.ErrorID, maIndicator.ErrorDescription);
            return maIndicator;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new Indicator()
            {
                ErrorID = -1,
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

            SetQueryResult(customIndicator.ErrorID, customIndicator.ErrorDescription);
            return customIndicator;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new Indicator()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message
            };
        }
    }


}
