using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class OrdersDealsListBuilder
{
    private List<OrdersDeals> _ordersDeals = [];

    public OrdersDealsListBuilder()
    {
        _ordersDeals.Add(new OrdersDealsBuilder().Build());
    }

    public OrdersDealsListBuilder WithOrdersDeals(OrdersDeals newOrdersDeals)
    {
        _ordersDeals.Add(newOrdersDeals);
        return this;
    }

    public OrdersDealsListBuilder WithNoDefaultOrdersDeals()
    {
        _ordersDeals.Clear();
        return this;
    }

    public List<OrdersDeals> Build()
    {
        return _ordersDeals;
    }

}
