using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class TickListBuilder
{
    private List<Tick> _ticks;

    public TickListBuilder()
    {
        _ticks = new();
        _ticks.Add(new TickBuilder().WithTime("2026.09.11 20:05:01").WithAsk(1.15967).WithBid(1.15967).WithFlags(1154).WithTimeMsc("2026.09.11 20:05:01.079").Build());
        _ticks.Add(new TickBuilder().WithTime("2026.09.11 20:05:02").WithAsk(1.15966).WithBid(1.15966).WithFlags(1158).WithTimeMsc("2026.09.11 20:05:02.984").Build());
        _ticks.Add(new TickBuilder().WithTime("2026.09.11 20:05:03").WithAsk(1.15965).WithBid(1.15965).WithFlags(1158).WithTimeMsc("2026.09.11 20:05:03.090").Build());
    }

    public List<Tick> Build()
    {
        return _ticks;
    }
}

