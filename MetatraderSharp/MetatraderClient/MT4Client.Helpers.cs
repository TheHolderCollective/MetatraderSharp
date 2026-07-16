using MetatraderSharp.MTsocketAPI.Responses;
using MetatraderSharp.MTsocketAPI.Responses.MT4;
using Newtonsoft.Json;
namespace MetatraderSharp.MetatraderClient;

public partial class MT4Client : MetatraderClient
{
    private string BuildModifyOrderUri(long ticketNumber,double stopLoss, double takeProfit, double price, string expiration)
    {
        string uri = $"{_partialURI}:{WebSocketPort}/v1/modify?ticket={ticketNumber}&sl={stopLoss}";

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

    //private string BuildSendOrderUri(string symbol, string orderType, string volume, double price = 0, double stopLoss = 0, double takeProfit = 0, int magic = 0, string comment = "", string expiration = "")
    //{
    //    string orderParameters = $"symbol={symbol}&volume={volume}&type={orderType}"; //&sl={stopLoss}&tp={takeProfit}&comment={comment}&magic={magic}";

    //    switch (orderType)
    //    {
    //        case OrderType.ORDER_TYPE_BUY_LIMIT:
    //        case OrderType.ORDER_TYPE_SELL_LIMIT:
    //        case OrderType.ORDER_TYPE_BUY_STOP:
    //        case OrderType.ORDER_TYPE_SELL_STOP:
    //            orderParameters += $"&price{price}&expiration{expiration}";
    //            break;
    //        default:
    //            break;
    //    }

    //    string uri = $"{_partialURI}:{WebSocketPort}/v1/order?symbol={symbol}&volume={volume}&type={orderType}";
    //}
}
