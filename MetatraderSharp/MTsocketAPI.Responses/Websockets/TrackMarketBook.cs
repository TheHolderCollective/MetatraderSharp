using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.Common;

/// <summary>
/// https://www.mtsocketapi.com/restapi.html#/operations/TrackMBOOK
/// </summary>

public class MarketDepth : MTsocketApiResponseBase
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("MARKET_BOOK")]
    public List<MarketBook> MarketBook { get; set; } = new();
}
 
public class MarketBook : MTsocketApiResponseBase
{
    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("VOLUME")]
    public int Volume { get; set; }

    [JsonProperty("VOLUMEREAL")]
    public double VolumeReal { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }
}

