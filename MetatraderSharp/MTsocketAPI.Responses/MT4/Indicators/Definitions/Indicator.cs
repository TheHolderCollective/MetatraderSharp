using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT4;

public abstract class Indicator
{
    [JsonProperty("MSG")]
    public string Msg { get; set; }

    [JsonProperty("DATA_VALUE")]
    public double DataValue { get; set; }

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string ErrorDescription { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
