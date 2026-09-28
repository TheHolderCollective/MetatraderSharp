using RichardSzalay.MockHttp;
using FluentAssertions;
using MetatraderSharp.Extensions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses.Common;

namespace MetatraderSharp.Tests.Extensions;

public class SymbolListExtensions_Tests
{
    [Fact]
    public async Task SymbolListExtensions_CorrectSymbolCount_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/symbol/list")
                .Respond("application/json", "{\r\n  \"MSG\": \"SYMBOL_LIST\",\r\n  \"SYMBOLS\": [\r\n    {\r\n      \"NAME\": \"ZARJPY\",\r\n      \"TRADE_MODE\": 1,\r\n      \"DESCRIPTION\": \"South Africa Rand vs Japanese Yen\",\r\n      \"PATH\": \"FX EXOTICS DEMO\\\\ZARJPY\"\r\n    }\r\n  ],\r\n  \"ERROR_ID\": 0,\r\n  \"ERROR_DESCRIPTION\": \"no error\"\r\n}");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        SymbolList symbolList = await mtClient.GetSymbolListAsync();

        // Act
        int symbolCount = symbolList.SymbolCount();

        // Assert
        symbolCount.Should().Be(1);
    }

    [Fact]
    public async Task SymbolListExtensions_CorrectSymbolNames_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/symbol/list")
                .Respond("application/json", "{\r\n  \"MSG\": \"SYMBOL_LIST\",\r\n  \"SYMBOLS\": [\r\n    {\r\n      \"NAME\": \"ZARJPY\",\r\n      \"TRADE_MODE\": 1,\r\n      \"DESCRIPTION\": \"South Africa Rand vs Japanese Yen\",\r\n      \"PATH\": \"FX EXOTICS DEMO\\\\ZARJPY\"\r\n    }\r\n  ],\r\n  \"ERROR_ID\": 0,\r\n  \"ERROR_DESCRIPTION\": \"no error\"\r\n}");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        SymbolList symbolList = await mtClient.GetSymbolListAsync();

        // Act
        var symbolNames = symbolList.GetSymbolNames();

        // Assert
        symbolNames.Should().NotBeEmpty().And.HaveCount(1);
        symbolNames[0].Should().Be("ZARJPY");
    }
}

