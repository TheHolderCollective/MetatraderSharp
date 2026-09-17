using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

/// <summary>
/// Builder class for OrderCloseResponse and OrderModifyResponse
/// </summary>
public class OrderResponseBuilder<T> where T : IOrderResponse, new()
{
    private string _msg;
    private long _ticket;
    private string _type;
    private int _retCode;
    private long _deal;
    private long _order;
    private double _volume;
    private double _price;
    private double _bid;
    private double _ask;
    private long _requestID;
    private long _retCodeExternal;
    private int _errorID;
    private string _errorDescription;

    public OrderResponseBuilder()
    {
        _msg = "ORDER_CLOSE";
        _ticket = 112115112;
        _type = "FULLY_CLOSED";
        _retCode = 10009;
        _deal = 0;
        _order = 112115130;
        _volume = 0.01;
        _price = 0;
        _bid = 0;
        _ask = 0;
        _requestID = 3038003655;
        _retCodeExternal = 0;
        _errorID = 0;
        _errorDescription = "The operation completed successfully";
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

    public OrderResponseBuilder<T> WithType(string newType)
    {
        this._type = newType;
        return this;
    }

    public OrderResponseBuilder<T> WithRetCode(int newRetCode)
    {
        this._retCode = newRetCode;
        return this;
    }

    public OrderResponseBuilder<T> WithDeal(long newDeal)
    {
        this._deal = newDeal;
        return this;
    }

    public OrderResponseBuilder<T> WithOrder(long newOrder)
    {
        this._order = newOrder;
        return this;
    }

    public OrderResponseBuilder<T> WithVolume(double newVolume)
    {
        this._volume = newVolume;
        return this;
    }

    public OrderResponseBuilder<T> WithPrice(double newPrice)
    {
        this._price = newPrice;
        return this;
    }

    public OrderResponseBuilder<T> WithBid(double newBid)
    {
        this._bid = newBid;
        return this;
    }

    public OrderResponseBuilder<T> WithAsk(double newAsk)
    {
        this._ask = newAsk;
        return this;
    }

    public OrderResponseBuilder<T> WithRequestID(long newRequestID)
    {
        this._requestID = newRequestID;
        return this;
    }

    public OrderResponseBuilder<T> WithRetCodeExternal(long newRetCodeExternal)
    {
        this._retCodeExternal = newRetCodeExternal;
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
            Type = _type,
            RetCode = _retCode,
            Deal = _deal,
            Order = _order,
            Volume = _volume,
            Price = _price,
            Bid = _bid,
            Ask = _ask,
            RequestID = _requestID,
            RetCodeExternal = _retCodeExternal,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}



