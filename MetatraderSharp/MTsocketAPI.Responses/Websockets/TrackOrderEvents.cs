using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses;

public class TrackOrderEvents
{
    [JsonProperty("MSG")]
    public string Msg { get; set; }

    [JsonProperty("TRADE_TRANSACTION")]
    public TradeTransaction TradeTransaction { get; set; }

    [JsonProperty("TRADE_REQUEST")]
    public TradeRequest TradeRequest { get; set; }

    [JsonProperty("TRADE_RESULT")]
    public TradeResult TradeResult { get; set; }

    [JsonProperty("DEMO")]
    public string Demo { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

public class TradeRequest
{
    [JsonProperty("ACTION")]
    public string Action { get; set; }

    [JsonProperty("COMMENT")]
    public string Comment { get; set; }

    [JsonProperty("DEVIATION")]
    public double Deviation { get; set; }

    [JsonProperty("EXPIRATION")]
    public string Expiration { get; set; }

    [JsonProperty("MAGIC")]
    public int Magic { get; set; }

    [JsonProperty("ORDER")]
    public long Order { get; set; }

    [JsonProperty("POSITION")]
    public int Position { get; set; }

    [JsonProperty("POSITION_BY")]
    public int PositionBy { get; set; }

    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("SL")]
    public double StopLoss { get; set; }

    [JsonProperty("STOPLIMIT")]
    public double StopLimit { get; set; }

    [JsonProperty("SYMBOL")]
    public string Symbol { get; set; }

    [JsonProperty("TP")]
    public double TakeProfit { get; set; }

    [JsonProperty("TYPE")]
    public string Type { get; set; }

    [JsonProperty("TYPE_FILLING")]
    public string TypeFilling { get; set; }

    [JsonProperty("TYPE_TIME")]
    public string TypeTime { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

public class TradeResult
{
    [JsonProperty("ASK")]
    public double Ask { get; set; }

    [JsonProperty("BID")]
    public double Bid { get; set; }

    [JsonProperty("COMMENT")]
    public string Comment { get; set; }

    [JsonProperty("DEAL")]
    public long Deal { get; set; }

    [JsonProperty("ORDER")]
    public long Order { get; set; }

    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("REQUEST_ID")]
    public long RequestID { get; set; }

    [JsonProperty("RETCODE")]
    public int RetCode { get; set; }

    [JsonProperty("RETCODE_EXTERNAL")]
    public int RetCodeExternal { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

public class TradeTransaction
{
    [JsonProperty("DEAL")]
    public long Deal { get; set; }

    [JsonProperty("DEAL_TYPE")]
    public string DealType { get; set; }

    [JsonProperty("ORDER")]
    public long Order { get; set; }

    [JsonProperty("ORDER_STATE")]
    public string OrderState { get; set; }

    [JsonProperty("ORDER_TYPE")]
    public string OrderType { get; set; }

    [JsonProperty("POSITION")]
    public int Position { get; set; }

    [JsonProperty("POSITION_BY")]
    public int PositionBy { get; set; }

    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("PRICE_SL")]
    public double PriceStopLoss { get; set; }

    [JsonProperty("PRICE_TP")]
    public double PriceTakeProfit { get; set; }

    [JsonProperty("PRICE_TRIGGER")]
    public double PriceTrigger { get; set; }

    [JsonProperty("SYMBOL")]
    public string Symbol { get; set; }

    [JsonProperty("TIME_EXPIRATION")]
    public string TimeExpiration { get; set; }

    [JsonProperty("TIME_TYPE")]
    public string TimeType { get; set; }

    [JsonProperty("TYPE")]
    public string Type { get; set; }

    [JsonProperty("VOLUME")]
    public double Volume { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

