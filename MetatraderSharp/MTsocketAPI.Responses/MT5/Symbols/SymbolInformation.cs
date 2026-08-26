using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

/// <summary>
/// https://www.mtsocketapi.com/restapi.html#/operations/SymbolInfo
/// </summary>
public class SymbolInformation
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; } 

    [JsonProperty("NAME")]
    public string? Name { get; set; }

    [JsonProperty("TIME")]
    public string? Time { get; set; }

    [JsonProperty("DIGITS")]
    public int Digits { get; set; }

    [JsonProperty("SPREAD_FLOAT")]
    public int SpreadFloat { get; set; }

    [JsonProperty("SPREAD")]
    public int Spread { get; set; }

    [JsonProperty("TRADE_CALC_MODE")]
    public int TradeCalcMode { get; set; }

    [JsonProperty("TRADE_MODE")]
    public int TradeMode { get; set; }

    [JsonProperty("START_TIME")]
    public int StartTime { get; set; }

    [JsonProperty("EXPIRATION_TIME")]
    public int ExpirationTime { get; set; }

    [JsonProperty("TRADE_STOPS_LEVEL")]
    public int TradesTopsLevel { get; set; }

    [JsonProperty("TRADE_FREEZE_LEVEL")]
    public int TradeFreezeLevel { get; set; }

    [JsonProperty("TRADE_EXEMODE")]
    public int TradeExeMode { get; set; }

    [JsonProperty("SWAP_MODE")]
    public int SwapMode { get; set; }

    [JsonProperty("SWAP_ROLLOVER3DAYS")]
    public int SwapRollOver3Days { get; set; }

    [JsonProperty("POINT")]
    public double Point { get; set; }

    [JsonProperty("TRADE_TICK_VALUE")]
    public double TradeTickValue { get; set; }

    [JsonProperty("TRADE_TICK_VALUE_PROFIT")]
    public double TradeTickValueProfit { get; set; }

    [JsonProperty("TRADE_TICK_VALUE_LOSS")]
    public double TradeTickValueLoss { get; set; }

    [JsonProperty("TRADE_TICK_SIZE")]
    public double TradeTickSize { get; set; }

    [JsonProperty("TRADE_CONTRACT_SIZE")]
    public double TradeContractSize { get; set; }

    [JsonProperty("VOLUME_MIN")]
    public double VolumeMin { get; set; }

    [JsonProperty("VOLUME_MAX")]
    public double VolumeMax { get; set; }

    [JsonProperty("VOLUME_STEP")]
    public double VolumeStep { get; set; }

    [JsonProperty("VOLUME_LIMIT")]
    public double VolumeLimit { get; set; }

    [JsonProperty("SWAP_LONG")]
    public double SwapLong { get; set; }

    [JsonProperty("SWAP_SHORT")]
    public double SwapShort { get; set; }

    [JsonProperty("MARGIN_INITIAL")]
    public double MarginInitial { get; set; }

    [JsonProperty("MARGIN_MAINTENANCE")]
    public double MarginMaintenance { get; set; }

    [JsonProperty("CURRENCY_BASE")]
    public string? CurrencyBase { get; set; } 

    [JsonProperty("CURRENCY_PROFIT")]
    public string? CurrencyProfit { get; set; }

    [JsonProperty("CURRENCY_MARGIN")]
    public string? CurrencyMargin { get; set; } 

    [JsonProperty("DESCRIPTION")]
    public string? Description { get; set; }

    [JsonProperty("PATH")]
    public string? Path { get; set; } 

    [JsonProperty("SESSION_QUOTE")]
    public List<SessionQuote> SessionQuote { get; set; } = new();

    [JsonProperty("SESSION_TRADE")]
    public List<SessionTrade> SessionTrade { get; set; } = new();

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string? ErrorDescription { get; set; } 


    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

