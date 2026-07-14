using MetatraderSharp.MTsocketAPI.Responses;
using MetatraderSharp.MTsocketAPI.Responses.MT4;
using Newtonsoft.Json;
namespace MetatraderSharp.MetatraderClient;

public class MT4Client : MetatraderClient
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
            SetQueryResult(-1, ex.Message);
            return new Account()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
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


    public async Task<TrackPricesResponse> TrackPricesAsync(TrackingCommand trackCommand, string symbol1 = "", string symbol2 = "", string symbol3 = "", string symbol4 = "", string symbol5 = "")
    {
        try
        {
            string symbols = "";

            switch (trackCommand)
            {
                case TrackingCommand.Start:
                    symbols = $"symbols={symbol1}&symbols={symbol2}&symbols={symbol3}&symbols={symbol4}&symbols={symbol5}";
                    break;
                case TrackingCommand.Stop:
                    symbols = $"symbols=";
                    break;
            }

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{_partialURI}:{WebSocketPort}/v1/track/prices?{symbols}"),
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
            SetQueryResult(-1, ex.Message);
            return new TrackPricesResponse()
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
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<Indicator> GetMAValues(string appliedPrice, string ma_Method, int ma_Period,int ma_Shift, string symbol, string timeframe)
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
            SetQueryResult(-1, ex.Message);
            return new Indicator()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<Indicator> GetCustomIndicatorValues(string indicatorName, int mode, int shift, string symbol,string timeframe, string param1 = "", string param2 = "", string param3 = "", string param4 = "")
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
            SetQueryResult(-1, ex.Message);
            return new Indicator()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
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
            SetQueryResult(-1, ex.Message);
            return new OrderHistory()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
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
                ErrorDescription = ex.Message,
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

                SetQueryResult(-1, message);
                return new OrderInfo()
                {
                    Msg = "ORDER_INFO",
                    ErrorID = -1,
                    ErrorDescription = message,
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
                ErrorDescription = ex.Message,
            };
        }
    }

}
