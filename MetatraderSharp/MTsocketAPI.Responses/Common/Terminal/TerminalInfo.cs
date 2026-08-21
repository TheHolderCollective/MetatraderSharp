using Newtonsoft.Json;
namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/TerminalInfo
/// </summary>
public class TerminalInfo
{
    [JsonProperty("MSG")]
    public string Msg { get; set; }

    [JsonProperty("LANGUAGE")]
    public string Language { get; set; }

    [JsonProperty("COMPANY")]
    public string Company { get; set; }

    [JsonProperty("NAME")]
    public string Name { get; set; }

    [JsonProperty("PATH")]
    public string Path { get; set; }

    [JsonProperty("DATA_PATH")]
    public string DataPath { get; set; }

    [JsonProperty("COMMONDATA_PATH")]
    public string CommonDataPath { get; set; }

    [JsonProperty("BUILD")]
    public double Build { get; set; }

    [JsonProperty("COMMUNITY_ACCOUNT")]
    public double CommunityAccount { get; set; }

    [JsonProperty("COMMUNITY_CONNECTION")]
    public double CommunityConnection { get; set; }

    [JsonProperty("CONNECTED")]
    public int Connected { get; set; }

    [JsonProperty("DLLS_ALLOWED")]
    public int DLLsAllowed { get; set; }

    [JsonProperty("TRADE_ALLOWED")]
    public int TradeAllowed { get; set; }

    [JsonProperty("EMAIL_ENABLED")]
    public int EmailEnabled { get; set; }

    [JsonProperty("FTP_ENABLED")]
    public int FtpEnabled { get; set; }

    [JsonProperty("NOTIFICATIONS_ENABLED")]
    public int NotificationsEnabled { get; set; }

    [JsonProperty("MAXBARS")]
    public int MaxBars { get; set; }

    [JsonProperty("MQID")]
    public int MQID { get; set; }

    [JsonProperty("CODEPAGE")]
    public int CodePage { get; set; }

    [JsonProperty("CPU_CORES")]
    public int CpuCores { get; set; }

    [JsonProperty("DISK_SPACE")]
    public double DiskSpace { get; set; }

    [JsonProperty("MEMORY_PHYSICAL")]
    public double MemoryPhysical { get; set; }

    [JsonProperty("MEMORY_TOTAL")]
    public double MemoryTotal { get; set; }

    [JsonProperty("MEMORY_AVAILABLE")]
    public double MemoryAvailable { get; set; }

    [JsonProperty("MEMORY_USED")]
    public double MemoryUsed { get; set; }

    [JsonProperty("SCREEN_DPI")]
    public double ScreenDPI { get; set; }

    [JsonProperty("PING_LAST")]
    public double PingLast { get; set; }

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
