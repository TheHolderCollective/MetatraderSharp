using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/HistoryOrders
/// </summary>
public class MT4OrderHistory
{
    [JsonProperty("MSG")]
    public string Msg { get; set; }

    [JsonProperty("TRADES")]
    public List<Trade> Trades { get; set; }

    [JsonProperty("ERROR_ID")]
    public int? ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string ErrorDescription { get; set; }
}

