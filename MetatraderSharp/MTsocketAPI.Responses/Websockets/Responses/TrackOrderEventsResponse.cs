using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
/// https://www.mtsocketapi.com/restapi.html#/operations/TrackOrderEvents
/// </summary>
public class TrackOrderEventsResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("ENABLED")]
    public bool Enabled { get; set; }

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string? ErrorDescription { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

