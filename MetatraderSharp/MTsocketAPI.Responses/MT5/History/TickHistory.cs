using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class TickHistory : MTsocketApiResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("TICKS")]
    public List<Tick> Ticks { get; set; } = new();
}
