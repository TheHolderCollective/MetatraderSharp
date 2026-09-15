using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class DealBuilder
{
    private string _time;
    private long _dealNumber;
    private string _symbol;
    private long _order;
    private long _position;
    private string _type;
    private string _reason;
    private string _direction;
    private double _price;
    private double _volume;
    private double _stopLoss;
    private double _takeProfit;
    private double _commission;
    private double _profit;
    private double _swap;
    private int _magic;
    private string _comment;

    public DealBuilder()
    {
        _time = "2026.09.02 07:20:05.528";
        _dealNumber = 78522301;
        _symbol = "EURUSD";
        _order = 99647050;
        _position = 99647050;
        _type = "BUY";
        _reason = "DEAL_REASON_CLIENT";
        _direction = "IN";
        _price = 1.1575;
        _volume = 0.01;
        _stopLoss = 0;
        _takeProfit = 0;
        _commission = 0;
        _profit = 0;
        _swap = 0;
        _magic = 0;
        _comment = "";
    }

    public DealBuilder WithTime(string newTime)
    {
        this._time = newTime;
        return this;
    }

    public DealBuilder WithDealNumber(long newDealNumber)
    {
        this._dealNumber = newDealNumber;
        return this;
    }

    public DealBuilder WithSymbol(string newSymbol)
    {
        this._symbol = newSymbol;
        return this;
    }

    public DealBuilder WithOrder(long newOrder)
    {
        this._order = newOrder;
        return this;
    }

    public DealBuilder WithPosition(long newPosition)
    {
        this._position = newPosition;
        return this;
    }

    public DealBuilder WithType(string newType)
    {
        this._type = newType;
        return this;
    }

    public DealBuilder WithReason(string newReason)
    {
        this._reason = newReason;
        return this;
    }

    public DealBuilder WithDirection(string newDirection)
    {
        this._direction = newDirection;
        return this;
    }

    public DealBuilder WithPrice(double newPrice)
    {
        this._price = newPrice;
        return this;
    }

    public DealBuilder WithVolume(double newVolume)
    {
        this._volume = newVolume;
        return this;
    }

    public DealBuilder WithStopLoss(double newStopLoss)
    {
        this._stopLoss = newStopLoss;
        return this;
    }

    public DealBuilder WithTakeProfit(double newTakeProfit)
    {
        this._takeProfit = newTakeProfit;
        return this;
    }

    public DealBuilder WithCommission(double newCommission)
    {
        this._commission = newCommission;
        return this;
    }

    public DealBuilder WithProfit(double newProfit)
    {
        this._profit = newProfit;
        return this;
    }

    public DealBuilder WithSwap(double newSwap)
    {
        this._swap = newSwap;
        return this;
    }

    public DealBuilder WithMagic(int newMagic)
    {
        this._magic = newMagic;
        return this;
    }

    public DealBuilder WithComment(string newComment)
    {
        this._comment = newComment;
        return this;
    }

    public Deal Build()
    {
        return new Deal()
        {
            Time = _time,
            DealNumber = _dealNumber,
            Symbol = _symbol,
            Order = _order,
            Position = _position,
            Type = _type,
            Reason = _reason,
            Direction = _direction,
            Price = _price,
            Volume = _volume,
            StopLoss = _stopLoss,
            TakeProfit = _takeProfit,
            Commission = _commission,
            Profit = _profit,
            Swap = _swap,
            Magic = _magic,
            Comment = _comment,
        };
    }
}
