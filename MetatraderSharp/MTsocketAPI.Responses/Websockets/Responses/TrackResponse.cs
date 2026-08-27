using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
///  Response class for track prices, track ohlc, and track mbook
/// </summary>
public class TrackResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("SUCCESS")]
    public List<string> Success { get; set; } = new();

    [JsonProperty("FAILED")]
    public List<string> Fail { get; set; } = new();

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string? ErrorDescription { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
