using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.Websockets;

public class TrackOrderEventsAsync_Tests
{
    [Fact]
    public async Task TrackOrderEventsAsync_TrackingStartedSuccessfully_Test()
    {
        // Arrange
        var mockTrackOrderEventsResponse = new TrackOrderEventsResponseBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/orders").Respond("application/json", mockTrackOrderEventsResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackOrderEventsResponse = await mtClient.TrackOrderEventsAsync(true);

        // Assert
        trackOrderEventsResponse.Msg.Should().Be("TRACK_TRADE_EVENTS");
        trackOrderEventsResponse.Enabled.Should().Be(true);
        trackOrderEventsResponse.ErrorID.Should().Be(0);
        trackOrderEventsResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task TrackOrderEventsAsync_TrackingEndedSuccessfully_Test()
    {
        // Arrange
        var mockTrackOrderEventsResponse = new TrackOrderEventsResponseBuilder().WithEnabled(false).Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/orders").Respond("application/json", mockTrackOrderEventsResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackOrderEventsResponse = await mtClient.TrackOrderEventsAsync(false);

        // Assert
        trackOrderEventsResponse.Msg.Should().Be("TRACK_TRADE_EVENTS");
        trackOrderEventsResponse.Enabled.Should().Be(false);
        trackOrderEventsResponse.ErrorID.Should().Be(0);
        trackOrderEventsResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task TrackOrderEventsAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/orders").Respond("application/json", "");

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackOrderEventsResponse = await mtClient.TrackOrderEventsAsync(true);

        // Assert
        trackOrderEventsResponse.ErrorID.Should().Be(QueryStatus.Error);
    }
}
