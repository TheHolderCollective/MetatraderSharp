using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class OrderList : MTsocketApiResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("COUNT")]
    public int Count { get; set; }

    [JsonProperty("OPENED")]
    public List<OpenedOrder> OpenedOrders { get; set; } = new();

    [JsonProperty("PENDING")]
    public List<PendingOrder> PendingOrders { get; set; } = new();
}


