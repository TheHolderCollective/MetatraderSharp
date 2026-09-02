using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

/// <summary>
/// Used to generates list of Symbols (List<Symbol>) for use in SymbolList class
/// </summary>
public class SymbolsListBuilder
{
    private List<Symbol> _symbols;

    public SymbolsListBuilder()
    {
        _symbols = new();
        _symbols.Add(new SymbolBuilder().Build());
        _symbols.Add(new SymbolBuilder().WithName("CHFJPY").WithDescription("Swiss Franc vs Japanese Yen").WithPath("FX STAN DEMO\\CHFJPY").Build());
        _symbols.Add(new SymbolBuilder().WithName("EURGBP").WithDescription("Euro vs Great Britain Pound").WithPath("FX STAN DEMO\\EURGBP").Build());
        _symbols.Add(new SymbolBuilder().WithName("NZDCAD").WithDescription("NZD vs Canadian Dollar").WithPath("FX EXOTICS DEMO\\NZDCAD").Build());
    }

    public SymbolsListBuilder WithNoDefaultSymbols()
    {
        _symbols.Clear();
        return this;
    }

    public SymbolsListBuilder WithSymbol(Symbol newSymbol)
    {
        _symbols.Add(newSymbol);
        return this;
    }

    public List<Symbol> Build()
    {
        return _symbols;
    }
}

