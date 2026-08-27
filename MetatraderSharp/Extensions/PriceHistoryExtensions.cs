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

    /// <summary>
    /// Returns first rate found with maximum open value for data set
    /// </summary>
    public static Rate? GetMaxOpenRate(this PriceHistory priceHistory)
    {
        if (priceHistory.RateCount() > 0)
        {
            double maxOpen = priceHistory.Rates.Max(x => x.Open);
            return (Rate) priceHistory.Rates.Select(x => x).Where(x => x.Open == maxOpen).First();
        }
        return null;
    }

    /// <summary>
    /// Returns first rate found with minimum open value for data set 
    /// </summary>
    public static Rate? GetMinOpenRate(this PriceHistory priceHistory)
    {
        if (priceHistory.RateCount() > 0)
        {
            double minOpen = priceHistory.Rates.Min(x => x.Open);
            return (Rate)priceHistory.Rates.Select(x => x).Where(x => x.Open == minOpen).First();
        }
        return null;
    }

}

