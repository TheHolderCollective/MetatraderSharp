using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

public class SessionTradeBuilder
{
    private string _monday;
    private string _tuesday;
    private string _wednesday;
    private string _thursday;
    private string _friday;

    public SessionTradeBuilder()
    {
        _monday = "00:00-23:59";
        _tuesday = "";
        _wednesday = "";
        _thursday = "";
        _friday = "";
    }

    public SessionTradeBuilder WithMonday(string newMonday)
    {
        this._monday = newMonday;
        return this;
    }

    public SessionTradeBuilder WithTuesday(string newTuesday)
    {
        this._tuesday = newTuesday;
        return this;
    }

    public SessionTradeBuilder WithWednesday(string newWednesday)
    {
        this._wednesday = newWednesday;
        return this;
    }

    public SessionTradeBuilder WithThursday(string newThursday)
    {
        this._thursday = newThursday;
        return this;
    }

    public SessionTradeBuilder WithFriday(string newFriday)
    {
        this._friday = newFriday;
        return this;
    }

    public SessionTradeBuilder WithAllEmpty()
    {
        _monday = "";
        _tuesday = "";
        _wednesday = "";
        _thursday = "";
        _friday = "";

        return this;
    }

    public SessionTrade Build()
    {
        return new SessionTrade()
        {
            Monday = _monday,
            Tuesday = _tuesday,
            Wednesday = _wednesday,
            Thursday = _thursday,
            Friday = _friday,
        };
    }

}
