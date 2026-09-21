using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.Common;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/HistoryPrices
/// </summary>
public class PriceHistory : MTsocketApiResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("TIMEFRAME")]
    public string? TimeFrame { get; set; }

    [JsonProperty("RATES")]
    public List<Rate> Rates { get; set; } = new();
}
