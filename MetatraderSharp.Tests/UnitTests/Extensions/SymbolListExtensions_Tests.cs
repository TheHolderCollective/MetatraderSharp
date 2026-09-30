using FluentAssertions;
using MetatraderSharp.Extensions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses.Common;
using MetatraderSharp.Tests.Builders;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.Extensions;

public class SymbolListExtensions_Tests : IAsyncLifetime
{
    private readonly SymbolList mockSymbolList;
    private readonly MockHttpMessageHandler mockHttp;
    private readonly HttpClient httpClient;
    private readonly MT4Client mtClient;
    private SymbolList symbolList;

    public SymbolListExtensions_Tests()
    {
        mockSymbolList = new SymbolListBuilder().Build();
        mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/symbol/list").Respond("application/json", mockSymbolList.ToString());

        httpClient = mockHttp.ToHttpClient();
        mtClient = new MT4Client(httpClient);
    }

    public async Task InitializeAsync()
    {
        symbolList = await mtClient.GetSymbolListAsync();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    [Fact]
    public void SymbolListExtensions_CorrectSymbolCount_Test()
    {
        // Act
        int symbolCount = symbolList.SymbolCount();

        // Assert
        symbolCount.Should().Be(4);
    }

    [Fact]
    public void SymbolListExtensions_CorrectSymbolNames_Test()
    {
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

