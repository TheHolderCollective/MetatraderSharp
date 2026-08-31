using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class OrderDeal
{
    [JsonProperty("TIME")]
    public string? Time { get; set; }

    [JsonProperty("TICKET")]
    public long Ticket { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    [JsonProperty("REASON")]
    public string? Reason { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }

    [JsonProperty("PRICE")]
    public double Price { get; set; }

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


