using FluentAssertions;
using MetatraderSharp.Extensions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.Extensions;

public class PriceHistoryExtensions_Tests
{
    [Fact]
    public async Task PriceHistoryExtensions_CorrectSymbolCount_Test()
    {
        // Arrange
        var mockPriceHistory = new PriceHistoryBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/history/prices*").Respond("application/json", mockPriceHistory.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        var priceHistory = await mtClient.GetPriceHistoryAsync("EURUSD", TimeframesMT4.Period_M15, "2026.08.21 16:30:00", "2026.08.21 17:30:00");

        // Act
        int rateCount = priceHistory.RateCount();

        // Assert
        rateCount.Should().Be(5);
    }

    [Fact]
    public async Task PriceHistoryExtensions_GetRates_Test()
    {
        // Arrange
        var mockPriceHistory = new PriceHistoryBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/history/prices*").Respond("application/json", mockPriceHistory.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        var priceHistory = await mtClient.GetPriceHistoryAsync("EURUSD", TimeframesMT4.Period_M15, "2026.08.21 16:30:00", "2026.08.21 17:30:00");

        // Act
        var rates = priceHistory.GetRates();

        // Assert
        rates.Should().NotBeEmpty().And.HaveCount(5);
    }

    [Fact]
    public async Task PriceHistoryExtensions_GetMaxOpenRate_Test()
    {
        // Arrange
        var mockPriceHistory = new PriceHistoryBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/history/prices*").Respond("application/json", mockPriceHistory.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        var priceHistory = await mtClient.GetPriceHistoryAsync("EURUSD", TimeframesMT4.Period_M15, "2026.08.21 16:30:00", "2026.08.21 17:30:00");

        // Act
        var maxOpenRate = priceHistory.GetMaxOpenRate();

        // Assert
        maxOpenRate.Should().NotBeNull();
        maxOpenRate.Open.Should().Be(1.16788);
        maxOpenRate.TickVolume.Should().Be(936);
    }

    [Fact]
    public async Task PriceHistoryExtensions_GetMinOpenRate_Test()
    {
        // Arrange
        var mockPriceHistory = new PriceHistoryBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/history/prices*").Respond("application/json", mockPriceHistory.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        var priceHistory = await mtClient.GetPriceHistoryAsync("EURUSD", TimeframesMT4.Period_M15, "2026.08.21 16:30:00", "2026.08.21 17:30:00");

        // Act
        var minOpenRate = priceHistory.GetMinOpenRate();

        // Assert
        minOpenRate.Should().NotBeNull();
        minOpenRate.Open.Should().Be(1.16714);
        minOpenRate.TickVolume.Should().Be(1397);
    }
}
