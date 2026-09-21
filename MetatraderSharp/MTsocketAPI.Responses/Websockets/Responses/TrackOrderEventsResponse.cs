using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.Common;

/// <summary>
/// https://www.mtsocketapi.com/restapi.html#/operations/TrackOrderEvents
/// </summary>
public class TrackOrderEventsResponse : MTsocketApiResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("ENABLED")]
    public bool Enabled { get; set; }
}

