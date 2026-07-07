using MetatraderSharp.MTsocketAPI.Responses;
namespace MetatraderSharp.MetatraderClient.MT4;

public class MT5Client: MetatraderClient
{
    public MT5Client() : base(MetatraderTerminalType.MT5)
    {
    }
}
