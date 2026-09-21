using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.Common;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/SymbolList
/// </summary>
public class SymbolList : MTsocketApiResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("SYMBOLS")]
    public List<Symbol> Symbols { get; set; } = new();
}
