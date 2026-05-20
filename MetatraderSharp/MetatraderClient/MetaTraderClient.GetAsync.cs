using MetatraderSharp.MTsocketAPI.Responses;
using Newtonsoft.Json;
namespace MetatraderSharp;

public partial class MetatraderClient
{
    private async Task<Account?> GetAccountInfoAsync()
    {
        try
        {
            var response = await _client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/account");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var account = (responseContent != null) ? JsonConvert.DeserializeObject<Account>(responseContent) : null;

            return account;
        }
        catch (Exception ex)
        {
            return new Account()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    private async Task<TerminalInfo> GetTerminalInfoAsync()
    {
        try
        {
            var response = await _client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/terminal");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var terminalInfo = (responseContent != null) ? JsonConvert.DeserializeObject<TerminalInfo>(responseContent) : null;

            return terminalInfo;
        }
        catch (Exception ex)
        {
            return new TerminalInfo()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

    private async Task<SymbolList> GetSymbolListResponseAsync()
    {
        try
        {
            var response = await _client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/symbol/list");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var terminalInfo = (responseContent != null) ? JsonConvert.DeserializeObject<SymbolList>(responseContent) : null;

            return terminalInfo;
        }
        catch (Exception ex)
        {
            return new SymbolList()
            {
                ErrorID = -1,
                ErrorDescription = ex.Message,
            };
        }
    }

}
