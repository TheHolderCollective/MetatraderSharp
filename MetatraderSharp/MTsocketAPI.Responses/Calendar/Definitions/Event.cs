using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses;
public class Event
{
    [JsonProperty("TIME")]
    public string Time { get; set; }

    [JsonProperty("EVENT_COUNTRY_ID")]
    public int EventCountryID { get; set; }

    [JsonProperty("EVENT_DIGITS")]
    public int EventDigits { get; set; }

    [JsonProperty("EVENT_CODE")]
    public string EventCode { get; set; }

    [JsonProperty("EVENT_FREQUENCY")]
    public string EventFrequency { get; set; }

    [JsonProperty("EVENT_ID")]
    public int EventID { get; set; }

    [JsonProperty("EVENT_IMPORTANCE")]
    public string EventImportance { get; set; }

    [JsonProperty("EVENT_MULTIPLIER")]
    public string EventMultiplier { get; set; }

    [JsonProperty("EVENT_NAME")]
    public string EventName { get; set; }

    [JsonProperty("EVENT_SECTOR")]
    public string EventSector { get; set; }

    [JsonProperty("EVENT_SOURCE_URL")]
    public string EventSourceUrl { get; set; }

    [JsonProperty("EVENT_TIME_MODE")]
    public string EventTimeMode { get; set; }

    [JsonProperty("EVENT_TYPE")]
    public string EventType { get; set; }

    [JsonProperty("EVENT_UNIT")]
    public string EventUnit { get; set; }

    [JsonProperty("ACTUAL_VALUE")]
    public double ActualValue { get; set; }

    [JsonProperty("FORECAST_VALUE")]
    public double ForecastValue { get; set; }

    [JsonProperty("PREVIOUS_VALUE")]
    public double PreviousValue { get; set; }

    [JsonProperty("REVISED_VALUE")]
    public double RevisedValue { get; set; }

    [JsonProperty("IMPACT_TYPE")]
    public string ImpactType { get; set; }

    [JsonProperty("REVISION")]
    public int Revision { get; set; }

    [JsonProperty("PERIOD")]
    public string Period { get; set; }
}
