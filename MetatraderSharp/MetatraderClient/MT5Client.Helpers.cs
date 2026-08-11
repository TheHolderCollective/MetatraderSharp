namespace MetatraderSharp.MetatraderClient;

public partial class MT5Client : MetatraderClient
{

    private string BuildModifyOrderUri(long ticketNumber, double stopLoss, double takeProfit, double price, bool async,string expiration)
    {
        string uri = $"{_partialURI}:{WebSocketPort}/v1/order/modify?ticket={ticketNumber}&sl={stopLoss}&async={async}";

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

    private string BuildSendOrderUri(string symbol, string orderType, double volume, bool async = false, double price = 0.0, double stopLoss = 0.0, double takeProfit = 0.0,
                                    int magic = 0, string orderFillType = "", string comment = "", string expiration = "")
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
        if(orderFillType != "") 
        {
            switch(orderFillType)
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


    private string BuildCloseOrderUri(long ticketNumber, double volume = 0.0, bool async = false)
    {
        string uri = $"{_partialURI}:{WebSocketPort}/v1/order/close?ticket={ticketNumber}";

        if (volume != 0.0)
        {
            uri = $"{_partialURI}:{WebSocketPort}/v1/order/close?ticket={ticketNumber}&volume={volume}";
        }

        if (async == true)
        {
            uri += "&async=true";
        }

        return uri;
    }
}
