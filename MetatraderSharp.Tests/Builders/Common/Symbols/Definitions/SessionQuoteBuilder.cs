using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

public class SessionQuoteBuilder
{
    private string _monday;
    private string _tuesday;
    private string _wednesday;
    private string _thursday;
    private string _friday;

    public SessionQuoteBuilder()
    {
        _monday = "00:00-23:59";
        _tuesday = "";
        _wednesday = "";
        _thursday = "";
        _friday = "";
    }

    public SessionQuoteBuilder WithMonday(string newMonday)
    {
        this._monday = newMonday;
        return this;
    }

    public SessionQuoteBuilder WithTuesday(string newTuesday)
    {
        this._tuesday = newTuesday;
        return this;
    }

    public SessionQuoteBuilder WithWednesday(string newWednesday)
    {
        this._wednesday = newWednesday;
        return this;
    }

    public SessionQuoteBuilder WithThursday(string newThursday)
    {
        this._thursday = newThursday;
        return this;
    }

    public SessionQuoteBuilder WithFriday(string newFriday)
    {
        this._friday = newFriday;
        return this;
    }

    public SessionQuoteBuilder WithAllEmpty()
    {
        _monday = "";
        _tuesday = "";
        _wednesday = "";
        _thursday = "";
        _friday = "";

        return this;
    }

    public SessionQuote Build()
    {
        return new SessionQuote()
        {
            Monday = _monday,
            Tuesday = _tuesday,
            Wednesday = _wednesday,
            Thursday = _thursday,
            Friday = _friday,
        };
    }

}
