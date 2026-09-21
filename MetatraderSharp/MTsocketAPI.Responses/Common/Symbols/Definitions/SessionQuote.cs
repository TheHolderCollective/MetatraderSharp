using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.Common;

public class SessionQuote : ISessionData
{
    [JsonProperty("MONDAY")]
    public string? Monday { get; set; }

    [JsonProperty("TUESDAY")]
    public string? Tuesday { get; set; }

    [JsonProperty("WEDNESDAY")]
    public string? Wednesday { get; set; }

    [JsonProperty("THURSDAY")]
    public string? Thursday { get; set; }

    [JsonProperty("FRIDAY")]
    public string? Friday { get; set; }
}