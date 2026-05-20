namespace MetatraderSharp;

public partial class MetatraderClient
{
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
}
