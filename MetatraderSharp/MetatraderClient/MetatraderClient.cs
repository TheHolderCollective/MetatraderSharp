namespace MetatraderSharp.MetatraderClient;

public abstract class MetatraderClient
{
    #region Fields

    protected string _partialURI;
    
    #endregion

    #region Properties

    public string TerminalType { get; protected set; }
    public bool StatusIsOK { get; protected set; }
    public QueryStatus LastQueryStatus { get; protected set; }
    public string LastQueryMessage { get; protected set; }
    public string WebSocketPort { get; set; }
    public HttpClient? Client { get; set; }

    #endregion

    public MetatraderClient(string terminalType) 
    {
        TerminalType = terminalType;

        SetupRequestUriComponents();
        SetupHttpClient();
        VerifyHttpStatus();
    }

    #region Helpers - Constructor

    private void SetupRequestUriComponents()
    {
        _partialURI = "http://127.0.0.1";
        WebSocketPort = "81";
    }

    private void SetupHttpClient()
    {
        Client = new HttpClient();
    }

    private void VerifyHttpStatus()
    {
        try
        {
            string url = $"{_partialURI}:{WebSocketPort}";
            var response = Client.GetAsync(url).Result;
            StatusIsOK = response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            StatusIsOK = false;
        }
    }
    #endregion

    #region Helpers - Error Handling

    protected void SetQueryResult(int errorID, string errorDescription)
    {
        switch (errorID)
        {
            case 0:
                LastQueryStatus = QueryStatus.OK;
                break;
            default:
                LastQueryStatus = QueryStatus.Error;
                break;
        }
        LastQueryMessage = errorDescription;
    }

    #endregion
}
