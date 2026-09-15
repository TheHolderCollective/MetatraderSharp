using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class OrderDealBuilder
{
    private string _time;
    private long _ticket;
    private string _type;
    private string _reason;
    private double _volume;
    private double _price;
    private double _commission;
    private double _profit;
    private double _swap;
    private int _magic;
    private string _comment;

    public OrderDealBuilder()
    {
        _time = "2026.09.02 07:20:05.528";
        _ticket = 78522301;
        _type = "IN";
        _reason = "DEAL_REASON_CLIENT";
        _volume = 0.01;
        _price = 1.1575;
        _commission = 0;
        _profit = 0;
        _swap = 0;
        _magic = 0;
        _comment = "";
    }

    public OrderDealBuilder WithTime(string newTime)
    {
        this._time = newTime;
        return this;
    }

    public OrderDealBuilder WithTicket(long newTicket)
    {
        this._ticket = newTicket;
        return this;
    }

    public OrderDealBuilder WithType(string newType)
    {
        this._type = newType;
        return this;
    }

    public OrderDealBuilder WithReason(string newReason)
    {
        this._reason = newReason;
        return this;
    }

    public OrderDealBuilder WithVolume(double newVolume)
    {
        this._volume = newVolume;
        return this;
    }

    public OrderDealBuilder WithPrice(double newPrice)
    {
        this._price = newPrice;
        return this;
    }

    public OrderDealBuilder WithCommission(double newCommission)
    {
        this._commission = newCommission;
        return this;
    }

    public OrderDealBuilder WithProfit(double newProfit)
    {
        this._profit = newProfit;
        return this;
    }

    public OrderDealBuilder WithSwap(double newSwap)
    {
        this._swap = newSwap;
        return this;
    }

    public OrderDealBuilder WithMagic(int newMagic)
    {
        this._magic = newMagic;
        return this;
    }

    public OrderDealBuilder WithComment(string newComment)
    {
        this._comment = newComment;
        return this;
    }

    public OrderDeal Build()
    {
        return new OrderDeal()
        {
            Time = _time,
            Ticket = _ticket,
            Type = _type,
            Reason = _reason,
            Volume = _volume,
            Price = _price,
            Commission = _commission,
            Profit = _profit,
            Swap = _swap,
            Magic = _magic,
            Comment = _comment,
        };
    }
}

public class OrderDealListBuilder
{
    private List<OrderDeal> _orderDeals = [];

    public OrderDealListBuilder()
    {
        _orderDeals.Add(new OrderDealBuilder().Build());
    }

    public OrderDealListBuilder WithOrderDeal(OrderDeal newOrderDeal)
    {
        _orderDeals.Add(newOrderDeal);
        return this;
    }

    public OrderDealListBuilder WithNoDefaultOrderDeals()
    {
        _orderDeals.Clear();
        return this;
    }

    public List<OrderDeal> Build()
    {
        return _orderDeals;
    }
}

