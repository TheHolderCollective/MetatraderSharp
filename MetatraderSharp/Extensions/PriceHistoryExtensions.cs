using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Extensions;

public static class PriceHistoryExtensions
{
    public static int RateCount(this PriceHistory priceHistory)
    {
        return priceHistory.Rates.Count;
    }

    public static List<Rate> GetRates(this PriceHistory priceHistory)
    {
        return priceHistory.Rates;
    }
}

