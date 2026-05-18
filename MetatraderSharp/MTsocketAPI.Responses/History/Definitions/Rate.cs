using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/HistoryPrices
/// </summary>
public class Rate
{
    [JsonProperty("TIME")]
    public string Time { get; set; }

    [JsonProperty("OPEN")]
    public double? Open { get; set; }

    [JsonProperty("HIGH")]
    public double? High { get; set; }

    [JsonProperty("LOW")]
    public double? Low { get; set; }

    [JsonProperty("CLOSE")]
    public double? Close { get; set; }

    [JsonProperty("REAL_VOLUME")]
    public int? RealVolume { get; set; }

    [JsonProperty("TICK_VOLUME")]
    public int? TickVolume { get; set; }

    [JsonProperty("SPREAD")]
    public int? Spread { get; set; }
}
