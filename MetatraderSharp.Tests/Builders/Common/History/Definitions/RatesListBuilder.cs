using MetatraderSharp.MTsocketAPI.Responses.Common;

namespace MetatraderSharp.Tests.Builders;

public class RatesListBuilder
{
    private List<Rate> _rates;

    public RatesListBuilder()
    {
        _rates = new();
        _rates.Add(new RateBuilder().WithTime("2026.08.21 17:30:00").WithOpen(1.16723).WithHigh(1.16743).WithLow(1.16685).WithClose(1.16718).WithTickVolume(1408). Build());
        _rates.Add(new RateBuilder().WithTime("2026.08.21 17:15:00").WithOpen(1.16788).WithHigh(1.16808).WithLow(1.16724).WithClose(1.16724).WithTickVolume(936). Build());
        _rates.Add(new RateBuilder().WithTime("2026.08.21 17:00:00").WithOpen(1.16753).WithHigh(1.16818).WithLow(1.16735).WithClose(1.16789).WithTickVolume(1031). Build());
        _rates.Add(new RateBuilder().WithTime("2026.08.21 16:45:00").WithOpen(1.16788).WithHigh(1.16801).WithLow(1.16704).WithClose(1.16724).WithTickVolume(906). Build());
        _rates.Add(new RateBuilder().WithTime("2026.08.21 16:30:00").WithOpen(1.16714).WithHigh(1.16752).WithLow(1.16701).WithClose(1.16761).WithTickVolume(1397). Build());
    }

    public RatesListBuilder WithNoDefaultSymbols()
    {
        _rates.Clear();
        return this;
    }

    public RatesListBuilder WithRate(Rate newRate)
    {
        _rates.Add(newRate);
        return this;
    }

    public List<Rate> Build()
    {
        return _rates;
    }
}

