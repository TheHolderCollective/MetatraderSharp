using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class OrderInfo : MTsocketApiResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("OPENED")]
    public List<OpenedOrder> OpenedOrder { get; set; } = new();

    [JsonProperty("PENDING")]
    public List<PendingOrder> PendingOrder { get; set; } = new();
}