using MetatraderSharp.MTsocketAPI.Responses;
using Newtonsoft.Json;
namespace MetatraderSharp;

public partial class MetatraderClient
{
    private async Task<Account?> GetAccountInfoAsync()
    {
        var client = new HttpClient();

        var response = await client.GetAsync($"{PartialURI}:{WebSocketPort}/v1/account");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var account = (responseContent != null) ? JsonConvert.DeserializeObject<Account>(responseContent) : null;

        return account;
    }


}
