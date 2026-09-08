using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.Tests.Builders.MT4;

public class OrderHistoryBuilder
{
    private string _msg;
    private List<Trade> _trades;
    private int _errorID;
    private string _errorDescription;

    public OrderHistoryBuilder()
    {
        _msg = "TRADE_HISTORY";
        _trades = new TradeListBuilder().Build();
        _errorID = 0;
        _errorDescription = "no error";
    }

    public OrderHistoryBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public OrderHistoryBuilder WithTrades(List<Trade> newTrades)
    {
        this._trades = newTrades;
        return this;
    }

    public OrderHistoryBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public OrderHistoryBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public OrderHistory Build()
    {
        return new OrderHistory()
        {
            Msg = _msg,
            Trades = _trades,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}
