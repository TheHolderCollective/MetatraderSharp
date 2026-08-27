using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Extensions;

public static class SymbolListExtensions
{
    public static int SymbolCount(this SymbolList symbolList)
    {
        return symbolList.Symbols.Count;
    }

    public static List<string> GetSymbolNames(this SymbolList symbolList)
    {
        List<string> symbolNames = new();

        if (symbolList.SymbolCount() > 0)
        {
            foreach (var symbol in symbolList.Symbols)
            {
                if (symbol.Name is not null)
                    symbolNames.Add(symbol.Name);
            }
        }

        return symbolNames;
    }

}

