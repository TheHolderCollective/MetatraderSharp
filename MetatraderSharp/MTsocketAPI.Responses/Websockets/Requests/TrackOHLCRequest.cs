using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.Common;

public class TrackOHLCRequest : MTsocketApiResponseBase
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
}

public class SymbolRequest : MTsocketApiResponseBase
{
    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }
    
    [JsonProperty("TIMEFRAME")]
    public string? TimeFrame { get; set; }

    [JsonProperty("DEPTH")]
    public int Depth { get; set; }

    public SymbolRequest()
    {

    }

    public SymbolRequest(string requestedSymbol, string requestedTimeFrame, int requestedDepth)
    {
        Symbol = requestedSymbol;
        TimeFrame = requestedTimeFrame;
        Depth = requestedDepth;
    }
}
