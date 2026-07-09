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

    public async Task<AverageTrueRangeIndicator> GetATRValues(int period, int shift, string symbol, string timeframe)
    {
        try
        {
            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/indicator/atr?symbol={symbol}&timeframe={timeframe}&period={period}&shift={shift}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var atrIndicator = (responseContent != null) ? JsonConvert.DeserializeObject<AverageTrueRangeIndicator>(responseContent) : null;

            SetQueryResult(atrIndicator.ErrorID, atrIndicator.ErrorDescription);
            return atrIndicator;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new AverageTrueRangeIndicator()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<MovingAverageIndicator> GetMAValues(string appliedPrice, string ma_Method, int ma_Period,int ma_Shift, string symbol, string timeframe)
    {
        try
        {
            string parameters = $"symbol={symbol}&timeframe={timeframe}&ma_period={ma_Period}&ma_shift={ma_Shift}&ma_method={ma_Method}&applied_price={appliedPrice}";

            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/indicator/ma?{parameters}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var maIndicator = (responseContent != null) ? JsonConvert.DeserializeObject<MovingAverageIndicator>(responseContent) : null;

            SetQueryResult(maIndicator.ErrorID, maIndicator.ErrorDescription);
            return maIndicator;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new MovingAverageIndicator()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    public async Task<CustomIndicator> GetCustomIndicatorValues(string indicatorName, int mode, int shift, string symbol,string timeframe, string param1 = "", string param2 = "", string param3 = "", string param4 = "")
    {
        try
        {
            string parameters = $"symbol={symbol}&timeframe={timeframe}&indicator_name={indicatorName}&param1={param1}&param2={param2}&param3={param3}&param4={param4}&mode={mode}&shift={shift}";

            var response = await Client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/indicator/custom?{parameters}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var customIndicator = (responseContent != null) ? JsonConvert.DeserializeObject<CustomIndicator>(responseContent) : null;

            SetQueryResult(customIndicator.ErrorID, customIndicator.ErrorDescription);
            return customIndicator;
        }
        catch (Exception ex)
        {
            SetQueryResult(-1, ex.Message);
            return new CustomIndicator()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }


}
