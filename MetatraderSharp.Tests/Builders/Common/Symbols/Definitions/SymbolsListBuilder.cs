using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.Builders;

public class SymbolsListBuilder
{
    private List<Symbol> _symbols;

    public SymbolsListBuilder()
    {
        _symbols = new();
    }

    public List<Symbol> Build()
    {
        _symbols.Add(new SymbolBuilder().Build());
        _symbols.Add(new SymbolBuilder().WithName("CHFJPY").WithDescription("Swiss Franc vs Japanese Yen").WithPath("FX STAN DEMO\\CHFJPY").Build()); 
        _symbols.Add(new SymbolBuilder().WithName("EURGBP").WithDescription("Euro vs Great Britain Pound").WithPath("FX STAN DEMO\\EURGBP").Build()); 
        _symbols.Add(new SymbolBuilder().WithName("NZDCAD").WithDescription("NZD vs Canadian Dollar").WithPath("FX EXOTICS DEMO\\NZDCAD").Build()); 
  
        return _symbols;
    }
}

