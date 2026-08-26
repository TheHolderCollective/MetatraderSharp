using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses;

public class TrackOHLCRequest
{
    [JsonProperty("OHLC")]
    public List<SymbolRequest> OHLCRequests { get; set; }

    public TrackOHLCRequest()
    {
        OHLCRequests = new();
    }

    public TrackOHLCRequest(params SymbolRequest[] requests) : this()
    {
        for (int i = 0; i < requests.Length; i++)
        {
            OHLCRequests.Add(requests[i]);
        }
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

public class SymbolRequest
{
    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("TIMEFRAME")]
    public string? TimeFrame { get; set; }

    [JsonProperty("DEPTH")]
    public int Depth { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
