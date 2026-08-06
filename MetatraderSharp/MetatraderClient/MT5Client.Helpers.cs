namespace MetatraderSharp.MetatraderClient;

public partial class MT5Client : MetatraderClient
{
    private string BuildGetCustomIndicatorValuesUri(string indicatorName, string symbol, string timeframe, int index, int count, string param1 = "", string param2 = "", string param3 = "", string param4 = "")
    {
        string parameters = $"symbol={symbol}&timeframe={timeframe}&indicator_name={indicatorName}&index={index}&num={count}";

        if (param1 != "")
        {
            parameters += $"&param1={param1}";
        }
        if (param2 != "")
        {
            parameters += $"&param2={param2}";
        }
        if (param3 != "")
        {
            parameters += $"&param3={param3}";
        }
        if (param4 != "")
        {
            parameters += $"&param4={param4}";
        }

        return $"{_partialURI}:{WebSocketPort}/v1/indicator/custom?{parameters}";
    }

}
