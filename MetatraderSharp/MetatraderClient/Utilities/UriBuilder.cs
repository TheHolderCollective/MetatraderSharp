namespace MetatraderSharp.MetatraderClient;

internal static class UriBuilder
{
    public static string BuildMT4ModifyOrderUri(string partialUri, string webSocketPort, long ticketNumber, double stopLoss, double takeProfit, double price, string expiration)
    {
        string uri = $"{partialUri}:{webSocketPort}/v1/order/modify?ticket={ticketNumber}&sl={stopLoss}";

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

    public static string BuildMT4SendOrderUri(string partialUri, string webSocketPort, string symbol, string orderType, double volume, double price = 0.0, double stopLoss = 0.0, 
                                        double takeProfit = 0.0, int magic = 0, string comment = "", string expiration = "")
    {
        string uri = $"{partialUri}:{webSocketPort}/v1/order?symbol={symbol}&volume={volume}&type={orderType}";

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

    public static string BuildMT4CloseOrderUri(string partialUri, string webSocketPort, long ticketNumber, double volume = 0.0)
    {
        if (volume != 0.0)
        {
            return $"{partialUri}:{webSocketPort}/v1/order/close?ticket={ticketNumber}&volume={volume}";
        }

        return $"{partialUri}:{webSocketPort}/v1/order/close?ticket={ticketNumber}";
    }
}
