using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class OpenedOrder
{
    [JsonProperty("TICKET")]
    public long Ticket { get; set; }

    [JsonProperty("OPEN_TIME")]
    public string? OpenTime { get; set; }

    [JsonProperty("TIME_UPDATE")]
    public string? TimeUpdate { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    [JsonProperty("MAGIC")]
    public int Magic { get; set; }

    [JsonProperty("IDENTIFIER")]
    public long Identifier { get; set; }

    [JsonProperty("REASON")]
    public int Reason { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }

    [JsonProperty("PRICE_OPEN")]
    public double PriceOpen { get; set; }

    [JsonProperty("SL")]
    public double StopLoss { get; set; }

    [JsonProperty("TP")]
    public double TakeProfit { get; set; }

    [JsonProperty("PRICE_CURRENT")]
    public double PriceCurrent { get; set; }

    [JsonProperty("SWAP")]
    public double Swap { get; set; }

    [JsonProperty("PROFIT")]
    public double Profit { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("COMMENT")]
    public string? Comment { get; set; }

    [JsonProperty("EXTERNAL_ID")]
    public string? ExternalID { get; set; }

    [JsonProperty("CHANGE")]
    public double Change { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}


