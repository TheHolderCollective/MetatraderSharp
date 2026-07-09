using MetatraderSharp.MTsocketAPI.Responses;
using MetatraderSharp.MTsocketAPI.Responses.MT5;
using Newtonsoft.Json;
namespace MetatraderSharp.MetatraderClient;

public class MT5Client: MetatraderClient
{
    public MT5Client() : base(MetatraderTerminalType.MT5)
    {
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
