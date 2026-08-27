using MetatraderSharp.MTsocketAPI.Responses;
using System.Text;

namespace MetatraderSharp.Extensions;

public static class TrackResponsesExtensions
{
    public static int SymbolCount(this TrackResponse trackResponse)
    {
        return trackResponse.Success.Count + trackResponse.Fail.Count;
    }

    public static int SuccessCount(this TrackResponse trackResponse)
    {
        return trackResponse.Success.Count;
    }

    public static int FailCount(this TrackResponse trackResponse)
    {
        return trackResponse.Fail.Count;
    }

    public static string SuccessfulSymbols(this TrackResponse trackResponse)
    {
        StringBuilder symbols = new();

        if(trackResponse.SuccessCount() > 0)
        {
            foreach(var symbol in trackResponse.Success)
            {
                symbols.Append(symbol + " ");
            }
        }

        return symbols.ToString();
    }

    public static string FailedSymbols(this TrackResponse trackResponse)
    {
        StringBuilder symbols = new();

        if (trackResponse.FailCount() > 0)
        {
            foreach (var symbol in trackResponse.Fail)
            {
                symbols.Append(symbol + " ");
            }
        }

        return symbols.ToString();
    }
}

