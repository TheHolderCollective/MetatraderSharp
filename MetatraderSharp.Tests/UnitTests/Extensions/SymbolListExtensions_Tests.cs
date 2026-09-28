using FluentAssertions;
using MetatraderSharp.Extensions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses.Common;
using MetatraderSharp.Tests.Builders;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.Extensions;

public class SymbolListExtensions_Tests
{
    [Fact]
    public async Task SymbolListExtensions_CorrectSymbolCount_Test()
    {
        // Arrange
        var mockSymbolList = new SymbolListBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/symbol/list").Respond("application/json", mockSymbolList.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        var symbolList = await mtClient.GetSymbolListAsync();

        // Act
        int symbolCount = symbolList.SymbolCount();

        // Assert
        symbolCount.Should().Be(4);
    }

    [Fact]
    public async Task SymbolListExtensions_CorrectSymbolNames_Test()
    {
        // Arrange
        var mockSymbolList = new SymbolListBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/symbol/list").Respond("application/json", mockSymbolList.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        var symbolList = await mtClient.GetSymbolListAsync();

        // Act
        var symbolNames = symbolList.GetSymbolNames();

        // Assert
        symbolNames.Should().NotBeEmpty().And.HaveCount(4);
        symbolNames[0].Should().Be("AUDJPY");
        symbolNames[1].Should().Be("CHFJPY");
        symbolNames[2].Should().Be("EURGBP");
        symbolNames[3].Should().Be("NZDCAD");
    }
}

