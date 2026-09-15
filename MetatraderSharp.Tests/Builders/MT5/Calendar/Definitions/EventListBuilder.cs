using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class EventListBuilder
{
    private List<Event> _events = [];

    public EventListBuilder()
    {
        _events.Add(new EventBuilder().Build());
    }

    public EventListBuilder WithNoEvents()
    {
        _events.Clear();
        return this;
    }

    public List<Event> Build()
    {
        return _events;
    }
}