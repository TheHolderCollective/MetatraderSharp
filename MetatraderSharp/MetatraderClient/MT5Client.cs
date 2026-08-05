using MetatraderSharp.MTsocketAPI.Responses;
using MetatraderSharp.MTsocketAPI.Responses.MT5;
using Newtonsoft.Json;
namespace MetatraderSharp.MetatraderClient;

public class MT5Client: MetatraderClient
{
    public MT5Client() : base(MetatraderTerminalType.MT5)
    {
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
