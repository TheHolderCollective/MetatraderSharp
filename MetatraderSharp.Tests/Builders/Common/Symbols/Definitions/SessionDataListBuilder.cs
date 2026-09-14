using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

public class SessionDataListBuilder<T> where T : ISessionData, new()
{
    private List<T> _sessionQuote;

    public SessionDataListBuilder()
    {
        _sessionQuote = new();
    }

    public List<T> Build()
    {
        _sessionQuote.Add(new SessionDataBuilder<T>().WithAllEmpty().WithMonday("00:00-23:59").Build());
        _sessionQuote.Add(new SessionDataBuilder<T>().WithAllEmpty().WithTuesday("00:00-23:59").Build());
        _sessionQuote.Add(new SessionDataBuilder<T>().WithAllEmpty().WithWednesday("00:00-23:59").Build());
        _sessionQuote.Add(new SessionDataBuilder<T>().WithAllEmpty().WithThursday("00:00-23:59").Build());
        _sessionQuote.Add(new SessionDataBuilder<T>().WithAllEmpty().WithFriday("00:00-23:59").Build());

        return _sessionQuote;
    }
}
