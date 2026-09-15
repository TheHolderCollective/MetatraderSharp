using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class OrderListBuilder
{
    private string _msg;
    private int _count;
    private List<OpenedOrder> _openedOrders;
    private List<PendingOrder> _pendingOrders;
    private int _errorID;
    private string _errorDescription;

    public OrderListBuilder()
    {
        _msg = "ORDER_LIST";
        _count = 2;
        _openedOrders = new OpenedOrderListBuilder().Build();
        _pendingOrders = new PendingOrderListBuilder().Build();
        _errorID = 0;
        _errorDescription = "The operation completed successfully";
    }

    public OrderListBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public OrderListBuilder WithCount(int newCount)
    {
        this._count = newCount;
        return this;
    }

    public OrderListBuilder WithOpenedOrders(List<OpenedOrder> newOpenedOrders)
    {
        this._openedOrders = newOpenedOrders;
        return this;
    }

    public OrderListBuilder WithPendingOrders(List<PendingOrder> newPendingOrders)
    {
        this._pendingOrders = newPendingOrders;
        return this;
    }

    public OrderListBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public OrderListBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public OrderListBuilder WithNoOrders()
    {
        _count = 0;
        _openedOrders.Clear();
        _pendingOrders.Clear();
        return this;
    }

    public OrderList Build()
    {
        return new OrderList()
        {
            Msg = _msg,
            Count = _count,
            OpenedOrders = _openedOrders,
            PendingOrders = _pendingOrders,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}
