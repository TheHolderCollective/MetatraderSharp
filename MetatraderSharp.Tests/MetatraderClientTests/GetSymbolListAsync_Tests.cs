using RichardSzalay.MockHttp;
using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.MetatraderClientTests;

public class GetSymbolListAsync_Tests
{
    [Fact]
    public async Task GetSymbolListAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/symbol/list")
                .Respond("application/json", "{\r\n  \"MSG\": \"SYMBOL_LIST\",\r\n  \"SYMBOLS\": [\r\n    {\r\n      \"NAME\": \"ZARJPY\",\r\n      \"TRADE_MODE\": 1,\r\n      \"DESCRIPTION\": \"South Africa Rand vs Japanese Yen\",\r\n      \"PATH\": \"FX EXOTICS DEMO\\\\ZARJPY\"\r\n    }\r\n  ],\r\n  \"ERROR_ID\": 0,\r\n  \"ERROR_DESCRIPTION\": \"no error\"\r\n}");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        SymbolList symbolList = await mtClient.GetSymbolListAsync();

        // Assert
        symbolList.Msg.Should().Be("SYMBOL_LIST");
        symbolList.Symbols.Should().NotBeEmpty().And.HaveCount(1);
        symbolList.Symbols[0].Name.Should().Be("ZARJPY");
        symbolList.Symbols[0].TradeMode.Should().Be(1);
        symbolList.Symbols[0].Description.Should().Be("South Africa Rand vs Japanese Yen");
        symbolList.Symbols[0].Path.Should().Be(@"FX EXOTICS DEMO\ZARJPY");
        symbolList.ErrorID.Should().Be(0);
        symbolList.ErrorDescription.Should().Be("no error");
    }
}

