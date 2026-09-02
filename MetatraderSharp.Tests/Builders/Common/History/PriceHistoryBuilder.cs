using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

/// <summary>
/// Used to generate a PriceHistory object populated with data
/// </summary>
public class PriceHistoryBuilder
{
    private string _msg;
    private string _symbol;
    private string _timeFrame;
    private List<Rate> _rates;
    private int _errorID;
    private string _errorDescription;

    public PriceHistoryBuilder()
    {
        _msg = "PRICE_HISTORY";
        _symbol = "EURUSD";
        _timeFrame = "PERIOD_M15";
        _rates = new RatesListBuilder().Build();
        _errorID = 0;
        _errorDescription = "no error";
    }

    public PriceHistoryBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public PriceHistoryBuilder WithSymbol(string newSymbol)
    {
        this._symbol = newSymbol;
        return this;
    }

    public PriceHistoryBuilder WithTimeFrame(string newTimeFrame)
    {
        this._timeFrame = newTimeFrame;
        return this;
    }

    public PriceHistoryBuilder WithRates(List<Rate> newRates)
    {
        this._rates = newRates;
        return this;
    }

    public PriceHistoryBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public PriceHistoryBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public PriceHistory Build()
    {
        return new PriceHistory()
        {
            Msg = _msg,
            Symbol = _symbol,
            TimeFrame = _timeFrame,
            Rates = _rates,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}
