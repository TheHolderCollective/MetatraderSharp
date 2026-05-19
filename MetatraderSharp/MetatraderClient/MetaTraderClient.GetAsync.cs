using MetatraderSharp.MTsocketAPI.Responses;
using Newtonsoft.Json;
namespace MetatraderSharp;

public partial class MetatraderClient
{
    private async Task<Account?> GetAccountInfoAsync()
    {
        var response = await _client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/account");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var account = (responseContent != null) ? JsonConvert.DeserializeObject<Account>(responseContent) : null;

        return account;
    }

    private async Task<TerminalInfo> GetTerminalInfoAsync()
    {
        var response = await _client.GetAsync($"{_partialURI}:{WebSocketPort}/v1/terminal");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var terminalInfo = (responseContent != null) ? JsonConvert.DeserializeObject<TerminalInfo>(responseContent) : null;

        return terminalInfo;

    }





}
