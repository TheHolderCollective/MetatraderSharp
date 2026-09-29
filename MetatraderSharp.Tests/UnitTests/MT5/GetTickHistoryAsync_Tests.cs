using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT5;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT5;

public class GetTickHistoryAsync_Tests
{
    [Fact]
    public async Task GetTickHistoryAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockTickHistory = new TickHistoryBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/history/ticks").Respond("application/json", mockTickHistory.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var tickHistory = await mtClient.GetTickHistoryAsync("2025.09.30 20:05:00", "2025.09.30 20:10:00", "EURUSD", TickFlag.COPY_TICKS_ALL);

        //Assert
        tickHistory.Msg.Should().Be("TICK_HISTORY");
        tickHistory.Symbol.Should().Be("EURUSD");
        tickHistory.Ticks[0].Time.Should().Be("2026.09.11 20:05:01");
        tickHistory.Ticks[0].Ask.Should().Be(1.15967);
        tickHistory.Ticks[0].Bid.Should().Be(1.15967);
        tickHistory.Ticks[0].Flags.Should().Be(1154);
        tickHistory.Ticks[0].Last.Should().Be(0);
        tickHistory.Ticks[0].TimeMsc.Should().Be("2026.09.11 20:05:01.079");
        tickHistory.Ticks[0].Volume.Should().Be(0);
        tickHistory.Ticks[0].VolumeReal.Should().Be(0);
        tickHistory.Ticks[1].Time.Should().Be("2026.09.11 20:05:02");
        tickHistory.Ticks[1].Ask.Should().Be(1.15966);
        tickHistory.Ticks[1].Bid.Should().Be(1.15966);
        tickHistory.Ticks[1].Flags.Should().Be(1158);
        tickHistory.Ticks[1].Last.Should().Be(0);
        tickHistory.Ticks[1].TimeMsc.Should().Be("2026.09.11 20:05:02.984");
        tickHistory.Ticks[1].Volume.Should().Be(0);
        tickHistory.Ticks[1].VolumeReal.Should().Be(0);
        tickHistory.Ticks[2].Time.Should().Be("2026.09.11 20:05:03");
        tickHistory.Ticks[2].Ask.Should().Be(1.15965);
        tickHistory.Ticks[2].Bid.Should().Be(1.15965);
        tickHistory.Ticks[2].Flags.Should().Be(1158);
        tickHistory.Ticks[2].Last.Should().Be(0);
        tickHistory.Ticks[2].TimeMsc.Should().Be("2026.09.11 20:05:03.090");
        tickHistory.Ticks[2].Volume.Should().Be(0);
        tickHistory.Ticks[2].VolumeReal.Should().Be(0);
        tickHistory.ErrorID.Should().Be(0);
        tickHistory.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetTickHistoryAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/history/ticks").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var tickHistory = await mtClient.GetTickHistoryAsync("2025.09.30 20:05:00", "2025.09.30 20:10:00", "EURUSD", TickFlag.COPY_TICKS_ALL);

        //Assert
        tickHistory.ErrorID.Should().Be(QueryStatus.Error);
    }
}
