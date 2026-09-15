using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class OpenedOrderListBuilder
{
    private List<OpenedOrder> _openedOrders = [];

    public OpenedOrderListBuilder()
    {
        _openedOrders.Add(new OpenedOrderBuilder().Build());
    }

    public OpenedOrderListBuilder WithNoDefaultOpenedOrders()
    {
        _openedOrders.Clear();
        return this;
    }

    public OpenedOrderListBuilder WithOpenedOrder(OpenedOrder newOpenedOrder)
    {
        _openedOrders.Add(newOpenedOrder);
        return this;
    }

    public List<OpenedOrder> Build()
    {
        return _openedOrders;
    }
}
