using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/SymbolList
/// </summary>
public class SymbolList
{
    [JsonProperty("MSG")]
    public string Msg { get; set; }

    [JsonProperty("SYMBOLS")]
    public List<Symbol> Symbols { get; set; }

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string ErrorDescription { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
