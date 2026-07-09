using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class Tick
{
    [JsonProperty("TIME")]
    public string Time { get; set; }

    [JsonProperty("ASK")]
    public double Ask { get; set; }

    [JsonProperty("BID")]
    public double Bid { get; set; }

    [JsonProperty("FLAGS")]
    public int Flags { get; set; }

    [JsonProperty("LAST")]
    public int Last { get; set; }

    [JsonProperty("TIME_MSC")]
    public string TimeMsc { get; set; }

    [JsonProperty("VOLUME")]
    public int Volume { get; set; }

    [JsonProperty("VOLUME_REAL")]
    public int VolumeReal { get; set; }
}

