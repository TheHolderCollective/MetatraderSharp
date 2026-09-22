namespace MetatraderSharp.MetatraderClient;

public class UriBuilder
{
    private static string? _partialUri;
    private static string? _webSocketPort;

    public UriBuilder()
    {
        _partialUri = "http://127.0.0.1";
        _webSocketPort = "81";
    }

    public UriBuilder(string webSocketPort)
    {
        SetUriParameter(webSocketPort);
    }

    public void SetUriParameter(string webSocketPort)
    {
        _webSocketPort = webSocketPort;
    }

    public static string BuildTrackPricesUri(TrackingCommand trackCommand, params string[] symbolList)
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

        return $"{_partialUri}:{_webSocketPort}/v1/track/prices?{symbolParameters}";
    }

    public static string BuildMT4ModifyOrderUri(long ticketNumber, double stopLoss, double takeProfit, double price, string expiration)
    {
        string uri = $"{_partialUri}:{_webSocketPort}/v1/order/modify?ticket={ticketNumber}&sl={stopLoss}";

        if (takeProfit != 0.0)
        {
            uri += $"&tp={takeProfit}";
        }
        if (price != 0.0)
        {
            uri += $"&price={price}";
        }
        if (expiration != "")
        {
            uri += $"&expiration={expiration}";
        }
        return uri;
    }

    public static string BuildMT4SendOrderUri(string symbol, string orderType, double volume, double price = 0.0, double stopLoss = 0.0, 
                                        double takeProfit = 0.0, int magic = 0, string comment = "", string expiration = "")
    {
        string uri = $"{_partialUri}:{_webSocketPort}/v1/order?symbol={symbol}&volume={volume}&type={orderType}";

        if (takeProfit != 0.0)
        {
            uri += $"&tp={takeProfit}";
        }
        if (stopLoss != 0.0)
        {
            uri += $"&sl={stopLoss}";
        }
        if (magic != 0)
        {
            uri += $"&magic={magic}";
        }
        if (price != 0.0)
        {
            switch (orderType)
            {
                case OrderType.ORDER_TYPE_BUY:
                case OrderType.ORDER_TYPE_SELL:
                case OrderType.ORDER_TYPE_BUY_LIMIT:
                case OrderType.ORDER_TYPE_SELL_LIMIT:
                case OrderType.ORDER_TYPE_BUY_STOP:
                case OrderType.ORDER_TYPE_SELL_STOP:
                    uri += $"&price={price}";
                    break;
                default:
                    break;
            }
        }
        if (expiration != "")
        {
            uri += $"&expiration={expiration}";
        }
        if (comment != "")
        {
            uri += $"&comment={comment}";
        }

        return uri;
    }

    public static string BuildMT4CloseOrderUri(long ticketNumber, double volume = 0.0)
    {
        if (volume != 0.0)
        {
            return $"{_partialUri}:{_webSocketPort}/v1/order/close?ticket={ticketNumber}&volume={volume}";
        }

        return $"{_partialUri}:{_webSocketPort}/v1/order/close?ticket={ticketNumber}";
    }

    public static string BuildMT5ModifyOrderUri(long ticketNumber, double stopLoss, double takeProfit, double price, bool async, string expiration)
    {
        string uri = $"{_partialUri}:{_webSocketPort}/v1/order/modify?ticket={ticketNumber}&sl={stopLoss}&async={async}";

        if (takeProfit != 0.0)
        {
            uri += $"&tp={takeProfit}";
        }
        if (price != 0.0)
        {
            uri += $"&price={price}";
        }
        if (expiration != "")
        {
            uri += $"&expiration={expiration}";
        }
        return uri;
    }

    public static string BuildMT5SendOrderUri(string symbol, string orderType, double volume, bool async = false, double price = 0.0, double stopLoss = 0.0, 
                                        double takeProfit = 0.0, int magic = 0, string orderFillType = "", string comment = "", string expiration = "")
    {
        string uri = $"{_partialUri}:{_webSocketPort}/v1/order?symbol={symbol}&volume={volume}&type={orderType}";

        if (takeProfit != 0.0)
        {
            uri += $"&tp={takeProfit}";
        }
        if (stopLoss != 0.0)
        {
            uri += $"&sl={stopLoss}";
        }
        if (magic != 0)
        {
            uri += $"&magic={magic}";
        }
        if (price != 0.0)
        {
            switch (orderType)
            {
                case OrderType.ORDER_TYPE_BUY:
                case OrderType.ORDER_TYPE_SELL:
                case OrderType.ORDER_TYPE_BUY_LIMIT:
                case OrderType.ORDER_TYPE_SELL_LIMIT:
                case OrderType.ORDER_TYPE_BUY_STOP:
                case OrderType.ORDER_TYPE_SELL_STOP:
                    uri += $"&price={price}";
                    break;
                default:
                    break;
            }
        }
        if (orderFillType != "")
        {
            switch (orderFillType)
            {
                case OrderFillType.ORDER_FILLING_FOK:
                case OrderFillType.ORDER_FILLING_IOC:
                case OrderFillType.ORDER_FILLING_RETURN:
                case OrderFillType.ORDER_FILLING_BOC:
                    uri += $"&type_filling={orderFillType}";
                    break;
                default: // maybe look into changing this so that user if notified if there is an unrecognised orderfill type
                    break;
            }
        }
        if (expiration != "")
        {
            uri += $"&expiration={expiration}";
        }
        if (comment != "")
        {
            uri += $"&comment={comment}";
        }

        if (async != false)
        {
            uri += $"&async=true";
        }

        return uri;
    }

    public static string BuildMT5CloseOrderUri(long ticketNumber, double volume = 0.0, bool async = false)
    {
        string uri = $"{_partialUri}:{_webSocketPort}/v1/order/close?ticket={ticketNumber}";

        if (volume != 0.0)
        {
            uri = $"{_partialUri}:{_webSocketPort}/v1/order/close?ticket={ticketNumber}&volume={volume}";
        }

        if (async == true)
        {
            uri += "&async=true";
        }

        return uri;
    }

    public static string BuildMT5GetCustomIndicatorValuesUri(string indicatorName, string symbol, string timeframe, int index, 
                                                             int count, string param1 = "", string param2 = "", string param3 = "", string param4 = "")
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

        return $"{_partialUri}:{_webSocketPort}/v1/indicator/custom?{parameters}";
    }

    public static string BuildMT5TrackMarketBookUri(params string[] symbolList)
    {
        string symbolParameters = "";

        if (symbolList.Length == 1 && symbolList[0] == "")
        {
            symbolParameters += $"symbols=";
        }
        else
        {
            for (int i = 0; i < symbolList.Length; i++)
            {

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

        return $"{_partialUri}:{_webSocketPort}/v1/track/mbook?{symbolParameters}";
    }

    public static string BuildMT5MAIndicatorValuesUri(string appliedPrice, string ma_Method, int ma_Period, int count, int ma_Shift, string symbol, string timeframe)
    {
        string parameters = $"symbol={symbol}&timeframe={timeframe}&ma_period={ma_Period}&ma_shift={ma_Shift}&ma_method={ma_Method}&applied_price={appliedPrice}&num={count}";

        return $"{_partialUri}:{_webSocketPort}/v1/indicator/ma?{parameters}";
    }

}
