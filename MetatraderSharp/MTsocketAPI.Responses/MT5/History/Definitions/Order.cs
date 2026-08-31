using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

public class Order
{
    [JsonProperty("TIME_SETUP")]
    public string? TimeSetup { get; set; }

    [JsonProperty("SYMBOL")]
    public string? Symbol { get; set; }

    [JsonProperty("TICKET")]
    public long Ticket { get; set; }

    [JsonProperty("TYPE")]
    public string? Type { get; set; }

    [JsonProperty("VOLUME_INITIAL")]
    public double VolumeInitial { get; set; }

    [JsonProperty("VOLUME_CURRENT")]
    public double VolumeCurrent { get; set; }

    [JsonProperty("PRICE")]
    public double Price { get; set; }

    [JsonProperty("SL")]
    public double StopLoss { get; set; }

    [JsonProperty("TP")]
    public double TakeProfit { get; set; }

    [JsonProperty("STATE")]
    public string? State { get; set; }

    [JsonProperty("MAGIC")]
    public int Magic { get; set; }

    [JsonProperty("COMMENT")]
    public string? Comment { get; set; }

    [JsonProperty("TIME_DONE")]
    public string? TimeDone { get; set; }

    [JsonProperty("POSITION")]
    public long Position { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}