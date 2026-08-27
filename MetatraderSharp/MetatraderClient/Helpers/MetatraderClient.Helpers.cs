namespace MetatraderSharp.MetatraderClient;

public abstract partial class MetatraderClient
{
    #region Helpers - Constructor

    private void VerifyHttpStatus(HttpClient client)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(client);

            _requestedUri = $"{_partialURI}:{_webSocketPort}";
            var response = client.GetAsync(_requestedUri).Result;
            _clientStatusIsOK = response.IsSuccessStatusCode;
            _clientStatusMessage = response.StatusCode.ToString();

            SetQueryResult(QueryStatus.Ok, _clientStatusMessage);
        }
        catch (Exception ex)
        {
            _clientStatusMessage = ex.Message;
            _clientStatusIsOK = false;

            SetQueryResult(QueryStatus.Error, _clientStatusMessage);
        }
    }
    #endregion

    #region Helpers - Error Handling

    protected void SetQueryResult(int errorID, string? errorDescription)
    {
        switch (errorID)
        {
            case 0:
                _lastQueryStatus = QueryStatus.Ok;
                break;
            default:
                _lastQueryStatus = QueryStatus.Error;
                break;
        }

        _lastErrorCode = errorID;
        _lastQueryMessage = errorDescription;
    }

    #endregion

    #region Helpers - Uri Building

    private string BuildTrackPricesUri(TrackingCommand trackCommand, params string[] symbolList)
    {
        string symbolParameters = "";

        if (trackCommand == TrackingCommand.Start)
        {
            for (int i = 0; i < symbolList.Length; i++)
            {
                ArgumentNullException.ThrowIfNullOrEmpty(symbolList[i], nameof(symbolList));

                if (i == symbolList.Length - 1)
                {
                    symbolParameters += $"symbols={symbolList[i]}";
                }
                else
                {
                    symbolParameters += $"symbols={symbolList[i]}&";
                }
            }
        }
        else if (trackCommand == TrackingCommand.Stop)
        {
            symbolParameters = $"symbols=";
        }

        return $"{_partialURI}:{_webSocketPort}/v1/track/prices?{symbolParameters}";
    }
    #endregion
}

