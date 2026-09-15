using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class OrderBuilder
{
    private string _timeSetup;
    private string _symbol;
    private long _ticket;
    private string _type;
    private double _volumeInitial;
    private double _volumeCurrent;
    private double _price;
    private double _stopLoss;
    private double _takeProfit;
    private string _state;
    private int _magic;
    private string _comment;
    private string _timeDone;
    private long _position;

    public OrderBuilder()
    {
        _timeSetup = "2026.08.26 23:51:47.255";
        _symbol = "EURUSD";
        _ticket = 99647050;
        _type = "BUY LIMIT";
        _volumeInitial = 0.01;
        _volumeCurrent = 0;
        _price = 1.1575;
        _stopLoss = 0;
        _takeProfit = 0;
        _state = "filled";
        _magic = 0;
        _comment = "";
        _timeDone = "2026.09.02 07:20:05.528";
        _position = 99647050;
    }

    public OrderBuilder WithTimeSetup(string newTimeSetup)
    {
        this._timeSetup = newTimeSetup;
        return this;
    }

    public OrderBuilder WithSymbol(string newSymbol)
    {
        this._symbol = newSymbol;
        return this;
    }

    public OrderBuilder WithTicket(long newTicket)
    {
        this._ticket = newTicket;
        return this;
    }

    public OrderBuilder WithType(string newType)
    {
        this._type = newType;
        return this;
    }

    public OrderBuilder WithVolumeInitial(double newVolumeInitial)
    {
        this._volumeInitial = newVolumeInitial;
        return this;
    }

    public OrderBuilder WithVolumeCurrent(double newVolumeCurrent)
    {
        this._volumeCurrent = newVolumeCurrent;
        return this;
    }

    public OrderBuilder WithPrice(double newPrice)
    {
        this._price = newPrice;
        return this;
    }

    public OrderBuilder WithStopLoss(double newStopLoss)
    {
        this._stopLoss = newStopLoss;
        return this;
    }

    public OrderBuilder WithTakeProfit(double newTakeProfit)
    {
        this._takeProfit = newTakeProfit;
        return this;
    }

    public OrderBuilder WithState(string newState)
    {
        this._state = newState;
        return this;
    }

    public OrderBuilder WithMagic(int newMagic)
    {
        this._magic = newMagic;
        return this;
    }

    public OrderBuilder WithComment(string newComment)
    {
        this._comment = newComment;
        return this;
    }

    public OrderBuilder WithTimeDone(string newTimeDone)
    {
        this._timeDone = newTimeDone;
        return this;
    }

    public OrderBuilder WithPosition(long newPosition)
    {
        this._position = newPosition;
        return this;
    }

    public Order Build()
    {
        return new Order()
        {
            TimeSetup = _timeSetup,
            Symbol = _symbol,
            Ticket = _ticket,
            Type = _type,
            VolumeInitial = _volumeInitial,
            VolumeCurrent = _volumeCurrent,
            Price = _price,
            StopLoss = _stopLoss,
            TakeProfit = _takeProfit,
            State = _state,
            Magic = _magic,
            Comment = _comment,
            TimeDone = _timeDone,
            Position = _position,
        };
    }
}
