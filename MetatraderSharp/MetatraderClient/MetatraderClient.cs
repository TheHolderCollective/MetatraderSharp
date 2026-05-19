using MetatraderSharp.MTsocketAPI.Responses;
namespace MetatraderSharp;

public partial class MetatraderClient
{
    private HttpClient _client;
    private string _partialURI;
    public string WebSocketPort { get; set;}

    public HttpClient? Client 
    { 
        set
        {
            _client = value;
        }
    }

    public MetatraderClient()
    {
        _partialURI = "http://127.0.0.1";
        _client = new HttpClient();
        WebSocketPort = "81";
    }
    
    public Account? GetAccountInfo()
    {
        return GetAccountInfoAsync().Result;
    }

    public TerminalInfo? GetTerminalInfo()
    {
        return GetTerminalInfoAsync().Result;
    }

    public SymbolList? GetSymbolListResponse()
    {
        return GetSymbolListResponseAsync().Result;
    }

    public List<Symbol>? GetSymbolList()
    {
        return GetSymbolListResponseAsync().Result.Symbols;
    }

}
