using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class OrdersListBuilder
{
    private List<Order> _orders = [];

    public OrdersListBuilder()
    {
        _orders.Add(new OrderBuilder().Build());
    }

    public OrdersListBuilder WithNoDefaultOrders()
    {
        _orders.Clear();
        return this;
    }

    public OrdersListBuilder WithOrder(Order newOrder)
    {
        _orders.Add(newOrder);
        return this;
    }

    public List<Order> Build()
    {
        return _orders;
    }
}

