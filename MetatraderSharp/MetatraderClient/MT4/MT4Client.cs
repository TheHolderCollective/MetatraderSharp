using MetatraderSharp.MTsocketAPI.Responses;
namespace MetatraderSharp.MetatraderClient;

public partial class MT4Client
{
    #region Fields

    private HttpClient _client;
    private string _partialURI;

    #endregion

    #region Properties

    public string TerminalType { get; protected set; }
    public bool StatusIsOK { get; protected set; }
    public QueryStatus LastQueryStatus { get; protected set; }
    public string LastQueryMessage { get; protected set; }
    public string WebSocketPort { get; set; }
    public HttpClient? Client
    {
        set
        {
            _client = value;
        }
    }

    #endregion

    public MT4Client()
    {
        TerminalType = MetatraderTerminalType.MT4;
        SetupRequestUriComponents();
        SetupHttpClient();
        VerifyHttpStatus();
    }

}
