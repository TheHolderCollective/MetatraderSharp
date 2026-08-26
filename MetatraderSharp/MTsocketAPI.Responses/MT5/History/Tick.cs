using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class Tick
{
    [JsonProperty("TIME")]
    public string? Time { get; set; }

    [JsonProperty("ASK")]
    public double Ask { get; set; }

    [JsonProperty("BID")]
    public double Bid { get; set; }

    [JsonProperty("FLAGS")]
    public int Flags { get; set; }

    [JsonProperty("LAST")]
    public double Last { get; set; }

    [JsonProperty("TIME_MSC")]
    public string? TimeMsc { get; set; }

    [JsonProperty("VOLUME")]
    public long Volume { get; set; }

    [JsonProperty("VOLUME_REAL")]
    public double VolumeReal { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

