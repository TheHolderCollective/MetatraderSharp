using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.Tests.Builders.MT4;

public class OrderCloseResponseBuilder
{
    private string _msg;
    private string? _type;
    private long _ticket;
    private int _errorID;
    private string _errorDescription;

    public OrderCloseResponseBuilder()
    {
        _msg = "ORDER_CLOSE";
        _type = "FULLY_CLOSED";
        _ticket = 296644727;
        _errorID = 0;
        _errorDescription = "no error";
    }

    public OrderCloseResponseBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public OrderCloseResponseBuilder WithTicket(long newTicket)
    {
        this._ticket = newTicket;
        return this;
    }

    public OrderCloseResponseBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public OrderCloseResponseBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }
    public OrderCloseResponseBuilder WithType(string? newType)
    {
        this._type = newType;
        return this;
    }

    public OrderCloseResponse Build()
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
