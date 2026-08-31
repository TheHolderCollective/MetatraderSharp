using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class OrderHistory
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

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string? ErrorDescription { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}





