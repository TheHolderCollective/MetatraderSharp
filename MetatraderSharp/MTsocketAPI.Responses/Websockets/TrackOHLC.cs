using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/TrackOHLC
/// </summary>

public class TrackOHLC
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("PERIOD")]
    public string? Period { get; set; }

    [JsonProperty("OHLC")]
    public List<OHLC> OHLCs { get; set; } = new();

    [JsonProperty("DEMO")]
    public string? Demo { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

public class OHLC
{
    [JsonProperty("TIME")]
    public string? Time { get; set; }

    [JsonProperty("OPEN")]
    public double Open { get; set; }

    [JsonProperty("HIGH")]
    public double High { get; set; }

    [JsonProperty("LOW")]
    public double Low { get; set; }

    [JsonProperty("CLOSE")]
    public double Close { get; set; }

    [JsonProperty("TICK_VOLUME")]
    public int TickVolume { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}


