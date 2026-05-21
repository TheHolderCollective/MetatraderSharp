using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/TrackPrices
/// </summary>
public class Response
{
    [JsonProperty("MSG")]
    public string Msg { get; set; }

    [JsonProperty("SUCCESS")]
    public List<string> Success { get; set; }

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string ErrorDescription { get; set; }
}
