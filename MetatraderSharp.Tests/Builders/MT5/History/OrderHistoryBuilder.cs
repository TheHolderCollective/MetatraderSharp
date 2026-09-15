using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class OrderHistoryBuilder
{
    private string _msg;
    private string _mode;
    private List<Order> _orders;
    private List<Deal> _deals;
    private List<Position> _positions;
    private List<OrdersDeals> _ordersDeals;
    private int _errorID;
    private string _errorDescription;

    public OrderHistoryBuilder()
    {
        _msg = "TRADE_HISTORY";
        _mode = "POSITIONS";
        _orders = [];
        _deals = [];
        _positions = new PositionListBuilder().Build();
        _ordersDeals = [];
        _errorID = 0;
        _errorDescription = "The operation completed successfully";
    }

    public OrderHistoryBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public OrderHistoryBuilder WithMode(string newMode)
    {
        this._mode = newMode;
        return this;
    }

    public OrderHistoryBuilder WithOrders(List<Order> newOrders)
    {
        this._orders = newOrders;
        return this;
    }

    public OrderHistoryBuilder WithDeals(List<Deal> newDeals)
    {
        this._deals = newDeals;
        return this;
    }

    public OrderHistoryBuilder WithPositions(List<Position> newPositions)
    {
        this._positions = newPositions;
        return this;
    }

    public OrderHistoryBuilder WithOrdersDeals(List<OrdersDeals> newOrdersDeals)
    {
        this._ordersDeals = newOrdersDeals;
        return this;
    }

    public OrderHistoryBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public OrderHistoryBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public OrderHistoryBuilder WithPositionsMode()
    {
        _mode = "POSITIONS";
        _orders = [];
        _deals = [];
        _positions = new PositionListBuilder().Build();
        _ordersDeals = [];

        return this;
    }

    public OrderHistoryBuilder WithOrdersMode()
    {
        _mode = "ORDERS";
        _orders = new OrdersListBuilder().Build();
        _deals = [];
        _positions = [];
        _ordersDeals = [];

        return this;
    }

    public OrderHistoryBuilder WithDealsMode()
    {
        _mode = "DEALS";
        _orders = [];
        _deals = new DealListBuilder().Build();
        _positions = [];
        _ordersDeals = [];

        return this;
    }

    public OrderHistoryBuilder WithOrdersDealsMode()
    {
        _mode = "ORDERS_DEALS";
        _orders = [];
        _deals = [];
        _positions = [];
        _ordersDeals = new OrdersDealsListBuilder().Build();

        return this;
    }

    public OrderHistory Build()
    {
        return new OrderHistory()
        {
            Msg = _msg,
            Mode = _mode,
            Orders = _orders,
            Deals = _deals,
            Positions = _positions,
            OrdersDeals = _ordersDeals,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}
