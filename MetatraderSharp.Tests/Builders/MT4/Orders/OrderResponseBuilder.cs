using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.Tests.Builders.MT4;

/// <summary>
/// Used to generate OrderSendResponse and OrderModifyResponse objects
/// </summary>
public class OrderResponseBuilder<T> where T : IOrderResponse, new()
{
    protected string _msg;
    protected long _ticket;
    protected int _errorID;
    protected string _errorDescription;

    public OrderResponseBuilder()
    {
        _msg = "ORDER_SEND";
        _ticket = 296644727;
        _errorID = 0;
        _errorDescription = "no error";
    }

    public OrderResponseBuilder<T> WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public OrderResponseBuilder<T> WithTicket(long newTicket)
    {
        this._ticket = newTicket;
        return this;
    }

    public OrderResponseBuilder<T> WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public OrderResponseBuilder<T> WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public T Build()
    {
        return new T()
        {
            Msg = _msg,
            Ticket = _ticket,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}
