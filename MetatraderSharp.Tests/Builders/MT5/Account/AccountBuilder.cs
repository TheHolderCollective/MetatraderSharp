using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class AccountBuilder
{
    private string _msg;
    private string _company;
    private string _currency;
    private string _name;
    private string _server;
    private int _login;
    private int _tradeMode;
    private int _leverage;
    private int _limitOrders;
    private int _marginSoMode;
    private int _tradeAllowed;
    private int _tradeExpert;
    private int _marginMode;
    private int _currencyDigits;
    private int _fifoClose;
    private int _hedgeAllowed;
    private double _balance;
    private double _credit;
    private double _profit;
    private double _equity;
    private double _margin;
    private double _marginFree;
    private double _marginLevel;
    private double _marginSoCal;
    private double _marginSoSo;
    private int _errorID;
    private string _errorDescription;

    public AccountBuilder()
    {
        _msg = "ACCOUNT_STATUS";
        _company = "Test Company";
        _currency = "USD";
        _name = "Account Uder";
        _server = "Test-Demo";
        _login = 50060862;
        _tradeMode = 0;
        _leverage = 500;
        _limitOrders = 0;
        _marginSoMode = 0;
        _tradeAllowed = 1;
        _tradeExpert = 1;
        _marginMode = 2;
        _currencyDigits = 2;
        _fifoClose = 0;
        _hedgeAllowed = 1;
        _balance = 99911.62;
        _credit = 0;
        _profit = -2.57;
        _equity = 99909.05;
        _margin = 2.32;
        _marginFree = 99906.73;
        _marginLevel = 4306424.57;
        _marginSoCal = 99;
        _marginSoSo = 20;
        _errorID = 0;
        _errorDescription = "The operation completed successfully";
    }

    public AccountBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public AccountBuilder WithCompany(string newCompany)
    {
        this._company = newCompany;
        return this;
    }

    public AccountBuilder WithCurrency(string newCurrency)
    {
        this._currency = newCurrency;
        return this;
    }

    public AccountBuilder WithName(string newName)
    {
        this._name = newName;
        return this;
    }

    public AccountBuilder WithServer(string newServer)
    {
        this._server = newServer;
        return this;
    }

    public AccountBuilder WithLogin(int newLogin)
    {
        this._login = newLogin;
        return this;
    }

    public AccountBuilder WithTradeMode(int newTradeMode)
    {
        this._tradeMode = newTradeMode;
        return this;
    }

    public AccountBuilder WithLeverage(int newLeverage)
    {
        this._leverage = newLeverage;
        return this;
    }

    public AccountBuilder WithLimitOrders(int newLimitOrders)
    {
        this._limitOrders = newLimitOrders;
        return this;
    }

    public AccountBuilder WithMarginSoMode(int newMarginSoMode)
    {
        this._marginSoMode = newMarginSoMode;
        return this;
    }

    public AccountBuilder WithTradeAllowed(int newTradeAllowed)
    {
        this._tradeAllowed = newTradeAllowed;
        return this;
    }

    public AccountBuilder WithTradeExpert(int newTradeExpert)
    {
        this._tradeExpert = newTradeExpert;
        return this;
    }

    public AccountBuilder WithMarginMode(int newMarginMode)
    {
        this._marginMode = newMarginMode;
        return this;
    }

    public AccountBuilder WithCurrencyDigits(int newCurrencyDigits)
    {
        this._currencyDigits = newCurrencyDigits;
        return this;
    }

    public AccountBuilder WithFifoClose(int newFifoClose)
    {
        this._fifoClose = newFifoClose;
        return this;
    }

    public AccountBuilder WithHedgeAllowed(int newHedgeAllowed)
    {
        this._hedgeAllowed = newHedgeAllowed;
        return this;
    }

    public AccountBuilder WithBalance(double newBalance)
    {
        this._balance = newBalance;
        return this;
    }

    public AccountBuilder WithCredit(double newCredit)
    {
        this._credit = newCredit;
        return this;
    }

    public AccountBuilder WithProfit(double newProfit)
    {
        this._profit = newProfit;
        return this;
    }

    public AccountBuilder WithEquity(double newEquity)
    {
        this._equity = newEquity;
        return this;
    }

    public AccountBuilder WithMargin(double newMargin)
    {
        this._margin = newMargin;
        return this;
    }

    public AccountBuilder WithMarginFree(double newMarginFree)
    {
        this._marginFree = newMarginFree;
        return this;
    }

    public AccountBuilder WithMarginLevel(double newMarginLevel)
    {
        this._marginLevel = newMarginLevel;
        return this;
    }

    public AccountBuilder WithMarginSoCal(double newMarginSoCal)
    {
        this._marginSoCal = newMarginSoCal;
        return this;
    }

    public AccountBuilder WithMarginSoSo(double newMarginSoSo)
    {
        this._marginSoSo = newMarginSoSo;
        return this;
    }

    public AccountBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public AccountBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }


    public Account Build()
    {
        return new Account()
        {
            Msg = _msg,
            Company = _company,
            Currency = _currency,
            Name = _name,
            Server = _server,
            Login = _login,
            TradeMode = _tradeMode,
            Leverage = _leverage,
            LimitOrders = _limitOrders,
            MarginSoMode = _marginSoMode,
            TradeAllowed = _tradeAllowed,
            TradeExpert = _tradeExpert,
            MarginMode = _marginMode,
            CurrencyDigits = _currencyDigits,
            FifoClose = _fifoClose,
            HedgeAllowed = _hedgeAllowed,
            Balance = _balance,
            Credit = _credit,
            Profit = _profit,
            Equity = _equity,
            Margin = _margin,
            MarginFree = _marginFree,
            MarginLevel = _marginLevel,
            MarginSoCal = _marginSoCal,
            MarginSoSo = _marginSoSo,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }

}

