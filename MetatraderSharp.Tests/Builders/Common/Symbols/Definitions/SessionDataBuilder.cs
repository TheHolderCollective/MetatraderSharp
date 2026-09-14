using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

public class SessionDataBuilder<T> where T : ISessionData, new()
{
    private string? _monday;
    private string? _tuesday;
    private string? _wednesday;
    private string? _thursday;
    private string? _friday;

    public SessionDataBuilder()
    {
        _monday = "00:00-23:59";
        _tuesday = "";
        _wednesday = "";
        _thursday = "";
        _friday = "";
    }

    public SessionDataBuilder<T> WithMonday(string newMonday)
    {
        this._monday = newMonday;
        return this;
    }

    public SessionDataBuilder<T> WithTuesday(string newTuesday)
    {
        this._tuesday = newTuesday;
        return this;
    }

    public SessionDataBuilder<T> WithWednesday(string newWednesday)
    {
        this._wednesday = newWednesday;
        return this;
    }

    public SessionDataBuilder<T> WithThursday(string newThursday)
    {
        this._thursday = newThursday;
        return this;
    }

    public SessionDataBuilder<T> WithFriday(string newFriday)
    {
        this._friday = newFriday;
        return this;
    }

    public SessionDataBuilder<T> WithAllEmpty()
    {
        _monday = "";
        _tuesday = "";
        _wednesday = "";
        _thursday = "";
        _friday = "";

        return this;
    }

    public T Build()
    {
        return new T()
        {
            Monday = _monday,
            Tuesday = _tuesday,
            Wednesday = _wednesday,
            Thursday = _thursday,
            Friday = _friday,
        };
    }

}