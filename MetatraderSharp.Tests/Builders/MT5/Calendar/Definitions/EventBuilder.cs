using MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.Builders.MT5;

public class EventBuilder
{
    private string? _time;
    private int _eventCountryID;
    private int _eventDigits;
    private string? _eventCode;
    private string? _eventFrequency;
    private int _eventID;
    private string? _eventImportance;
    private string? _eventMultiplier;
    private string? _eventName;
    private string? _eventSector;
    private string? _eventSourceUrl;
    private string? _eventTimeMode;
    private string? _eventType;
    private string? _eventUnit;
    private double _actualValue;
    private double _forecastValue;
    private double _previousValue;
    private double _revisedValue;
    private string? _impactType;
    private double _revision;
    private string? _period;

    public EventBuilder()
    {
        _time = "2025.01.27 16:30:00";
        _eventCountryID = 840;
        _eventDigits = 2;
        _eventCode = "chicago-fed-national-activity-index";
        _eventFrequency = "CALENDAR_FREQUENCY_MONTH";
        _eventID = 840080001;
        _eventImportance = "CALENDAR_IMPORTANCE_LOW";
        _eventMultiplier = "CALENDAR_MULTIPLIER_NONE";
        _eventName = "Chicago Fed National Activity Index";
        _eventSector = "CALENDAR_SECTOR_BUSINESS";
        _eventSourceUrl = "https://www.chicagofed.org";
        _eventTimeMode = "CALENDAR_TIMEMODE_DATETIME";
        _eventType = "CALENDAR_TYPE_INDICATOR";
        _eventUnit = "CALENDAR_UNIT_NONE";
        _actualValue = 0.15;
        _forecastValue = 0.24;
        _previousValue = -0.12;
        _revisedValue = -0.01;
        _impactType = "CALENDAR_UNIT_CURRENCY";
        _revision = 0;
        _period = "2024.12.01 00:00:00";
    }

    public EventBuilder WithTime(string newTime)
    {
        this._time = newTime;
        return this;
    }

    public EventBuilder WithEventCountryID(int newEventCountryID)
    {
        this._eventCountryID = newEventCountryID;
        return this;
    }

    public EventBuilder WithEventDigits(int newEventDigits)
    {
        this._eventDigits = newEventDigits;
        return this;
    }

    public EventBuilder WithEventCode(string newEventCode)
    {
        this._eventCode = newEventCode;
        return this;
    }

    public EventBuilder WithEventFrequency(string newEventFrequency)
    {
        this._eventFrequency = newEventFrequency;
        return this;
    }

    public EventBuilder WithEventID(int newEventID)
    {
        this._eventID = newEventID;
        return this;
    }

    public EventBuilder WithEventImportance(string newEventImportance)
    {
        this._eventImportance = newEventImportance;
        return this;
    }

    public EventBuilder WithEventMultiplier(string newEventMultiplier)
    {
        this._eventMultiplier = newEventMultiplier;
        return this;
    }

    public EventBuilder WithEventName(string newEventName)
    {
        this._eventName = newEventName;
        return this;
    }

    public EventBuilder WithEventSector(string newEventSector)
    {
        this._eventSector = newEventSector;
        return this;
    }

    public EventBuilder WithEventSourceUrl(string newEventSourceUrl)
    {
        this._eventSourceUrl = newEventSourceUrl;
        return this;
    }

    public EventBuilder WithEventTimeMode(string newEventTimeMode)
    {
        this._eventTimeMode = newEventTimeMode;
        return this;
    }

    public EventBuilder WithEventType(string newEventType)
    {
        this._eventType = newEventType;
        return this;
    }

    public EventBuilder WithEventUnit(string newEventUnit)
    {
        this._eventUnit = newEventUnit;
        return this;
    }

    public EventBuilder WithActualValue(double newActualValue)
    {
        this._actualValue = newActualValue;
        return this;
    }

    public EventBuilder WithForecastValue(double newForecastValue)
    {
        this._forecastValue = newForecastValue;
        return this;
    }

    public EventBuilder WithPreviousValue(double newPreviousValue)
    {
        this._previousValue = newPreviousValue;
        return this;
    }

    public EventBuilder WithRevisedValue(double newRevisedValue)
    {
        this._revisedValue = newRevisedValue;
        return this;
    }

    public EventBuilder WithImpactType(string newImpactType)
    {
        this._impactType = newImpactType;
        return this;
    }

    public EventBuilder WithRevision(double newRevision)
    {
        this._revision = newRevision;
        return this;
    }

    public EventBuilder WithPeriod(string newPeriod)
    {
        this._period = newPeriod;
        return this;
    }

    public Event Build()
    {
        return new Event()
        {
            Time = _time,
            EventCountryID = _eventCountryID,
            EventDigits = _eventDigits,
            EventCode = _eventCode,
            EventFrequency = _eventFrequency,
            EventID = _eventID,
            EventImportance = _eventImportance,
            EventMultiplier = _eventMultiplier,
            EventName = _eventName,
            EventSector = _eventSector,
            EventSourceUrl = _eventSourceUrl,
            EventTimeMode = _eventTimeMode,
            EventType = _eventType,
            EventUnit = _eventUnit,
            ActualValue = _actualValue,
            ForecastValue = _forecastValue,
            PreviousValue = _previousValue,
            RevisedValue = _revisedValue,
            ImpactType = _impactType,
            Revision = _revision,
            Period = _period,
        };
    }
}
