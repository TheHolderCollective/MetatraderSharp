using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class OpenedOrderBuilder
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

    public OpenedOrderBuilder()
    {
        _ticket = 99647050;
        _openTime = "2026.09.02 07:20:05.528";
        _timeUpdate = "2026.09.02 07:20:05.528";
        _type = "ORDER_TYPE_BUY";
        _magic = 0;
        _identifier = 99647050;
        _reason = 0;
        _volume = 0.01;
        _priceOpen = 1.1575;
        _stopLoss = 0;
        _takeProfit = 0;
        _priceCurrent = 1.15375;
        _swap = -0.85;
        _profit = -3.75;
        _symbol = "EURUSD";
        _comment = "";
        _externalID = "";
        _change = -0.32;
    }

    public OpenedOrderBuilder WithTicket(long newTicket)
    {
        this._ticket = newTicket;
        return this;
    }

    public OpenedOrderBuilder WithOpenTime(string newOpenTime)
    {
        this._openTime = newOpenTime;
        return this;
    }

    public OpenedOrderBuilder WithTimeUpdate(string newTimeUpdate)
    {
        this._timeUpdate = newTimeUpdate;
        return this;
    }

    public OpenedOrderBuilder WithType(string newType)
    {
        this._type = newType;
        return this;
    }

    public OpenedOrderBuilder WithMagic(int newMagic)
    {
        this._magic = newMagic;
        return this;
    }

    public OpenedOrderBuilder WithIdentifier(long newIdentifier)
    {
        this._identifier = newIdentifier;
        return this;
    }

    public OpenedOrderBuilder WithReason(int newReason)
    {
        this._reason = newReason;
        return this;
    }

    public OpenedOrderBuilder WithVolume(double newVolume)
    {
        this._volume = newVolume;
        return this;
    }

    public OpenedOrderBuilder WithPriceOpen(double newPriceOpen)
    {
        this._priceOpen = newPriceOpen;
        return this;
    }

    public OpenedOrderBuilder WithStopLoss(double newStopLoss)
    {
        this._stopLoss = newStopLoss;
        return this;
    }

    public OpenedOrderBuilder WithTakeProfit(double newTakeProfit)
    {
        this._takeProfit = newTakeProfit;
        return this;
    }

    public OpenedOrderBuilder WithPriceCurrent(double newPriceCurrent)
    {
        this._priceCurrent = newPriceCurrent;
        return this;
    }

    public OpenedOrderBuilder WithSwap(double newSwap)
    {
        this._swap = newSwap;
        return this;
    }

    public OpenedOrderBuilder WithProfit(double newProfit)
    {
        this._profit = newProfit;
        return this;
    }

    public OpenedOrderBuilder WithSymbol(string newSymbol)
    {
        this._symbol = newSymbol;
        return this;
    }

    public OpenedOrderBuilder WithComment(string newComment)
    {
        this._comment = newComment;
        return this;
    }

    public OpenedOrderBuilder WithExternalID(string newExternalID)
    {
        this._externalID = newExternalID;
        return this;
    }

    public OpenedOrderBuilder WithChange(double newChange)
    {
        this._change = newChange;
        return this;
    }

    public OpenedOrder Build()
    {
        return new OpenedOrder()
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
        };
    }
}
