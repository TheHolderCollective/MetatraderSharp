using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class PendingOrderListBuilder
{
    private List<PendingOrder> _pendingOrders = [];

    public PendingOrderListBuilder()
    {
        _pendingOrders.Add(new PendingOrderBuilder().Build());
    }

    public PendingOrderListBuilder WithNoDefaultPendingOrders()
    {
        _pendingOrders.Clear();
        return this;
    }

    public PendingOrderListBuilder WithPendingOrder(PendingOrder newPendingOrder)
    {
        _pendingOrders.Add(newPendingOrder);
        return this;
    }

    public List<PendingOrder> Build()
    {
        return _pendingOrders;
    }
}

