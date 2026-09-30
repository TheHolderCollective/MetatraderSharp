using FluentAssertions;
using MetatraderSharp.Extensions;
using MetatraderSharp.MTsocketAPI.Responses.Common;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.Extensions;

public class PriceHistoryExtensions_Tests : IAsyncLifetime
{
    private readonly PriceHistory mockPriceHistory;
    private readonly MockHttpMessageHandler mockHttp;
    private readonly HttpClient httpClient;
    private readonly MT4Client mtClient;
    private PriceHistory priceHistory;

    public PriceHistoryExtensions_Tests()
    {
        mockPriceHistory = new PriceHistoryBuilder().Build();
        mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/history/prices*").Respond("application/json", mockPriceHistory.ToString());

        httpClient = mockHttp.ToHttpClient();
        mtClient = new MT4Client(httpClient);
    }

    public async Task InitializeAsync()
    {
        priceHistory = await mtClient.GetPriceHistoryAsync("EURUSD", TimeframesMT4.Period_M15, "2026.08.21 16:30:00", "2026.08.21 17:30:00");
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    [Fact]
    public void PriceHistoryExtensions_CorrectSymbolCount_Test()
    {
        // Act
        int rateCount = priceHistory.RateCount();

        // Assert
        rateCount.Should().Be(5);
    }

    [Fact]
    public void PriceHistoryExtensions_GetRates_Test()
    {
        // Act
        var rates = priceHistory.GetRates();

        // Assert
        rates.Should().NotBeEmpty().And.HaveCount(5);
    }

    [Fact]
    public void PriceHistoryExtensions_GetMaxOpenRate_Test()
    {
        // Act
        var maxOpenRate = priceHistory.GetMaxOpenRate();

        // Assert
        maxOpenRate.Should().NotBeNull();
        maxOpenRate.Open.Should().Be(1.16788);
        maxOpenRate.TickVolume.Should().Be(936);
    }

    [Fact]
    public void PriceHistoryExtensions_GetMinOpenRate_Test()
    {
        // Act
        var minOpenRate = priceHistory.GetMinOpenRate();

        // Assert
        minOpenRate.Should().NotBeNull();
        minOpenRate.Open.Should().Be(1.16714);
        minOpenRate.TickVolume.Should().Be(1397);
    }
}
