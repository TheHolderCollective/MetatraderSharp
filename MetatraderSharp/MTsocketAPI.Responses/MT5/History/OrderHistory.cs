using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class OrderHistory : MTsocketApiResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("MODE")]
    public string? Mode { get; set; }

    [JsonProperty("ORDERS")]
    public List<Order> Orders { get; set; } = new();

    [JsonProperty("DEALS")]
    public List<Deal> Deals { get; set; } = new();

    [JsonProperty("POSITIONS")]
    public List<Position> Positions { get; set; } = new();

    [JsonProperty("ORDERS_DEALS")]
    public List<OrdersDeals> OrdersDeals { get; set; } = new();
}





