using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class TickBuilder
{
    private string _time;
    private double _ask;
    private double _bid;
    private int _flags;
    private double _last;
    private string _timeMsc;
    private long _volume;
    private double _volumeReal;

    public TickBuilder()
    {
        _time = "2026.09.11 20:05:01";
        _ask = 1.15967;
        _bid = 1.15967;
        _flags = 1154;
        _last = 0;
        _timeMsc = "2026.09.11 20:05:01.079";
        _volume = 0;
        _volumeReal = 0;
    }

    public TickBuilder WithTime(string newTime)
    {
        this._time = newTime;
        return this;
    }

    public TickBuilder WithAsk(double newAsk)
    {
        this._ask = newAsk;
        return this;
    }

    public TickBuilder WithBid(double newBid)
    {
        this._bid = newBid;
        return this;
    }

    public TickBuilder WithFlags(int newFlags)
    {
        this._flags = newFlags;
        return this;
    }

    public TickBuilder WithLast(double newLast)
    {
        this._last = newLast;
        return this;
    }

    public TickBuilder WithTimeMsc(string newTimeMsc)
    {
        this._timeMsc = newTimeMsc;
        return this;
    }

    public TickBuilder WithVolume(long newVolume)
    {
        this._volume = newVolume;
        return this;
    }

    public TickBuilder WithVolumeReal(double newVolumeReal)
    {
        this._volumeReal = newVolumeReal;
        return this;
    }

    public Tick Build()
    {
        return new Tick()
        {
            Time = _time,
            Ask = _ask,
            Bid = _bid,
            Flags = _flags,
            Last = _last,
            TimeMsc = _timeMsc,
            Volume = _volume,
            VolumeReal = _volumeReal,
        };
    }
}

