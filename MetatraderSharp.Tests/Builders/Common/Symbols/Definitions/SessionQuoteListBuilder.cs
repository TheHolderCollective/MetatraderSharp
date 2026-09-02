using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

/// <summary>
/// Used to generate a list of SessionQuote objects
/// </summary>
public class SessionQuoteListBuilder
{
    private List<SessionQuote> _sessionQuote;

    public SessionQuoteListBuilder()
    {
        _sessionQuote = new();
    }

    public List<SessionQuote> Build()
    {
        _sessionQuote.Add(new SessionQuoteBuilder().WithAllEmpty().WithMonday("00:00-23:59").Build());
        _sessionQuote.Add(new SessionQuoteBuilder().WithAllEmpty().WithTuesday("00:00-23:59").Build());
        _sessionQuote.Add(new SessionQuoteBuilder().WithAllEmpty().WithWednesday("00:00-23:59").Build());
        _sessionQuote.Add(new SessionQuoteBuilder().WithAllEmpty().WithThursday("00:00-23:59").Build());
        _sessionQuote.Add(new SessionQuoteBuilder().WithAllEmpty().WithFriday("00:00-23:59").Build());

        return _sessionQuote;
    }
}

