using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.Common;

/// <summary>
///  Response class for track prices, track ohlc, and track mbook
/// </summary>
public class TrackResponse : MTsocketApiResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("SUCCESS")]
    public List<string>? Success { get; set; } = new();

    [JsonProperty("FAILED")]
    public List<string>? Fail { get; set; } = new();
}
