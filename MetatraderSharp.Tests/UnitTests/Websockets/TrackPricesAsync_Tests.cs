using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.Websockets;

public class TrackPricesAsync_Tests
{
    [Fact]
    public async Task TrackPricesAsync_AllSymbolsCorrect_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithErrorDescription("The operation completed successfully")
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/prices").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackPricesResponse = await mtClient.TrackPricesAsync(TrackingCommand.Start, ["EURUSD", "GBPUSD"]);

        // Assert
        trackPricesResponse.Msg.Should().Be("TRACK_PRICES");
        trackPricesResponse.Success.Should().NotBeEmpty();
        trackPricesResponse.Success[0].Should().Be("EURUSD");
        trackPricesResponse.Success[1].Should().Be("GBPUSD");
        trackPricesResponse.Fail.Should().BeEmpty();
        trackPricesResponse.ErrorID.Should().Be(0);
        trackPricesResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task TrackPricesAsync_OneIncorrectSymbol_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithSuccess(["EURUSD"])
                                                                .WithFail(["GBPUSDl"])
                                                                .WithErrorID(4001)
                                                                .WithErrorDescription("Unexpected internal error")
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/prices").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackPricesResponse = await mtClient.TrackPricesAsync(TrackingCommand.Start, ["EURUSD", "GBPUSDl"]);

        // Assert
        trackPricesResponse.Msg.Should().Be("TRACK_PRICES");
        trackPricesResponse.Success.Should().NotBeEmpty();
        trackPricesResponse.Fail.Should().NotBeEmpty();
        trackPricesResponse.Success[0].Should().Be("EURUSD");
        trackPricesResponse.Fail[0].Should().Be("GBPUSDl");
        trackPricesResponse.ErrorID.Should().Be(4001);
        trackPricesResponse.ErrorDescription.Should().Be("Unexpected internal error");
    }

    [Fact]
    public async Task TrackPricesAsync_AllSymbolsIncorrect_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithSuccess([])
                                                                .WithFail(["EURUSDs", "GBPUSDl"])
                                                                .WithErrorID(4001)
                                                                .WithErrorDescription("Unexpected internal error")
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/prices").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackPricesResponse = await mtClient.TrackPricesAsync(TrackingCommand.Start, ["EURUSD", "GBPUSD"]);

        // Assert
        trackPricesResponse.Msg.Should().Be("TRACK_PRICES");
        trackPricesResponse.Success.Should().BeEmpty();
        trackPricesResponse.Fail.Should().NotBeEmpty();
        trackPricesResponse.Fail[0].Should().Be("EURUSDs");
        trackPricesResponse.Fail[1].Should().Be("GBPUSDl");
        trackPricesResponse.ErrorID.Should().Be(4001);
        trackPricesResponse.ErrorDescription.Should().Be("Unexpected internal error");
    }

    [Fact]
    public async Task TrackPricesAsync_TrackingStoppedSuccessfully_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithSuccess([])
                                                                .WithErrorID(0)
                                                                .WithErrorDescription("The operation completed successfully")
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/prices").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackPricesResponse = await mtClient.TrackPricesAsync(TrackingCommand.Stop, [""]);

        // Assert
        trackPricesResponse.Msg.Should().Be("TRACK_PRICES");
        trackPricesResponse.Success.Should().BeEmpty();
        trackPricesResponse.Fail.Should().BeEmpty();
        trackPricesResponse.ErrorID.Should().Be(0);
        trackPricesResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task TrackPricesAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/prices").Respond("application/json", "");

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackPricesResponse = await mtClient.TrackOrderEventsAsync(true);

        // Assert
        trackPricesResponse.ErrorID.Should().Be(QueryStatus.Error);
    }
}

