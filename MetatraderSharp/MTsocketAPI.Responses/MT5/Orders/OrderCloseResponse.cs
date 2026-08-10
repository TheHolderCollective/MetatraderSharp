using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

/// <summary>
/// https://www.mtsocketapi.com/restapi.html#/operations/OrderClose
/// </summary>
public class OrderCloseResponse
{
    [JsonProperty("MSG")]
    public string Msg { get; set; }

    [JsonProperty("TICKET")]
    public string Ticket { get; set; }

    [JsonProperty("TYPE")]
    public string Type { get; set; }

    [JsonProperty("RETCODE")]
    public int RetCode { get; set; }

    [JsonProperty("DEAL")]
    public int Deal { get; set; }

    [JsonProperty("ORDER")]
    public int Order { get; set; }

    [JsonProperty("VOLUME")]
    public int Volume { get; set; }

    [JsonProperty("PRICE")]
    public int Price { get; set; }

    [JsonProperty("BID")]
    public int Bid { get; set; }

    [JsonProperty("ASK")]
    public int Ask { get; set; }

    [JsonProperty("REQUEST_ID")]
    public int RequestID { get; set; }

    [JsonProperty("RETCODE_EXTERNAL")]
    public int RetCodeExternal { get; set; }

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string ErrorDescription { get; set; }

    [JsonProperty("DEMO")]
    public string Demo { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}





