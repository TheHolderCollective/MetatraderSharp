using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

public class TerminalInfoBuilder
{
    private string _msg;
    private string _language;
    private string _company;
    private string _name;
    private string _path;
    private string _dataPath;
    private string _commonDataPath;
    private double _build;
    private double _communityAccount;
    private double _communityConnection;
    private int _connected;
    private int _dLLsAllowed;
    private int _tradeAllowed;
    private int _emailEnabled;
    private int _ftpEnabled;
    private int _notificationsEnabled;
    private int _maxBars;
    private int _mQID;
    private int _codePage;
    private int _cpuCores;
    private double _diskSpace;
    private double _memoryPhysical;
    private double _memoryTotal;
    private double _memoryAvailable;
    private double _memoryUsed;
    private double _screenDPI;
    private double _pingLast;
    private int _errorID;
    private string _errorDescription;

    public TerminalInfoBuilder()
    {
        _msg = "TERMINAL_INFO";
        _language = "English";
        _company = "Testing Corporation Ltd";
        _name = "MetaTrader 4 Test Terminal";
        _path = @"C:\Program Files (x86)\MetaTrader 4 Test Terminal";
        _dataPath = @"C:\Users\User\AppData\Roaming\MetaQuotes\Terminal\ABCDEFG0000000000012345678910111";
        _commonDataPath = @"C:\Users\User\AppData\Roaming\MetaQuotes\Terminal\Common";
        _build = 1473;
        _communityAccount = 0;
        _communityConnection = 0;
        _connected = 1;
        _dLLsAllowed = 0;
        _tradeAllowed = 1;
        _emailEnabled = 0;
        _ftpEnabled = 0;
        _notificationsEnabled = 1;
        _maxBars = 65000;
        _mQID = 1;
        _codePage = 0;
        _cpuCores = 4;
        _diskSpace = 132584;
        _memoryPhysical = 16272;
        _memoryTotal = 4095;
        _memoryAvailable = 3751;
        _memoryUsed = 344;
        _screenDPI = 96;
        _pingLast = 68077;
        _errorID = 0;
        _errorDescription = "no error";
    }

    public TerminalInfoBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public TerminalInfoBuilder WithLanguage(string newLanguage)
    {
        this._language = newLanguage;
        return this;
    }

    public TerminalInfoBuilder WithCompany(string newCompany)
    {
        this._company = newCompany;
        return this;
    }

    public TerminalInfoBuilder WithName(string newName)
    {
        this._name = newName;
        return this;
    }

    public TerminalInfoBuilder WithPath(string newPath)
    {
        this._path = newPath;
        return this;
    }

    public TerminalInfoBuilder WithDataPath(string newDataPath)
    {
        this._dataPath = newDataPath;
        return this;
    }

    public TerminalInfoBuilder WithCommonDataPath(string newCommonDataPath)
    {
        this._commonDataPath = newCommonDataPath;
        return this;
    }

    public TerminalInfoBuilder WithBuild(double newBuild)
    {
        this._build = newBuild;
        return this;
    }

    public TerminalInfoBuilder WithCommunityAccount(double newCommunityAccount)
    {
        this._communityAccount = newCommunityAccount;
        return this;
    }

    public TerminalInfoBuilder WithCommunityConnection(double newCommunityConnection)
    {
        this._communityConnection = newCommunityConnection;
        return this;
    }

    public TerminalInfoBuilder WithConnected(int newConnected)
    {
        this._connected = newConnected;
        return this;
    }

    public TerminalInfoBuilder WithDLLsAllowed(int newDLLsAllowed)
    {
        this._dLLsAllowed = newDLLsAllowed;
        return this;
    }

    public TerminalInfoBuilder WithTradeAllowed(int newTradeAllowed)
    {
        this._tradeAllowed = newTradeAllowed;
        return this;
    }

    public TerminalInfoBuilder WithEmailEnabled(int newEmailEnabled)
    {
        this._emailEnabled = newEmailEnabled;
        return this;
    }

    public TerminalInfoBuilder WithFtpEnabled(int newFtpEnabled)
    {
        this._ftpEnabled = newFtpEnabled;
        return this;
    }

    public TerminalInfoBuilder WithNotificationsEnabled(int newNotificationsEnabled)
    {
        this._notificationsEnabled = newNotificationsEnabled;
        return this;
    }

    public TerminalInfoBuilder WithMaxBars(int newMaxBars)
    {
        this._maxBars = newMaxBars;
        return this;
    }

    public TerminalInfoBuilder WithMQID(int newMQID)
    {
        this._mQID = newMQID;
        return this;
    }

    public TerminalInfoBuilder WithCodePage(int newCodePage)
    {
        this._codePage = newCodePage;
        return this;
    }

    public TerminalInfoBuilder WithCpuCores(int newCpuCores)
    {
        this._cpuCores = newCpuCores;
        return this;
    }

    public TerminalInfoBuilder WithDiskSpace(double newDiskSpace)
    {
        this._diskSpace = newDiskSpace;
        return this;
    }

    public TerminalInfoBuilder WithMemoryPhysical(double newMemoryPhysical)
    {
        this._memoryPhysical = newMemoryPhysical;
        return this;
    }

    public TerminalInfoBuilder WithMemoryTotal(double newMemoryTotal)
    {
        this._memoryTotal = newMemoryTotal;
        return this;
    }

    public TerminalInfoBuilder WithMemoryAvailable(double newMemoryAvailable)
    {
        this._memoryAvailable = newMemoryAvailable;
        return this;
    }

    public TerminalInfoBuilder WithMemoryUsed(double newMemoryUsed)
    {
        this._memoryUsed = newMemoryUsed;
        return this;
    }

    public TerminalInfoBuilder WithScreenDPI(double newScreenDPI)
    {
        this._screenDPI = newScreenDPI;
        return this;
    }

    public TerminalInfoBuilder WithPingLast(double newPingLast)
    {
        this._pingLast = newPingLast;
        return this;
    }

    public TerminalInfoBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public TerminalInfoBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }


    public TerminalInfo Build()
    {
        return new TerminalInfo()
        {
            Msg = _msg,
            Language = _language,
            Company = _company,
            Name = _name,
            Path = _path,
            DataPath = _dataPath,
            CommonDataPath = _commonDataPath,
            Build = _build,
            CommunityAccount = _communityAccount,
            CommunityConnection = _communityConnection,
            Connected = _connected,
            DLLsAllowed = _dLLsAllowed,
            TradeAllowed = _tradeAllowed,
            EmailEnabled = _emailEnabled,
            FtpEnabled = _ftpEnabled,
            NotificationsEnabled = _notificationsEnabled,
            MaxBars = _maxBars,
            MQID = _mQID,
            CodePage = _codePage,
            CpuCores = _cpuCores,
            DiskSpace = _diskSpace,
            MemoryPhysical = _memoryPhysical,
            MemoryTotal = _memoryTotal,
            MemoryAvailable = _memoryAvailable,
            MemoryUsed = _memoryUsed,
            ScreenDPI = _screenDPI,
            PingLast = _pingLast,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }
}

