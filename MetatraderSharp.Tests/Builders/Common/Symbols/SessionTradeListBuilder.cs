using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

public class SessionTradeListBuilder
{
    private List<SessionTrade> _sessionTrade;

    public SessionTradeListBuilder()
    {
        _sessionTrade = new();
    }

    public List<SessionTrade> Build()
    {
        _sessionTrade.Add(new SessionTradeBuilder().WithAllEmpty().WithMonday("00:00-23:59").Build());
        _sessionTrade.Add(new SessionTradeBuilder().WithAllEmpty().WithTuesday("00:00-23:59").Build());
        _sessionTrade.Add(new SessionTradeBuilder().WithAllEmpty().WithWednesday("00:00-23:59").Build());
        _sessionTrade.Add(new SessionTradeBuilder().WithAllEmpty().WithThursday("00:00-23:59").Build());
        _sessionTrade.Add(new SessionTradeBuilder().WithAllEmpty().WithFriday("00:00-23:59").Build());

        return _sessionTrade;
    }
}