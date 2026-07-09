using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/HistoryPrices
/// </summary>
public class PriceHistory
{
    [JsonProperty("MSG")]
    public string Msg { get; set; }

    [JsonProperty("SYMBOL")]
    public string Symbol { get; set; }

    [JsonProperty("TIMEFRAME")]
    public string TimeFrame { get; set; }

    [JsonProperty("RATES")]
    public List<Rate> Rates { get; set; }

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string ErrorDescription { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
