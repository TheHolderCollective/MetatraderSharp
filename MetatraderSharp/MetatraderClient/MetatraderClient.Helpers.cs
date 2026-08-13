namespace MetatraderSharp.MetatraderClient;

public abstract partial class MetatraderClient
{
    #region Helpers - Constructor

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
                LastQueryStatus = QueryStatus.Ok;
                break;
            default:
                LastQueryStatus = QueryStatus.Error;
                break;
        }
        LastQueryMessage = errorDescription;
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

        return $"{_partialURI}:{WebSocketPort}/v1/track/prices?{symbolParameters}";
    }

    #endregion
}

