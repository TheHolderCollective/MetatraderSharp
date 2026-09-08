using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.Tests.Builders.MT4;

public class TradeListBuilder
{
    private List<Trade> _trades;

    public TradeListBuilder()
    {
        _trades = new();
        _trades.Add(new TradeBuilder().WithTicket(296629269).WithSymbol("USDCAD").WithLots(0.01).WithType("sell").WithPriceOpen(1.37842)
                                      .WithOpenTime("2026.09.08 22:51:20").WithProfit(-0.13).WithExpiration("1970.01.01 00:00:00").Build());
        _trades.Add(new TradeBuilder().WithTicket(296629041).WithSymbol("EURUSD").WithLots(0.01).WithType("buy").WithPriceOpen(1.16253)
                                      .WithOpenTime("2026.09.08 22:50:42").WithProfit(-0.14).WithExpiration("1970.01.01 00:00:00").Build());
    }

    public TradeListBuilder WithNoDefaultSymbols()
    {
        _trades.Clear();
        return this;
    }

    public TradeListBuilder WithRate(Trade newTrade)
    {
        _trades.Add(newTrade);
        return this;
    }

    public List<Trade> Build()
    {
        return _trades;
    }
}
