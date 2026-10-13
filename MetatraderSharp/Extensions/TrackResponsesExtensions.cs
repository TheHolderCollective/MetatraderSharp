using MetatraderSharp.MTsocketAPI.Responses.Common;
using System.Text;

namespace MetatraderSharp.Extensions;

public static class TrackResponsesExtensions
{
    public static int SymbolCount(this TrackResponse trackResponse)
    {
        int symbolCount = 0;

        if (trackResponse.Success is not null)
            symbolCount = trackResponse.Success.Count;

        if (trackResponse.Fail is not null)
            symbolCount += trackResponse.Fail.Count;

        return symbolCount;
    }

    public static int SuccessCount(this TrackResponse trackResponse)
    {
        if (trackResponse.Success is null)
            return 0;

        return trackResponse.Success.Count;
    }

    public static int FailCount(this TrackResponse trackResponse)
    {
        if (trackResponse.Fail is null)
            return 0;

        return trackResponse.Fail.Count;
    }

    public static string SuccessfulSymbols(this TrackResponse trackResponse)
    {
        StringBuilder symbols = new();

        if (trackResponse.Success is null)
            return string.Empty;

        foreach (var symbol in trackResponse.Success)
        {
            symbols.Append(symbol + " ");
        }

        return symbols.ToString().Trim();
    }

    public static string FailedSymbols(this TrackResponse trackResponse)
    {
        StringBuilder symbols = new();

        if (trackResponse.Fail is null)
            return string.Empty;

        foreach (var symbol in trackResponse.Fail)
        {
            symbols.Append(symbol + " ");
        }

        return symbols.ToString().Trim();
    }
}

