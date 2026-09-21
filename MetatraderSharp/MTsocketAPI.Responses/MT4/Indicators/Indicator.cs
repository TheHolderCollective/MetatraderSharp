using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.MT4;

public class Indicator : MTsocketApiResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("DATA_VALUE")]
    public double DataValue { get; set; }
}
