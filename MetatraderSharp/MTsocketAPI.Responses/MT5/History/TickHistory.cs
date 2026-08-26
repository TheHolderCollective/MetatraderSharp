using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class TickHistory
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("TICKS")]
    public List<Tick> Ticks { get; set; } = new();

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string? ErrorDescription { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
