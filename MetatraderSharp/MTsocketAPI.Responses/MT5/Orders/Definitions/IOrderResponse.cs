namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

internal interface IOrderResponse
{
    public string? Msg { get; set; }
    public long Ticket { get; set; }
    public string? Type { get; set; }
    public int RetCode { get; set; }
    public long Deal { get; set; }
    public long Order { get; set; }
    public double Volume { get; set; }
    public double Price { get; set; }
    public double Bid { get; set; }
    public double Ask { get; set; }
    public long RequestID { get; set; }
    public long RetCodeExternal { get; set; }
    public int ErrorID { get; set; }
    public string? ErrorDescription { get; set; }
}
