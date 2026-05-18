using MetatraderSharp.MTsocketAPI.Responses;
using Newtonsoft.Json;
namespace MetatraderSharp;

public partial class MetatraderClient
{
    private string PartialURI { get; set; }
    public string WebSocketPort { get; set;}

    public MetatraderClient()
    {
        PartialURI = "http://127.0.0.1";
        WebSocketPort = "81";
    }
    
    public Account? GetAccountInfo()
    {
        return GetAccountInfoAsync().Result;
    }


}
