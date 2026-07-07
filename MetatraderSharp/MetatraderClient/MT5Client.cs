using MetatraderSharp.MTsocketAPI.Responses;
using Newtonsoft.Json;
namespace MetatraderSharp.MetatraderClient;

public class MT5Client: MetatraderClient
{
    public MT5Client() : base(MetatraderTerminalType.MT5)
    {
    }

}
