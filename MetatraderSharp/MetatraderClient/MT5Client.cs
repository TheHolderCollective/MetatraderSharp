using MetatraderSharp.MTsocketAPI.Responses;
using MetatraderSharp.MTsocketAPI.Responses.MT5;
using Newtonsoft.Json;
namespace MetatraderSharp.MetatraderClient;

public class MT5Client: MetatraderClient
{
    public MT5Client() : base(MetatraderTerminalType.MT5)
    {
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

    public async Task<Calendar> GetCalendarAsync(string fromDate, string toDate, string countryCode="", string currency="")
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

}
