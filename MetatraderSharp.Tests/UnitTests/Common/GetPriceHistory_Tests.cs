using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.Common;

public class GetPriceHistory_Tests
{
    [Fact]
    public async Task GetPriceHistoryAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockPriceHistory = new PriceHistoryBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/history/prices*").Respond("application/json", mockPriceHistory.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var priceHistory = await mtClient.GetPriceHistoryAsync("EURUSD", TimeframesMT4.Period_M15, "2026.08.21 16:30:00", "2026.08.21 17:30:00");

        // Assert
        priceHistory.Msg.Should().Be("PRICE_HISTORY");
        priceHistory.Symbol.Should().Be("EURUSD");
        priceHistory.TimeFrame.Should().Be("PERIOD_M15");
        priceHistory.Rates.Should().NotBeNull();
        priceHistory.Rates.Should().NotBeEmpty().And.HaveCount(5);
        priceHistory.ErrorID.Should().Be(0);
        priceHistory.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task GetPriceHistoryAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/history/prices*").Respond("application/json","");

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var priceHistory = await mtClient.GetPriceHistoryAsync("EURUSD", TimeframesMT4.Period_M15, "2026.08.21 16:30:00", "2026.08.21 17:30:00");

        // Assert
        priceHistory.ErrorID.Should().Be(QueryStatus.Error);
    }
}
