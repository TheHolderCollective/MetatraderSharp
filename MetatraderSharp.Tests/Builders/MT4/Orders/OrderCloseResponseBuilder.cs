using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.Tests.Builders.MT4;

public class OrderCloseResponseBuilder: OrderResponseBuilder<OrderCloseResponse>
{
    private string? _type;

    public OrderCloseResponseBuilder()
    {
        _msg = "ORDER_CLOSE";
        _type = "FULLY_CLOSED";
    }

    public OrderCloseResponseBuilder WithType(string newType)
    {
        this._type = newType;
        return this;
    }

    public new OrderCloseResponse Build()
    {
        return new OrderCloseResponse()
        {
            Msg = _msg,
            Ticket = _ticket,
            Type = _type,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription
        };
    }
}
