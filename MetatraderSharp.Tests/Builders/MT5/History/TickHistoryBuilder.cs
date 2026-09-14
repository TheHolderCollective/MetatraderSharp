using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class TickHistoryBuilder
{
    private string _msg;
    private string _symbol;
    private List<Tick> _ticks;
    private int _errorID;
    private string _errorDescription;

    public TickHistoryBuilder()
    {
        _msg = "TICK_HISTORY";
        _symbol = "EURUSD";
        _ticks = new TickListBuilder().Build();
        _errorID = 0;
        _errorDescription = "The operation completed successfully";
    }

    public TickHistoryBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public TickHistoryBuilder WithSymbol(string newSymbol)
    {
        this._symbol = newSymbol;
        return this;
    }

    public TickHistoryBuilder WithTicks(List<Tick> newTicks)
    {
        this._ticks = newTicks;
        return this;
    }

    public TickHistoryBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public TickHistoryBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public TickHistory Build()
    {
        return new TickHistory()
        {
            Msg = _msg,
            Symbol = _symbol,
            Ticks = _ticks,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}

