using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses.MT5;

/// <summary>
/// https://www.mtsocketapi.com/restapi.html#/operations/AccountStatus
/// </summary>
public class Account
{
    [JsonProperty("MSG")]
    public string Msg { get; set; }

    [JsonProperty("COMPANY")]
    public string Company { get; set; }

    [JsonProperty("CURRENCY")]
    public string Currency { get; set; }

    [JsonProperty("NAME")]
    public string Name { get; set; }

    [JsonProperty("SERVER")]
    public string Server { get; set; }

    [JsonProperty("LOGIN")]
    public int Login { get; set; }

    [JsonProperty("TRADE_MODE")]
    public int TradeMode { get; set; }

    [JsonProperty("LEVERAGE")]
    public int Leverage { get; set; }

    [JsonProperty("LIMIT_ORDERS")]
    public int LimitOrders { get; set; }

    [JsonProperty("MARGIN_SO_MODE")]
    public int MarginSoMode { get; set; }

    [JsonProperty("TRADE_ALLOWED")]
    public int TradeAllowed { get; set; }

    [JsonProperty("TRADE_EXPERT")]
    public int TradeExpert { get; set; }

    [JsonProperty("MARGIN_MODE")]
    public int MarginMode { get; set; }

    [JsonProperty("CURRENCY_DIGITS")]
    public int CurrencyDigits { get; set; }

    [JsonProperty("FIFO_CLOSE")]
    public int FifoClose { get; set; }

    [JsonProperty("HEDGE_ALLOWED")]
    public int HedgeAllowed { get; set; }

    [JsonProperty("BALANCE")]
    public double Balance { get; set; }

    [JsonProperty("CREDIT")]
    public double Credit { get; set; }

    [JsonProperty("PROFIT")]
    public double Profit { get; set; }

    [JsonProperty("EQUITY")]
    public double Equity { get; set; }

    [JsonProperty("MARGIN")]
    public double Margin { get; set; }

    [JsonProperty("MARGIN_FREE")]
    public double MarginFree { get; set; }

    [JsonProperty("MARGIN_LEVEL")]
    public double MarginLevel { get; set; }

    [JsonProperty("MARGIN_SO_CAL")]
    public double MarginSoCal { get; set; }

    [JsonProperty("MARGIN_SO_SO")]
    public double MarginSoSo { get; set; }

    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string ErrorDescription { get; set; }

    [JsonProperty("DEMO")]
    public string Demo { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}


