using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class CalendarBuilder
{
    private string _msg;
    private List<Event> _events;
    private int _errorID;
    private string _errorDescription;

    public CalendarBuilder()
    {
        _msg = "CALENDAR_LIST";
        _events = new EventListBuilder().Build();
        _errorID = 0;
        _errorDescription = "The operation completed successfully";
    }

    public CalendarBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public CalendarBuilder WithEvents(List<Event> newEvents)
    {
        this._events = newEvents;
        return this;
    }

    public CalendarBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public CalendarBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public Calendar Build()
    {
        return new Calendar()
        {
            Msg = _msg,
            Events = _events,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}
