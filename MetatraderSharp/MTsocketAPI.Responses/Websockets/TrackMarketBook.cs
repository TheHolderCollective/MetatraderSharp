using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
/// https://www.mtsocketapi.com/restapi.html#/operations/TrackMBOOK
/// </summary>

public class MarketDepth
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("MARKET_BOOK")]
    public List<MarketBook> MarketBook { get; set; } = new();

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
 
public class MarketBook
{
    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("VOLUME")]
    public int Volume { get; set; }

    [JsonProperty("VOLUMEREAL")]
    public double VolumeReal { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

