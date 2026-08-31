using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

/// <summary>
/// https://www.mtsocketapi.com/restapi.html#/operations/OrderSend
/// </summary>
public class OrderSendResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    [JsonProperty("RETCODE")]
    public int RetCode { get; set; }

    [JsonProperty("DEAL")]
    public long Deal { get; set; }

    [JsonProperty("ORDER")]
    public long Order { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }

    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("BID")]
    public double Bid { get; set; }

    [JsonProperty("ASK")]
    public double Ask { get; set; }

    [JsonProperty("REQUEST_ID")]
    public long RequestID { get; set; }

    [JsonProperty("RETCODE_EXTERNAL")]
    public int RetCodeExternal { get; set; }

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string? ErrorDescription { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

