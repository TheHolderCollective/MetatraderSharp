using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.Tests.Builders.MT4;

public class OrderListBuilder
{
    private string _msg;
    private List<Trade> _trades;
    private int _errorID;
    private string _errorDescription;

    public OrderListBuilder()
    {
        _msg = "ORDER_LIST";
        _trades = new TradeListBuilder().Build();
        _errorID = 0;
        _errorDescription = "no error";
    }

    public OrderListBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public OrderListBuilder WithTrades(List<Trade> newTrades)
    {
        this._trades = newTrades;
        return this;
    }

    public OrderListBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public OrderListBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public OrderList Build()
    {
        return new OrderList()
        {
            Msg = _msg,
            Trades = _trades,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }

}
