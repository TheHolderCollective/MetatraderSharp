namespace MetatraderSharp.MTsocketAPI.Responses.MT4;

public interface IOrderResponse
{
    public string? Msg { get; set; }
    public long Ticket { get; set; }
    public int ErrorID { get; set; }
    public string? ErrorDescription { get; set; }
}

