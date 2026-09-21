using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.Base;

public abstract class MTsocketApiResponse: MTsocketApiResponseBase
{
    [JsonProperty("ERROR_ID")]
    public int ErrorID { get; set; }

    [JsonProperty("ERROR_DESCRIPTION")]
    public string? ErrorDescription { get; set; }
}
