## MetatraderSharp

A C# wrapper library which simplifies the use of MTsocketAPI for MT4 and MT5.

## Usage Requirements

Successful usage of the MetatraderSharp library requires:
- Metatrader 4/Metratrader 5 to be installed 
- a version of the MTsocketAPI installed in your Metatrader

The MT4/MT5 client should be instantiated with the port number which matches the http port used by the MTsocketAPI in the terminal. The default client uses port 81 to match the default settings of the MTsocketAPI.

## Quick Start Example 1
Using a default MT4 client:

```
﻿using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses.Common;

// setup default client which listens on MTsocketAPI default http port 81
MT4Client mtClient = new();

// check that client successfully connected to terminal
if (mtClient.ClientStatusIsError())
{
   // do something here if client status is error
   return;
}
else
{
   // get quote
   Quote quote = await mtClient.GetQuoteAsync("USDJPY");
   Console.WriteLine(quote);
}
```
## Quick Start Example 2

Using an MT5 client on http port 82:

```
using MetatraderSharp.MetatraderClient;
﻿using MetatraderSharp.MTsocketAPI.Responses.MT5;

// setup MT5 client to use http port 82
MT5Client mtClient = new("82");

// check that client successfully connected to terminal
if (mtClient.ClientStatusIsError())
{
   // do something here if client status is error
   return;
}
else
{
   string fromDate = "2025.01.26 21:15:00";
   string toDate = "2025.01.30 21:15:00";
   string countryCode = "US";
   string currency = "USD"; // this is optional

   // get calendar
   Calendar usCalendar = await mtClient.GetCalendarAsync(fromDate, toDate, countryCode, currency);

   Console.WriteLine($"Calendar events for {countryCode} from {fromDate} to {toDate}:");
   Console.WriteLine(usCalendar);
}
```

## Usage Examples
For complete examples on how to use the library please consult: [MetatraderSharp Cookbook](https://github.com/TheHolderCollective/MetatraderSharpCookbook)

## Disclaimer

I have no connection or affiliation with MTsocketAPI. This library is purely a labour of love which arose from my need to have an easy way to pull data from my MetaTrader terminals. See story [here](https://theholdercollective.github.io/posts/MetatraderSharp-Origins/).
