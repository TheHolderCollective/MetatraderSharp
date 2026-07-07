using MetatraderSharp.MTsocketAPI.Responses;
namespace MetatraderSharp.MetatraderClient.MT4;

public partial class MT4Client : MetatraderClient
{
    public MT4Client(): base(MetatraderTerminalType.MT4)
    {
    }
}
