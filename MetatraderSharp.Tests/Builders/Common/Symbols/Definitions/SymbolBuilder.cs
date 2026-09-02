using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

/// <summary>
/// Used to generate Symbol objects for SymbolList class
/// </summary>
public class SymbolBuilder
{
    private string _name;
    private int _tradeMode;
    private string _description;
    private string _path;

    public SymbolBuilder()
    {
        _name = "AUDJPY";
        _tradeMode = 2;
        _description = "Australian Dollar vs Japanese Yen";
        _path = "FX STAN DEMO\\AUDJPY";
    }

    public SymbolBuilder WithName(string newName)
    {
        this._name = newName;
        return this;
    }

    public SymbolBuilder WithTradeMode(int newTradeMode)
    {
        this._tradeMode = newTradeMode;
        return this;
    }

    public SymbolBuilder WithDescription(string newDescription)
    {
        this._description = newDescription;
        return this;
    }

    public SymbolBuilder WithPath(string newPath)
    {
        this._path = newPath;
        return this;
    }

    public Symbol Build()
    {
        return new Symbol()
        {
            Name = _name,
            TradeMode = _tradeMode,
            Description = _description,
            Path = _path,
        };
    }
}
