using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.Common;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/Quote
/// </summary>
public class Quote : MTsocketApiResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("ASK")]
    public double Ask { get; set; }

    [JsonProperty("BID")]
    public double Bid { get; set; }

    [JsonProperty("FLAGS")]
    public int Flags { get; set; }

    [JsonProperty("TIME")]
    public string? Time { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }
}



