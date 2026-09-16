using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class OrderSendResponseBuilder
{
    private string _msg;
    private string _type;
    private int _retCode;
    private long _deal;
    private long _order;
    private double _volume;
    private double _price;
    private double _bid;
    private double _ask;
    private long _requestID;
    private int _retCodeExternal;
    private int _errorID;
    private string _errorDescription;

    public OrderSendResponseBuilder()
    {
        _msg = "ORDER_SEND";
        _type = "ORDER_TYPE_SELL";
        _retCode = 10009;
        _deal = 0;
        _order = 112109367;
        _volume = 0.01;
        _price = 0;
        _bid = 0;
        _ask = 0;
        _requestID = 3038003652;
        _retCodeExternal = 0;
        _errorID = 0;
        _errorDescription = "The operation completed successfully";
    }

    public OrderSendResponseBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public OrderSendResponseBuilder WithType(string newType)
    {
        this._type = newType;
        return this;
    }

    public OrderSendResponseBuilder WithRetCode(int newRetCode)
    {
        this._retCode = newRetCode;
        return this;
    }

    public OrderSendResponseBuilder WithDeal(long newDeal)
    {
        this._deal = newDeal;
        return this;
    }

    public OrderSendResponseBuilder WithOrder(long newOrder)
    {
        this._order = newOrder;
        return this;
    }

    public OrderSendResponseBuilder WithVolume(double newVolume)
    {
        this._volume = newVolume;
        return this;
    }

    public OrderSendResponseBuilder WithPrice(double newPrice)
    {
        this._price = newPrice;
        return this;
    }

    public OrderSendResponseBuilder WithBid(double newBid)
    {
        this._bid = newBid;
        return this;
    }

    public OrderSendResponseBuilder WithAsk(double newAsk)
    {
        this._ask = newAsk;
        return this;
    }

    public OrderSendResponseBuilder WithRequestID(long newRequestID)
    {
        this._requestID = newRequestID;
        return this;
    }

    public OrderSendResponseBuilder WithRetCodeExternal(int newRetCodeExternal)
    {
        this._retCodeExternal = newRetCodeExternal;
        return this;
    }

    public OrderSendResponseBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public OrderSendResponseBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public OrderSendResponse Build()
    {
        return new OrderSendResponse()
        {
            Msg = _msg,
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
