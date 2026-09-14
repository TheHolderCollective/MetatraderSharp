using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class IndicatorBuilder
{
    private string _msg;
    private List<double> _dataValues;
    private int _errorID;
    private string _errorDescription;

    public IndicatorBuilder()
    {
        _msg = "MA_INDICATOR";
        _dataValues = [111.017438];
        _errorID = 0;
        _errorDescription = "The operation completed successfully";
    }

    public IndicatorBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public IndicatorBuilder WithDataValues(List<double> newDataValues)
    {
        this._dataValues = newDataValues;
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
            DataValues = _dataValues,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}
