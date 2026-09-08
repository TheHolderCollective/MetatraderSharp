using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.Tests.Builders.MT4;

public class IndicatorBuilder
{
    private string _msg;
    private double _dataValue;
    private int _errorID;
    private string _errorDescription;

    public IndicatorBuilder()
    {
        _msg = "ATR_INDICATOR";
        _dataValue = 7.714E-05;
        _errorID = 0;
        _errorDescription = "no error";
    }

    public IndicatorBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public IndicatorBuilder WithDataValue(double newDataValue)
    {
        this._dataValue = newDataValue;
        return this;
    }

    public IndicatorBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public IndicatorBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public Indicator Build()
    {
        return new Indicator()
        {
            Msg = _msg,
            DataValue = _dataValue,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }

}
