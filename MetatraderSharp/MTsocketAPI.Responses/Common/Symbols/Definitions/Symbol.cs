using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.Common;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/SymbolList
/// </summary>
public class Symbol : MTsocketApiResponseBase
{
    [JsonProperty("NAME")]
    public string? Name { get; set; }

    [JsonProperty("TRADE_MODE")]
    public int TradeMode { get; set; }

    [JsonProperty("DESCRIPTION")]
    public string? Description { get; set; }

    [JsonProperty("PATH")]
    public string? Path { get; set; }
}
