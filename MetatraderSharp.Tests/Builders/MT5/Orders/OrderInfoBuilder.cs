using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class OrderInfoBuilder
{
    private string _msg;
    private List<OpenedOrder> _openedOrder;
    private List<PendingOrder> _pendingOrder;
    private int _errorID;
    private string _errorDescription;

    public OrderInfoBuilder()
    {
        _msg = "ORDER_INFO";
        _openedOrder = new OpenedOrderListBuilder().Build();
        _pendingOrder = [];
        _errorID = 0;
        _errorDescription = "The operation completed successfully";
    }

    public OrderInfoBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public OrderInfoBuilder WithOpenedOrder(List<OpenedOrder> newOpenedOrder)
    {
        this._openedOrder = newOpenedOrder;
        return this;
    }

    public OrderInfoBuilder WithPendingOrder(List<PendingOrder> newPendingOrder)
    {
        this._pendingOrder = newPendingOrder;
        return this;
    }

    public OrderInfoBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public OrderInfoBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public OrderInfo Build()
    {
        return new OrderInfo()
        {
            Msg = _msg,
            OpenedOrder = _openedOrder,
            PendingOrder = _pendingOrder,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}
