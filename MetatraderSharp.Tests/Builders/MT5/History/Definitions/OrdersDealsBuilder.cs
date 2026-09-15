using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class OrdersDealsBuilder
{
    private string _time;
    private long _ticket;
    private string _symbol;
    private string _type;
    private double _volume;
    private double _price;
    private int _magic;
    private string _comment;
    private List<OrderDeal> _deals;

    public OrdersDealsBuilder()
    {
        _time = "2026.08.26 23:51:47.255";
        _ticket = 99647050;
        _symbol = "EURUSD";
        _type = "BUY LIMIT";
        _volume = 0.01;
        _price = 1.1575;
        _magic = 0;
        _comment = "";
        _deals = new OrderDealListBuilder().Build();
    }

    public OrdersDealsBuilder WithTime(string newTime)
    {
        this._time = newTime;
        return this;
    }

    public OrdersDealsBuilder WithTicket(long newTicket)
    {
        this._ticket = newTicket;
        return this;
    }

    public OrdersDealsBuilder WithSymbol(string newSymbol)
    {
        this._symbol = newSymbol;
        return this;
    }

    public OrdersDealsBuilder WithType(string newType)
    {
        this._type = newType;
        return this;
    }

    public OrdersDealsBuilder WithVolume(double newVolume)
    {
        this._volume = newVolume;
        return this;
    }

    public OrdersDealsBuilder WithPrice(double newPrice)
    {
        this._price = newPrice;
        return this;
    }

    public OrdersDealsBuilder WithMagic(int newMagic)
    {
        this._magic = newMagic;
        return this;
    }

    public OrdersDealsBuilder WithComment(string newComment)
    {
        this._comment = newComment;
        return this;
    }

    public OrdersDealsBuilder WithDeals(List<OrderDeal> newDeals)
    {
        this._deals = newDeals;
        return this;
    }

    public OrdersDeals Build()
    {
        return new OrdersDeals()
        {
            Time = _time,
            Ticket = _ticket,
            Symbol = _symbol,
            Type = _type,
            Volume = _volume,
            Price = _price,
            Magic = _magic,
            Comment = _comment,
            Deals = _deals,
        };
    }
}

