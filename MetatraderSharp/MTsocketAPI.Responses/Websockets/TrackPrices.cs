using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.Common;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/TrackPrices
/// </summary>

public class TrackPrices : MTsocketApiResponseBase
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; } 

    [JsonProperty("TIME")]
    public string? Time { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("ASK")]
    public double Ask { get; set; }

    [JsonProperty("BID")]
    public double Bid { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }
}