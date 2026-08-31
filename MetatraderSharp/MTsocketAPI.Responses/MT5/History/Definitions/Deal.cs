using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class Deal
{
    [JsonProperty("TIME")]
    public string? Time { get; set; }

    [JsonProperty("DEAL")]
    public long DealNumber { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("ORDER")]
    public long Order { get; set; }

    [JsonProperty("POSITION")]
    public long Position { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    [JsonProperty("REASON")]
    public string? Reason { get; set; }

    [JsonProperty("DIRECTION")]
    public string? Direction { get; set; }

    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }

    [JsonProperty("SL")]
    public double StopLoss { get; set; }

    [JsonProperty("TP")]
    public double TakeProfit { get; set; }

    [JsonProperty("COMMISSION")]
    public double Commission { get; set; }

    [JsonProperty("PROFIT")]
    public double Profit { get; set; }

    [JsonProperty("SWAP")]
    public double Swap { get; set; }

    [JsonProperty("MAGIC")]
    public int Magic { get; set; }

    [JsonProperty("COMMENT")]
    public string? Comment { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
