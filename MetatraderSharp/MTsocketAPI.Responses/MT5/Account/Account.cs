using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

/// <summary>
/// https://www.mtsocketapi.com/restapi.html#/operations/AccountStatus
/// </summary>
public class Account
{
    [JsonProperty("MSG")]
    public string MSG { get; set; }

    [JsonProperty("COMPANY")]
    public string COMPANY { get; set; }

    [JsonProperty("CURRENCY")]
    public string CURRENCY { get; set; }

    [JsonProperty("NAME")]
    public string NAME { get; set; }

    [JsonProperty("SERVER")]
    public string SERVER { get; set; }

    [JsonProperty("LOGIN")]
    public int LOGIN { get; set; }

    [JsonProperty("TRADE_MODE")]
    public int TRADE_MODE { get; set; }

    [JsonProperty("LEVERAGE")]
    public int LEVERAGE { get; set; }

    [JsonProperty("LIMIT_ORDERS")]
    public int LIMIT_ORDERS { get; set; }

    [JsonProperty("MARGIN_SO_MODE")]
    public int MARGIN_SO_MODE { get; set; }

    [JsonProperty("TRADE_ALLOWED")]
    public int TRADE_ALLOWED { get; set; }

    [JsonProperty("TRADE_EXPERT")]
    public int TRADE_EXPERT { get; set; }

    [JsonProperty("MARGIN_MODE")]
    public int MARGIN_MODE { get; set; }

    [JsonProperty("CURRENCY_DIGITS")]
    public int CURRENCY_DIGITS { get; set; }

    [JsonProperty("FIFO_CLOSE")]
    public int FIFO_CLOSE { get; set; }

    [JsonProperty("HEDGE_ALLOWED")]
    public int HEDGE_ALLOWED { get; set; }

    [JsonProperty("BALANCE")]
    public double BALANCE { get; set; }

    [JsonProperty("CREDIT")]
    public int CREDIT { get; set; }

    [JsonProperty("PROFIT")]
    public double PROFIT { get; set; }

    [JsonProperty("EQUITY")]
    public double EQUITY { get; set; }

    [JsonProperty("MARGIN")]
    public double MARGIN { get; set; }

    [JsonProperty("MARGIN_FREE")]
    public double MARGIN_FREE { get; set; }

    [JsonProperty("MARGIN_LEVEL")]
    public double MARGIN_LEVEL { get; set; }

    [JsonProperty("MARGIN_SO_CAL")]
    public int MARGIN_SO_CAL { get; set; }

    [JsonProperty("MARGIN_SO_SO")]
    public int MARGIN_SO_SO { get; set; }

    [JsonProperty("ERROR_ID")]
    public int ERROR_ID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string ERROR_DESCRIPTION { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}


