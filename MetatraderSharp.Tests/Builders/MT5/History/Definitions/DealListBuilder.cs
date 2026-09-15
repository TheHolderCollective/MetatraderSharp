using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class DealListBuilder
{
    private List<Deal> _deals = [];

    public DealListBuilder()
    {
        _deals.Add(new DealBuilder().Build());
    }

    public DealListBuilder WithNoDefaultDeals()
    {
        _deals.Clear();
        return this;
    }

    public DealListBuilder WithDeal(Deal newDeal)
    {
        _deals.Add(newDeal);
        return this;
    }

    public List<Deal> Build()
    {
        return _deals;
    }
}

