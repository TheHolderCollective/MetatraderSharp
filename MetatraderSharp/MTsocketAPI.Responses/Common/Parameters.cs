namespace MetatraderSharp.MTsocketAPI.Responses;

public static class MetatraderTerminalType
{
    public const string MT4 = "MT4";
    public const string MT5 = "MT5";
}

public static class TimeframesMT4
{
    public const string Period_M1 = "PERIOD_M1";
    public const string Period_M5 = "PERIOD_M5";
    public const string Period_M15 = "PERIOD_M15";
    public const string Period_M30 = "PERIOD_M30";
    public const string Period_H1 = "PERIOD_H1";
    public const string Period_H4 = "PERIOD_H4";
    public const string Period_D1 = "PERIOD_D1";
    public const string Period_W1 = "PERIOD_W1";
    public const string Period_MN = "PERIOD_MN1";
}

public static class TimeframesMT5
{
    public const string Period_M1 = "PERIOD_M1";
    public const string Period_M2 = "PERIOD_M2";
    public const string Period_M3 = "PERIOD_M3";
    public const string Period_M4 = "PERIOD_M4";
    public const string Period_M5 = "PERIOD_M5";
    public const string Period_M6 = "PERIOD_M6";
    public const string Period_M10 = "PERIOD_M10";
    public const string Period_M12 = "PERIOD_M12";
    public const string Period_M15 = "PERIOD_M15";
    public const string Period_M20 = "PERIOD_M20";
    public const string Period_M30 = "PERIOD_M30";
    public const string Period_H1 = "PERIOD_H1";
    public const string Period_H2 = "PERIOD_H2";
    public const string Period_H3 = "PERIOD_H3";
    public const string Period_H4 = "PERIOD_H4";
    public const string Period_H6 = "PERIOD_H6";
    public const string Period_H8 = "PERIOD_H8";
    public const string Period_H12 = "PERIOD_H12";
    public const string Period_D1 = "PERIOD_D1";
    public const string Period_W1 = "PERIOD_W1";
    public const string Period_MN = "PERIOD_MN1";
}

public static class AppliedPrice
{
    public const string Price_Open = "PRICE_OPEN";
    public const string Price_Close = "PRICE_CLOSE";
    public const string Price_High = "PRICE_HIGH";
    public const string Price_Low = "PRICE_LOW";
    public const string Price_Weighted = "PRICE_WEIGHTED";
}

public static class MA_Method
{
    public const string Mode_SMA = "MODE_SMA";
    public const string Mode_EMA = "MODE_EMA";
    public const string Mode_SMMA = "MODE_SMMA";
    public const string Mode_LVMA = "MODE_LWMA";
}

public static class OrderType
{
    public const string ORDER_TYPE_BUY = "ORDER_TYPE_BUY";
    public const string ORDER_TYPE_SELL = "ORDER_TYPE_SELL";
    public const string ORDER_TYPE_BUY_LIMIT = "ORDER_TYPE_BUY_LIMIT";
    public const string ORDER_TYPE_SELL_LIMIT = "ORDER_TYPE_SELL_LIMIT";
    public const string ORDER_TYPE_BUY_STOP = "ORDER_TYPE_BUY_STOP";
    public const string ORDER_TYPE_SELL_STOP = "ORDER_TYPE_SELL_STOP";
}
