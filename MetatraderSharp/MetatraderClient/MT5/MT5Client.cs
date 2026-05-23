using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.MetatraderClient;

public class MT5Client: MT4Client
{
    public MT5Client (): base()
    {
        TerminalType = MetatraderTerminalType.MT5;
    }

}
