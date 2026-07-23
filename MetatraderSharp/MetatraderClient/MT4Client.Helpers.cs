using MetatraderSharp.MTsocketAPI.Responses;
namespace MetatraderSharp.MetatraderClient;

public partial class MT4Client : MetatraderClient
{
    private string BuildTrackPricesUri(TrackingCommand trackCommand, string symbol1 = "", string symbol2 = "", string symbol3 = "", string symbol4 = "", string symbol5 = "")
    {
        string symbols = "";

        switch (trackCommand)
        {
            case TrackingCommand.Start:
                symbols = $"symbols={symbol1}&symbols={symbol2}&symbols={symbol3}&symbols={symbol4}&symbols={symbol5}";
                break;
            case TrackingCommand.Stop:
                symbols = $"symbols=";
                break;
        }

        return $"{_partialURI}:{WebSocketPort}/v1/track/prices?{symbols}";

    }

    private string BuildModifyOrderUri(long ticketNumber,double stopLoss, double takeProfit, double price, string expiration)
    {
        string uri = $"{_partialURI}:{WebSocketPort}/v1/order/modify?ticket={ticketNumber}&sl={stopLoss}";

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

    private string BuildSendOrderUri(string symbol, string orderType, double volume, double price = 0.0, double stopLoss = 0.0, double takeProfit = 0.0, 
                                     int magic = 0, string comment = "", string expiration = "")
    {
        string uri = $"{_partialURI}:{WebSocketPort}/v1/order?symbol={symbol}&volume={volume}&type={orderType}";

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
}
