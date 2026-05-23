using System;
namespace MetatraderSharp.MetatraderClient;

public partial class MT4Client
{
    #region Helpers - Constructor

    private void SetupRequestUriComponents()
    {
        _partialURI = "http://127.0.0.1";
        WebSocketPort = "81";
    }

    private void SetupHttpClient()
    {
        _client = new HttpClient();
    }

    private void VerifyHttpStatus()
    {
        try
        {
            string url = $"{_partialURI}:{WebSocketPort}";
            var response = _client.GetAsync(url).Result;
            StatusIsOK = response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            StatusIsOK = false;
        }
    }
    #endregion

    #region Helpers - Error Handling

    private void SetQueryResult(int errorID, string errorDescription)
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
