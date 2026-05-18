using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/OrderList
/// </summary>
public class Trade
{
    [JsonProperty("SYMBOL")]
    public string Symbol { get; set; }

    [JsonProperty("MAGIC")]
    public int? Magic { get; set; }

    [JsonProperty("TICKET")]
    public int? Ticket { get; set; }

    [JsonProperty("OPEN_TIME")]
    public string OpenTime { get; set; }

    [JsonProperty("CLOSE_TIME")]
    public string CloseTime { get; set; }

    [JsonProperty("PRICE_OPEN")]
    public double? PriceOpen { get; set; }

    [JsonProperty("PRICE_CLOSE")]
    public double? PriceClose { get; set; }

    [JsonProperty("TYPE")]
    public string Type { get; set; }

    [JsonProperty("LOTS")]
    public double? Lots { get; set; }

    [JsonProperty("STOP_LOSS")]
    public int? StopLoss { get; set; }

    [JsonProperty("TAKE_PROFIT")]
    public int? TakeProfit { get; set; }

    [JsonProperty("SWAP")]
    public int? Swap { get; set; }

    [JsonProperty("COMMISSION")]
    public int? Commission { get; set; }

    [JsonProperty("COMMENT")]
    public object Comment { get; set; }

    [JsonProperty("PROFIT")]
    public double? Profit { get; set; }

    [JsonProperty("EXPIRATION")]
    public string Expiration { get; set; }
}
