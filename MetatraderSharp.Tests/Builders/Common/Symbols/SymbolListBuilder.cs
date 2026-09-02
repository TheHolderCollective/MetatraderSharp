using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

/// <summary>
/// Used to generate a SymbolList object populated with data
/// </summary>
public class SymbolListBuilder
{
    private string _msg;
    private List<Symbol> _symbols;
    private int _errorID;
    private string _errorDescription;

    public SymbolListBuilder()
    {
        _msg = "SYMBOL_LIST";
        _symbols = new SymbolsListBuilder().Build();
        _errorID = 0;
        _errorDescription = "no error";
    }

    public SymbolListBuilder WithMsg(string newMsg)
    {
        this._msg = newMsg;
        return this;
    }

    public SymbolListBuilder WithSymbols(List<Symbol> newSymbols)
    {
        this._symbols = newSymbols;
        return this;
    }

    public SymbolListBuilder WithErrorID(int newErrorID)
    {
        this._errorID = newErrorID;
        return this;
    }

    public SymbolListBuilder WithErrorDescription(string newErrorDescription)
    {
        this._errorDescription = newErrorDescription;
        return this;
    }

    public SymbolList Build()
    {
        return new SymbolList()
        {
            Msg = _msg,
            Symbols = _symbols,
            ErrorID = _errorID,
            ErrorDescription = _errorDescription,
        };
    }

}
