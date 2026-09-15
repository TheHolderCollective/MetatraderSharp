using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class PendingOrderBuilder
{
    private long _ticket;
    private string _openTime;
    private string _timeUpdate;
    private string _type;
    private int _magic;
    private long _identifier;
    private int _reason;
    private double _volume;
    private double _priceOpen;
    private double _stopLoss;
    private double _takeProfit;
    private double _priceCurrent;
    private double _swap;
    private double _profit;
    private string _symbol;
    private string _comment;
    private string _externalID;
    private double _change;
    private string _timeDone;
    private string _timeSetup;
    private int _orderReason;
    private long _positionID;
    private long _positionByID;
    private double _volumeInitial;
    private double _volumeCurrent;
    private double _priceStopLimit;

    public PendingOrderBuilder()
    {
        _ticket = 111173847;
        _openTime = "2026.09.02 07:20:05.528";
        _timeUpdate = "2026.09.02 07:20:05.528";
        _type = "ORDER_TYPE_SELL_LIMIT";
        _magic = 0;
        _identifier = 99647050;
        _reason = 0;
        _volume = 0.01;
        _priceOpen = 1.16801;
        _stopLoss = 0;
        _takeProfit = 0;
        _priceCurrent = 1.15375;
        _swap = -0.85;
        _profit = -3.75;
        _symbol = "EURUSD";
        _comment = "";
        _externalID = "";
        _change = -0.32;
        _timeDone = "1970.01.01 00:00:00.0";
        _timeSetup = "2026.09.15 21:07:32.138";
        _orderReason = 0;
        _positionID = 0;
        _positionByID = 0;
        _volumeInitial = 0.01;
        _volumeCurrent = 0.01;
        _priceStopLimit = 0;
    }

    public PendingOrderBuilder WithTicket(long newTicket)
    {
        this._ticket = newTicket;
        return this;
    }

    public PendingOrderBuilder WithOpenTime(string newOpenTime)
    {
        this._openTime = newOpenTime;
        return this;
    }

    public PendingOrderBuilder WithTimeUpdate(string newTimeUpdate)
    {
        this._timeUpdate = newTimeUpdate;
        return this;
    }

    public PendingOrderBuilder WithType(string newType)
    {
        this._type = newType;
        return this;
    }

    public PendingOrderBuilder WithMagic(int newMagic)
    {
        this._magic = newMagic;
        return this;
    }

    public PendingOrderBuilder WithIdentifier(long newIdentifier)
    {
        this._identifier = newIdentifier;
        return this;
    }

    public PendingOrderBuilder WithReason(int newReason)
    {
        this._reason = newReason;
        return this;
    }

    public PendingOrderBuilder WithVolume(double newVolume)
    {
        this._volume = newVolume;
        return this;
    }

    public PendingOrderBuilder WithPriceOpen(double newPriceOpen)
    {
        this._priceOpen = newPriceOpen;
        return this;
    }

    public PendingOrderBuilder WithStopLoss(double newStopLoss)
    {
        this._stopLoss = newStopLoss;
        return this;
    }

    public PendingOrderBuilder WithTakeProfit(double newTakeProfit)
    {
        this._takeProfit = newTakeProfit;
        return this;
    }

    public PendingOrderBuilder WithPriceCurrent(double newPriceCurrent)
    {
        this._priceCurrent = newPriceCurrent;
        return this;
    }

    public PendingOrderBuilder WithSwap(double newSwap)
    {
        this._swap = newSwap;
        return this;
    }

    public PendingOrderBuilder WithProfit(double newProfit)
    {
        this._profit = newProfit;
        return this;
    }

    public PendingOrderBuilder WithSymbol(string newSymbol)
    {
        this._symbol = newSymbol;
        return this;
    }

    public PendingOrderBuilder WithComment(string newComment)
    {
        this._comment = newComment;
        return this;
    }

    public PendingOrderBuilder WithExternalID(string newExternalID)
    {
        this._externalID = newExternalID;
        return this;
    }

    public PendingOrderBuilder WithChange(double newChange)
    {
        this._change = newChange;
        return this;
    }

    public PendingOrderBuilder WithTimeDone(string newTimeDone)
    {
        this._timeDone = newTimeDone;
        return this;
    }

    public PendingOrderBuilder WithTimeSetup(string newTimeSetup)
    {
        this._timeSetup = newTimeSetup;
        return this;
    }

    public PendingOrderBuilder WithOrderReason(int newOrderReason)
    {
        this._orderReason = newOrderReason;
        return this;
    }

    public PendingOrderBuilder WithPositionID(long newPositionID)
    {
        this._positionID = newPositionID;
        return this;
    }

    public PendingOrderBuilder WithPositionByID(long newPositionByID)
    {
        this._positionByID = newPositionByID;
        return this;
    }

    public PendingOrderBuilder WithVolumeInitial(double newVolumeInitial)
    {
        this._volumeInitial = newVolumeInitial;
        return this;
    }

    public PendingOrderBuilder WithVolumeCurrent(double newVolumeCurrent)
    {
        this._volumeCurrent = newVolumeCurrent;
        return this;
    }

    public PendingOrderBuilder WithPriceStopLimit(double newPriceStopLimit)
    {
        this._priceStopLimit = newPriceStopLimit;
        return this;
    }

    public PendingOrder Build()
    {
        return new PendingOrder()
        {
            Ticket = _ticket,
            OpenTime = _openTime,
            TimeUpdate = _timeUpdate,
            Type = _type,
            Magic = _magic,
            Identifier = _identifier,
            Reason = _reason,
            Volume = _volume,
            PriceOpen = _priceOpen,
            StopLoss = _stopLoss,
            TakeProfit = _takeProfit,
            PriceCurrent = _priceCurrent,
            Swap = _swap,
            Profit = _profit,
            Symbol = _symbol,
            Comment = _comment,
            ExternalID = _externalID,
            Change = _change,
            TimeDone = _timeDone,
            TimeSetup = _timeSetup,
            OrderReason = _orderReason,
            PositionID = _positionID,
            PositionByID = _positionByID,
            VolumeInitial = _volumeInitial,
            VolumeCurrent = _volumeCurrent,
            PriceStopLimit = _priceStopLimit,
        };
    }
}
