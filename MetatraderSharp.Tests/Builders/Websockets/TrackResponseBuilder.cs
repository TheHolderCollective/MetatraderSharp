using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

public class TrackResponseBuilder
{
    private string _msg;
    private List<string>? _success;
    private List<string>? _fail;
    private int _errorID;
    private string _errorDescription;

    public TrackResponseBuilder()
    {
        _msg = "TRACK_PRICES";
        _success =["EURUSD", "GBPUSD"];
        _fail = null;
        _errorID = 0;
        _errorDescription = "no error";
    }

    public TrackResponseBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public TrackResponseBuilder WithSuccess(List<string> newSuccess)
    {
        this._success = newSuccess;
        return this;
    }

    public TrackResponseBuilder WithFail(List<string> newFail)
    {
        this._fail = newFail;
        return this;
    }

    public TrackResponseBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public TrackResponseBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public TrackResponseBuilder WithTrackingSuccessfullyStopped()
    {
        this._success = null;
        this._fail = null;
        this._errorID = 0;
        this._errorDescription = "no error";
        return this;
    }

    public TrackResponse Build()
    {
        return new TrackResponse()
        {
            Msg = _msg,
            Success = _success,
            Fail = _fail,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}
