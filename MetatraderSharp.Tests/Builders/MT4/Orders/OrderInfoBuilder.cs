using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.Tests.Builders.MT4;

public class OrderInfoBuilder
{
    private string _msg;
    private Trade _trade;
    private int _errorID;
    private string _errorDescription;

    public OrderInfoBuilder()
    {
        _msg = "ORDER_INFO";
        _trade = new TradeBuilder().Build();
        _errorID = 0;
        _errorDescription = "no error";
    }

    public OrderInfoBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public OrderInfoBuilder WithTrade(Trade newTrade)
    {
        this._trade = newTrade;
        return this;
    }

    public OrderInfoBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public OrderInfoBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public OrderInfo Build()
    {
        return new OrderInfo()
        {
            Msg = _msg,
            Trade = _trade,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}
