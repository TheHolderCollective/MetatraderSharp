using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class PositionBuilder
{
    private string _openTime;
    private string _symbol;
    private long _ticket;
    private string _type;
    private double _volume;
    private double _priceOpen;
    private int _magic;
    private string _closeTime;
    private double _priceClose;
    private double _profit;
    private double _commission;
    private double _swap;
    private double _stopLoss;
    private double _takeProfit;
    private double _change;

    public PositionBuilder()
    {
        _openTime = "2026.09.02 07:20:05.528";
        _symbol = "EURUSD";
        _ticket = 99646055;
        _type = "BUY";
        _volume = 0;
        _priceOpen = 0;
        _magic = 0;
        _closeTime = "2026.09.08 21:24:54.986";
        _priceClose = 1.16266;
        _profit = -2.77;
        _commission = 0;
        _swap = -0.89;
        _stopLoss = 0;
        _takeProfit = 0;
        _change = 0;
    }

    public PositionBuilder WithOpenTime(string newOpenTime)
    {
        this._openTime = newOpenTime;
        return this;
    }

    public PositionBuilder WithSymbol(string newSymbol)
    {
        this._symbol = newSymbol;
        return this;
    }

    public PositionBuilder WithTicket(long newTicket)
    {
        this._ticket = newTicket;
        return this;
    }

    public PositionBuilder WithType(string newType)
    {
        this._type = newType;
        return this;
    }

    public PositionBuilder WithVolume(double newVolume)
    {
        this._volume = newVolume;
        return this;
    }

    public PositionBuilder WithPriceOpen(double newPriceOpen)
    {
        this._priceOpen = newPriceOpen;
        return this;
    }

    public PositionBuilder WithMagic(int newMagic)
    {
        this._magic = newMagic;
        return this;
    }

    public PositionBuilder WithCloseTime(string newCloseTime)
    {
        this._closeTime = newCloseTime;
        return this;
    }

    public PositionBuilder WithPriceClose(double newPriceClose)
    {
        this._priceClose = newPriceClose;
        return this;
    }

    public PositionBuilder WithProfit(double newProfit)
    {
        this._profit = newProfit;
        return this;
    }

    public PositionBuilder WithCommission(double newCommission)
    {
        this._commission = newCommission;
        return this;
    }

    public PositionBuilder WithSwap(double newSwap)
    {
        this._swap = newSwap;
        return this;
    }

    public PositionBuilder WithStopLoss(double newStopLoss)
    {
        this._stopLoss = newStopLoss;
        return this;
    }

    public PositionBuilder WithTakeProfit(double newTakeProfit)
    {
        this._takeProfit = newTakeProfit;
        return this;
    }

    public PositionBuilder WithChange(double newChange)
    {
        this._change = newChange;
        return this;
    }

    public Position Build()
    {
        return new Position()
        {
            OpenTime = _openTime,
            Symbol = _symbol,
            Ticket = _ticket,
            Type = _type,
            Volume = _volume,
            PriceOpen = _priceOpen,
            Magic = _magic,
            CloseTime = _closeTime,
            PriceClose = _priceClose,
            Profit = _profit,
            Commission = _commission,
            Swap = _swap,
            StopLoss = _stopLoss,
            TakeProfit = _takeProfit,
            Change = _change,
        };
    }
}
