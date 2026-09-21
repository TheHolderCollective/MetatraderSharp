using MetatraderSharp.MTsocketAPI.Responses.Base;
using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.MT4;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/OrderSend
/// </summary>
public class OrderSendResponse : MTsocketApiResponse,  IOrderResponse
{
    [JsonProperty("MSG")]
    public string? Msg { get; set; }

    [JsonProperty("TICKET")]
    public long Ticket { get; set; }
}
