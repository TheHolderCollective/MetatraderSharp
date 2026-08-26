using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT4;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/OrderClose
/// </summary>
public class OrderCloseResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("TICKET")]
    public long Ticket { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string? ErrorDescription { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
