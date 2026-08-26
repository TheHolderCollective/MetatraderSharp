using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class Calendar
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("EVENTS")]
    public List<Event> Events { get; set; } = new();

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string? ErrorDescription { get; set; }
     
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
