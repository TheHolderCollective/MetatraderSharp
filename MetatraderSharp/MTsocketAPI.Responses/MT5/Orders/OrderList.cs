using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class OrderList
{
    [JsonProperty("MSG")]
    public string Msg { get; set; }

    [JsonProperty("COUNT")]
    public int Count { get; set; }

    [JsonProperty("OPENED")]
    public List<OpenedOrder> OpenedOrders { get; set; }

    [JsonProperty("PENDING")]
    public List<PendingOrder> PendingOrders { get; set; }

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string ErrorDescription { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}


