using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses;

/// <summary>
/// https://www.mtsocketapi.com/restapi_mt4.html#/operations/TrackOHLC
/// </summary>
public class TrackOHLCResponse: Response
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}

