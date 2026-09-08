using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.Tests.Builders.MT4;

public class TradeBuilder
{
    private string _symbol;
    private int _magic;
    private long _ticket;
    private string _openTime;
    private string _closeTime;
    private double _priceOpen;
    private double _priceClose;
    private string _type;
    private double _lots;
    private double _stopLoss;
    private double _takeProfit;
    private double _swap;
    private double _commission;
    private string _comment;
    private double _profit;
    private string _expiration;

    public TradeBuilder()
    {
        _symbol = "USDCAD";
        _magic = 0;
        _ticket = 296629269;
        _openTime = "2026.09.08 22:51:20";
        _closeTime = "";
        _priceOpen = 1.37842;
        _priceClose = 0;
        _type = "sell";
        _lots = 0.01;
        _stopLoss = 0;
        _takeProfit = 0;
        _swap = 0;
        _commission = 0;
        _comment = "";
        _profit = -0.13;
        _expiration = "1970.01.01 00:00:00";
    }

    public TradeBuilder WithSymbol(string newSymbol)
    {
        this._symbol = newSymbol;
        return this;
    }

    public TradeBuilder WithMagic(int newMagic)
    {
        this._magic = newMagic;
        return this;
    }

    public TradeBuilder WithTicket(long newTicket)
    {
        this._ticket = newTicket;
        return this;
    }

    public TradeBuilder WithOpenTime(string newOpenTime)
    {
        this._openTime = newOpenTime;
        return this;
    }

    public TradeBuilder WithCloseTime(string newCloseTime)
    {
        this._closeTime = newCloseTime;
        return this;
    }

    public TradeBuilder WithPriceOpen(double newPriceOpen)
    {
        this._priceOpen = newPriceOpen;
        return this;
    }

    public TradeBuilder WithPriceClose(double newPriceClose)
    {
        this._priceClose = newPriceClose;
        return this;
    }

    public TradeBuilder WithType(string newType)
    {
        this._type = newType;
        return this;
    }

    public TradeBuilder WithLots(double newLots)
    {
        this._lots = newLots;
        return this;
    }

    public TradeBuilder WithStopLoss(double newStopLoss)
    {
        this._stopLoss = newStopLoss;
        return this;
    }

    public TradeBuilder WithTakeProfit(double newTakeProfit)
    {
        this._takeProfit = newTakeProfit;
        return this;
    }

    public TradeBuilder WithSwap(double newSwap)
    {
        this._swap = newSwap;
        return this;
    }

    public TradeBuilder WithCommission(double newCommission)
    {
        this._commission = newCommission;
        return this;
    }

    public TradeBuilder WithComment(string newComment)
    {
        this._comment = newComment;
        return this;
    }

    public TradeBuilder WithProfit(double newProfit)
    {
        this._profit = newProfit;
        return this;
    }

    public TradeBuilder WithExpiration(string newExpiration)
    {
        this._expiration = newExpiration;
        return this;
    }

    public Trade Build()
    {
        return new Trade()
        {
            Symbol = _symbol,
            Magic = _magic,
            Ticket = _ticket,
            OpenTime = _openTime,
            CloseTime = _closeTime,
            PriceOpen = _priceOpen,
            PriceClose = _priceClose,
            Type = _type,
            Lots = _lots,
            StopLoss = _stopLoss,
            TakeProfit = _takeProfit,
            Swap = _swap,
            Commission = _commission,
            Comment = _comment,
            Profit = _profit,
            Expiration = _expiration,
        };
    }
}
