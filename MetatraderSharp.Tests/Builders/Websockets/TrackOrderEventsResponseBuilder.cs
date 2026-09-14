using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

public class TrackOrderEventsResponseBuilder
{
    private string _msg;
    private bool _enabled;
    private int _errorID;
    private string _errorDescription;

    public TrackOrderEventsResponseBuilder()
    {
        _msg = "TRACK_TRADE_EVENTS";
        _enabled = true;
        _errorID = 0;
        _errorDescription = "The operation completed successfully";
    }

    public TrackOrderEventsResponseBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public TrackOrderEventsResponseBuilder WithEnabled(bool newEnabled)
    {
        this._enabled = newEnabled;
        return this;
    }

    public TrackOrderEventsResponseBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public TrackOrderEventsResponseBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public TrackOrderEventsResponse Build()
    {
        return new TrackOrderEventsResponse()
        {
            Msg = _msg,
            Enabled = _enabled,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}
