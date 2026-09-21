using Newtonsoft.Json;

namespace MetatraderSharp.MTsocketAPI.Responses.Base;

public abstract class MTsocketApiResponseBase
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
