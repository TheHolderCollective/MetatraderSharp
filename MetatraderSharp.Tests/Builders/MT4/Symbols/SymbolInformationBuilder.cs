using MetatraderSharp.MTsocketAPI.Responses;
using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.Tests.Builders;

/// <summary>
/// Used to generate a SymbolInformation object populated with data
/// </summary>
public class SymbolInformationBuilder
{
    private string _msg;
    private string _name;
    private string _time;
    private int _digits;
    private int _spreadFloat;
    private int _spread;
    private int _tradeCalcMode;
    private int _tradeMode;
    private int _startTime;
    private int _expirationTime;
    private int _tradesTopsLevel;
    private int _tradeFreezeLevel;
    private int _tradeExeMode;
    private int _swapMode;
    private int _swapRollOver3Days;
    private double _point;
    private double _symbolTradeTickValue;
    private double _symbolTradeTickValueProfit;
    private double _symbolTradeTickValueLoss;
    private double _tradeTickSize;
    private double _tradeContractSize;
    private double _volumeMin;
    private double _volumeMax;
    private double _volumeStep;
    private double _symbolVolumeLimit;
    private double _swapLong;
    private double _swapShort;
    private double _marginInitial;
    private double _marginMaintenance;
    private string _currencyBase;
    private string _currencyProfit;
    private string _currencyMargin;
    private string _description;
    private string _path;
    private List<SessionQuote> _sessionQuote; 
    private List<SessionTrade> _sessionTrade;
    private int _errorID;
    private string _errorDescription;

    public SymbolInformationBuilder()
    {
        _msg = "SYMBOL_INFO";
        _name = "EURUSD";
        _time = "2026.09.02 20:56:00";
        _digits = 5;
        _spreadFloat = 1;
        _spread = 7;
        _tradeCalcMode = 0;
        _tradeMode = 2;
        _startTime = 0;
        _expirationTime = 0;
        _tradesTopsLevel = 1;
        _tradeFreezeLevel = 0;
        _tradeExeMode = 2;
        _swapMode = 0;
        _swapRollOver3Days = 3;
        _point = 1E-05;
        _symbolTradeTickValue = 1;
        _symbolTradeTickValueProfit = 0;
        _symbolTradeTickValueLoss = 0;
        _tradeTickSize = 1E-05;
        _tradeContractSize = 100000;
        _volumeMin = 0.01;
        _volumeMax = 100;
        _volumeStep = 0.01;
        _symbolVolumeLimit = 0;
        _swapLong = -6.71;
        _swapShort = 3.69;
        _marginInitial = 0;
        _marginMaintenance = 0;
        _currencyBase = "EUR";
        _currencyProfit = "USD";
        _currencyMargin = "EUR";
        _description = "Euro vs US Dollar";
        _path = @"FX STAN DEMO\EURUSD";
        _sessionQuote = new SessionQuoteListBuilder().Build();
        _sessionTrade = new SessionTradeListBuilder().Build();
        _errorID = 0;
        _errorDescription = "no error";
    }

    public SymbolInformationBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public SymbolInformationBuilder WithName(string newName)
    {
        this._name = newName;
        return this;
    }

    public SymbolInformationBuilder WithTime(string newTime)
    {
        this._time = newTime;
        return this;
    }

    public SymbolInformationBuilder WithDigits(int newDigits)
    {
        this._digits = newDigits;
        return this;
    }

    public SymbolInformationBuilder WithSpreadFloat(int newSpreadFloat)
    {
        this._spreadFloat = newSpreadFloat;
        return this;
    }

    public SymbolInformationBuilder WithSpread(int newSpread)
    {
        this._spread = newSpread;
        return this;
    }

    public SymbolInformationBuilder WithTradeCalcMode(int newTradeCalcMode)
    {
        this._tradeCalcMode = newTradeCalcMode;
        return this;
    }

    public SymbolInformationBuilder WithTradeMode(int newTradeMode)
    {
        this._tradeMode = newTradeMode;
        return this;
    }

    public SymbolInformationBuilder WithStartTime(int newStartTime)
    {
        this._startTime = newStartTime;
        return this;
    }

    public SymbolInformationBuilder WithExpirationTime(int newExpirationTime)
    {
        this._expirationTime = newExpirationTime;
        return this;
    }

    public SymbolInformationBuilder WithTradesTopsLevel(int newTradesTopsLevel)
    {
        this._tradesTopsLevel = newTradesTopsLevel;
        return this;
    }

    public SymbolInformationBuilder WithTradeFreezeLevel(int newTradeFreezeLevel)
    {
        this._tradeFreezeLevel = newTradeFreezeLevel;
        return this;
    }

    public SymbolInformationBuilder WithTradeExeMode(int newTradeExeMode)
    {
        this._tradeExeMode = newTradeExeMode;
        return this;
    }

    public SymbolInformationBuilder WithSwapMode(int newSwapMode)
    {
        this._swapMode = newSwapMode;
        return this;
    }

    public SymbolInformationBuilder WithSwapRollOver3Days(int newSwapRollOver3Days)
    {
        this._swapRollOver3Days = newSwapRollOver3Days;
        return this;
    }

    public SymbolInformationBuilder WithPoint(double newPoint)
    {
        this._point = newPoint;
        return this;
    }

    public SymbolInformationBuilder WithSymbolTradeTickValue(double newSymbolTradeTickValue)
    {
        this._symbolTradeTickValue = newSymbolTradeTickValue;
        return this;
    }

    public SymbolInformationBuilder WithSymbolTradeTickValueProfit(double newSymbolTradeTickValueProfit)
    {
        this._symbolTradeTickValueProfit = newSymbolTradeTickValueProfit;
        return this;
    }

    public SymbolInformationBuilder WithSymbolTradeTickValueLoss(double newSymbolTradeTickValueLoss)
    {
        this._symbolTradeTickValueLoss = newSymbolTradeTickValueLoss;
        return this;
    }

    public SymbolInformationBuilder WithTradeTickSize(double newTradeTickSize)
    {
        this._tradeTickSize = newTradeTickSize;
        return this;
    }

    public SymbolInformationBuilder WithTradeContractSize(double newTradeContractSize)
    {
        this._tradeContractSize = newTradeContractSize;
        return this;
    }

    public SymbolInformationBuilder WithVolumeMin(double newVolumeMin)
    {
        this._volumeMin = newVolumeMin;
        return this;
    }

    public SymbolInformationBuilder WithVolumeMax(double newVolumeMax)
    {
        this._volumeMax = newVolumeMax;
        return this;
    }

    public SymbolInformationBuilder WithVolumeStep(double newVolumeStep)
    {
        this._volumeStep = newVolumeStep;
        return this;
    }

    public SymbolInformationBuilder WithSymbolVolumeLimit(double newSymbolVolumeLimit)
    {
        this._symbolVolumeLimit = newSymbolVolumeLimit;
        return this;
    }

    public SymbolInformationBuilder WithSwapLong(double newSwapLong)
    {
        this._swapLong = newSwapLong;
        return this;
    }

    public SymbolInformationBuilder WithSwapShort(double newSwapShort)
    {
        this._swapShort = newSwapShort;
        return this;
    }

    public SymbolInformationBuilder WithMarginInitial(double newMarginInitial)
    {
        this._marginInitial = newMarginInitial;
        return this;
    }

    public SymbolInformationBuilder WithMarginMaintenance(double newMarginMaintenance)
    {
        this._marginMaintenance = newMarginMaintenance;
        return this;
    }

    public SymbolInformationBuilder WithCurrencyBase(string newCurrencyBase)
    {
        this._currencyBase = newCurrencyBase;
        return this;
    }

    public SymbolInformationBuilder WithCurrencyProfit(string newCurrencyProfit)
    {
        this._currencyProfit = newCurrencyProfit;
        return this;
    }

    public SymbolInformationBuilder WithCurrencyMargin(string newCurrencyMargin)
    {
        this._currencyMargin = newCurrencyMargin;
        return this;
    }

    public SymbolInformationBuilder WithDescription(string newDescription)
    {
        this._description = newDescription;
        return this;
    }

    public SymbolInformationBuilder WithPath(string newPath)
    {
        this._path = newPath;
        return this;
    }

    public SymbolInformationBuilder WithSessionQuote(List<SessionQuote> newSessionQuote)
    {
        this._sessionQuote = newSessionQuote;
        return this;
    }

    public SymbolInformationBuilder WithSessionTrade(List<SessionTrade> newSessionTrade)
    {
        this._sessionTrade = newSessionTrade;
        return this;
    }

    public SymbolInformationBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public SymbolInformationBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }


    public SymbolInformation Build()
    {
        return new SymbolInformation()
        {
            Msg = _msg,
            Name = _name,
            Time = _time,
            Digits = _digits,
            SpreadFloat = _spreadFloat,
            Spread = _spread,
            TradeCalcMode = _tradeCalcMode,
            TradeMode = _tradeMode,
            StartTime = _startTime,
            ExpirationTime = _expirationTime,
            TradesTopsLevel = _tradesTopsLevel,
            TradeFreezeLevel = _tradeFreezeLevel,
            TradeExeMode = _tradeExeMode,
            SwapMode = _swapMode,
            SwapRollOver3Days = _swapRollOver3Days,
            Point = _point,
            SymbolTradeTickValue = _symbolTradeTickValue,
            SymbolTradeTickValueProfit = _symbolTradeTickValueProfit,
            SymbolTradeTickValueLoss = _symbolTradeTickValueLoss,
            TradeTickSize = _tradeTickSize,
            TradeContractSize = _tradeContractSize,
            VolumeMin = _volumeMin,
            VolumeMax = _volumeMax,
            VolumeStep = _volumeStep,
            SymbolVolumeLimit = _symbolVolumeLimit,
            SwapLong = _swapLong,
            SwapShort = _swapShort,
            MarginInitial = _marginInitial,
            MarginMaintenance = _marginMaintenance,
            CurrencyBase = _currencyBase,
            CurrencyProfit = _currencyProfit,
            CurrencyMargin = _currencyMargin,
            Description = _description,
            Path = _path,
            SessionQuote = _sessionQuote,
            SessionTrade = _sessionTrade,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }

}
