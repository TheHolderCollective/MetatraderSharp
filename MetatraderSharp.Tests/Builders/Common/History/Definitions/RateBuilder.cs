using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

/// <summary>
/// Used to generate a Rate object populated with data
/// </summary>
public class RateBuilder
{
    private string _time;
    private double _open;
    private double _high;
    private double _low;
    private double _close;
    private double _realVolume;
    private double _tickVolume;
    private double _spread;

    public RateBuilder()
    {
        _time = "2026.08.21 17:15:00";
        _open = 1.16788;
        _high = 1.16808;
        _low = 1.16724;
        _close = 1.16724;
        _realVolume = 0;
        _tickVolume = 936;
        _spread = 0;
    }

    public RateBuilder WithTime(string newTime)
    {
        this._time = newTime;
        return this;
    }

    public RateBuilder WithOpen(double newOpen)
    {
        this._open = newOpen;
        return this;
    }

    public RateBuilder WithHigh(double newHigh)
    {
        this._high = newHigh;
        return this;
    }

    public RateBuilder WithLow(double newLow)
    {
        this._low = newLow;
        return this;
    }

    public RateBuilder WithClose(double newClose)
    {
        this._close = newClose;
        return this;
    }

    public RateBuilder WithRealVolume(double newRealVolume)
    {
        this._realVolume = newRealVolume;
        return this;
    }

    public RateBuilder WithTickVolume(double newTickVolume)
    {
        this._tickVolume = newTickVolume;
        return this;
    }

    public RateBuilder WithSpread(double newSpread)
    {
        this._spread = newSpread;
        return this;
    }

    public Rate Build()
    {
        return new Rate()
        {
            Time = _time,
            Open = _open,
            High = _high,
            Low = _low,
            Close = _close,
            RealVolume = _realVolume,
            TickVolume = _tickVolume,
            Spread = _spread,
        };
    }
}
