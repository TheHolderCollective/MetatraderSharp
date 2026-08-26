using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT4;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/OrderInfo
/// </summary>
public class OrderInfo
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("TRADES")]
    public Trade Trade { get; set; } = new();

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string? ErrorDescription { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
