using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

public class QuoteBuilder
{
    private string _msg;
    private string _symbol;
    private double _ask;
    private double _bid;
    private int _flags;
    private string? _time;
    private double _volume;
    private int _errorID;
    private string? _errorDescription;

    public QuoteBuilder()
    {
        _msg = "QUOTE";
        _symbol = "EURUSD";
        _ask = 1.16627;
        _bid = 1.1662;
        _flags = 6;
        _time = "2026.08.24 22:45:29.0";
        _volume = 0;
        _errorID = 0;
        _errorDescription = "no error";
    }

    public QuoteBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public QuoteBuilder WithSymbol(string newSymbol)
    {
        this._symbol = newSymbol;
        return this;
    }

    public QuoteBuilder WithAsk(double newAsk)
    {
        this._ask = newAsk;
        return this;
    }

    public QuoteBuilder WithBid(double newBid)
    {
        this._bid = newBid;
        return this;
    }

    public QuoteBuilder WithFlags(int newFlags)
    {
        this._flags = newFlags;
        return this;
    }

    public QuoteBuilder WithTime(string newTime)
    {
        this._time = newTime;
        return this;
    }

    public QuoteBuilder WithVolume(double newVolume)
    {
        this._volume = newVolume;
        return this;
    }

    public QuoteBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public QuoteBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public QuoteBuilder WithAllExceptMessageNull()
    {
        _msg = "QUOTE";
        _symbol = string.Empty;
        _ask = 0;
        _bid = 0;
        _flags = 0;
        _time = null;
        _volume = 0;
        _errorID = 0;
        _errorDescription = null;

        return this;
    }

    public Quote Build()
    {
        return new Quote()
        {
            Msg = _msg,
            Symbol = _symbol,
            Ask = _ask,
            Bid = _bid,
            Flags = _flags,
            Time = _time,
            Volume = _volume,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }

}
