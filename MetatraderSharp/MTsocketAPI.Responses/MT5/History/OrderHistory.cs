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

    [JsonProperty("DEMO")]
    public string? Demo { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

public class Order
{
    [JsonProperty("TIME_SETUP")]
    public string? TimeSetup { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("TICKET")]
    public long Ticket { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    [JsonProperty("VOLUME_INITIAL")]
    public double VolumeInitial { get; set; }

    [JsonProperty("VOLUME_CURRENT")]
    public double VolumeCurrent { get; set; }

    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("SL")]
    public double StopLoss { get; set; }

    [JsonProperty("TP")]
    public double TakeProfit { get; set; }

    [JsonProperty("STATE")]
    public string? State { get; set; }

    [JsonProperty("MAGIC")]
    public int Magic { get; set; }

    [JsonProperty("COMMENT")]
    public string? Comment { get; set; }

    [JsonProperty("TIME_DONE")]
    public string? TimeDone { get; set; }

    [JsonProperty("POSITION")]
    public long Position { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

public class Deal
{
    [JsonProperty("TIME")]
    public string? Time { get; set; }

    [JsonProperty("DEAL")]
    public long DealNumber { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("ORDER")]
    public long Order { get; set; }

    [JsonProperty("POSITION")]
    public long Position { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    [JsonProperty("REASON")]
    public string? Reason { get; set; }

    [JsonProperty("DIRECTION")]
    public string? Direction { get; set; }

    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }

    [JsonProperty("SL")]
    public double StopLoss { get; set; }

    [JsonProperty("TP")]
    public double TakeProfit { get; set; }

    [JsonProperty("COMMISSION")]
    public double Commission { get; set; }

    [JsonProperty("PROFIT")]
    public double Profit { get; set; }

    [JsonProperty("SWAP")]
    public double Swap { get; set; }

    [JsonProperty("MAGIC")]
    public int Magic { get; set; }

    [JsonProperty("COMMENT")]
    public string? Comment { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

public class Position
{
    [JsonProperty("OPEN_TIME")]
    public string? OpenTime { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("TICKET")]
    public long Ticket { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }

    [JsonProperty("PRICE_OPEN")]
    public double PriceOpen { get; set; }

    [JsonProperty("MAGIC")]
    public int Magic { get; set; }

    [JsonProperty("CLOSE_TIME")]
    public string? CloseTime { get; set; }

    [JsonProperty("PRICE_CLOSE")]
    public double PriceClose { get; set; }

    [JsonProperty("PROFIT")]
    public double Profit { get; set; }

    [JsonProperty("COMMISSION")]
    public double Commission { get; set; }

    [JsonProperty("SWAP")]
    public double Swap { get; set; }

    [JsonProperty("SL")]
    public double StopLoss { get; set; }

    [JsonProperty("TP")]
    public double TakeProfit { get; set; }

    [JsonProperty("CHANGE")]
    public double Change { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

public class OrdersDeals
{
    [JsonProperty("TIME")]
    public string? Time { get; set; }

    [JsonProperty("TICKET")]
    public long Ticket { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }

    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("MAGIC")]
    public int Magic { get; set; }

    [JsonProperty("COMMENT")]
    public string? Comment { get; set; }

    [JsonProperty("DEALS")]
    public List<OrderDeal> Deals { get; set; } = new();

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

public class OrderDeal 
{
    [JsonProperty("TIME")]
    public string? Time { get; set; }

    [JsonProperty("TICKET")]
    public long Ticket { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    [JsonProperty("REASON")]
    public string? Reason { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }

    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("COMMISSION")]
    public double Commission { get; set; }

    [JsonProperty("PROFIT")]
    public double Profit { get; set; }

    [JsonProperty("SWAP")]
    public double Swap { get; set; }

    [JsonProperty("MAGIC")]
    public int Magic { get; set; }

    [JsonProperty("COMMENT")]
    public string? Comment { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}


