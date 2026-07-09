using Newtonsoft.Json;
using MetatraderSharp.MTsocketAPI.Responses;
using MetatraderSharp.MTsocketAPI.Responses.MT4;
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

    public async Task<SymbolList> GetSymbolListResponseAsync()
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
            SetQueryResult(-1, ex.Message);
            return new SymbolList()
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
            SetQueryResult(-1, ex.Message);
            return new PriceHistory()
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
}
