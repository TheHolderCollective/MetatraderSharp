using RichardSzalay.MockHttp;
using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders;

namespace MetatraderSharp.Tests.Common;

public class GetSymbolListAsync_Tests
{
    [Fact]
    public async Task GetSymbolListAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockSymbolList = new SymbolListBuilder().Build(); 
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/symbol/list").Respond("application/json", mockSymbolList.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var symbolList = await mtClient.GetSymbolListAsync();

        // Assert
        symbolList.Msg.Should().Be("SYMBOL_LIST");
        symbolList.Symbols.Should().NotBeNull();
        symbolList.Symbols.Should().NotBeEmpty().And.HaveCount(4);
        symbolList.Symbols[0].Name.Should().Be("AUDJPY");
        symbolList.Symbols[0].TradeMode.Should().Be(2);
        symbolList.Symbols[0].Description.Should().Be("Australian Dollar vs Japanese Yen");
        symbolList.Symbols[0].Path.Should().Be("FX STAN DEMO\\AUDJPY");
        symbolList.Symbols[1].Name.Should().Be("CHFJPY");
        symbolList.Symbols[1].TradeMode.Should().Be(2);
        symbolList.Symbols[1].Description.Should().Be("Swiss Franc vs Japanese Yen");
        symbolList.Symbols[1].Path.Should().Be("FX STAN DEMO\\CHFJPY");
        symbolList.Symbols[2].Name.Should().Be("EURGBP");
        symbolList.Symbols[2].TradeMode.Should().Be(2);
        symbolList.Symbols[2].Description.Should().Be("Euro vs Great Britain Pound");
        symbolList.Symbols[2].Path.Should().Be("FX STAN DEMO\\EURGBP");
        symbolList.Symbols[3].Name.Should().Be("NZDCAD");
        symbolList.Symbols[3].TradeMode.Should().Be(2);
        symbolList.Symbols[3].Description.Should().Be("NZD vs Canadian Dollar");
        symbolList.Symbols[3].Path.Should().Be("FX EXOTICS DEMO\\NZDCAD");
        symbolList.ErrorID.Should().Be(0);
        symbolList.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task GetSymbolListAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/symbol/list").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var symbolList = await mtClient.GetSymbolListAsync();

        // Assert
        symbolList.ErrorID.Should().Be(QueryStatus.Error);
    }
}

