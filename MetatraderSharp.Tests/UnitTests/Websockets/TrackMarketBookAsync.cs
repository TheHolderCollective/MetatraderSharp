using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.Websockets;

public class TrackMarketBookAsync
{
    [Fact]
    public async Task TrackMarketBookAsync_AllSymbolsCorrect_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithMsg("TRACK_MBOOK")
                                                                .WithSuccess(["EURUSD", "CADJPY"])
                                                                .WithErrorID(0)
                                                                .WithErrorDescription("The operation completed successfully")
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/mbook").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackMarketBookResponse = await mtClient.TrackMarketBookAsync(["EURUSD", "GBPUSD"]);

        // Assert
        trackMarketBookResponse.Msg.Should().Be("TRACK_MBOOK");
        trackMarketBookResponse.Success.Should().NotBeEmpty();
        trackMarketBookResponse.Success[0].Should().Be("EURUSD");
        trackMarketBookResponse.Success[1].Should().Be("CADJPY");
        trackMarketBookResponse.Fail.Should().BeEmpty();
        trackMarketBookResponse.ErrorID.Should().Be(0);
        trackMarketBookResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task TrackMarketBookAsync_OneSymbolIncorrect_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithMsg("TRACK_MBOOK")
                                                                .WithSuccess(["EURUSD"])
                                                                .WithFail(["CADJPYl"])
                                                                .WithErrorID(-1)
                                                                .WithErrorDescription("Please check the failed symbol names and if the broker supports Market Depth")
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/mbook").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackMarketBookResponse = await mtClient.TrackMarketBookAsync(["EURUSD", "CADJPYl"]);

        // Assert
        trackMarketBookResponse.Msg.Should().Be("TRACK_MBOOK");
        trackMarketBookResponse.Success.Should().NotBeEmpty();
        trackMarketBookResponse.Fail.Should().NotBeEmpty();
        trackMarketBookResponse.Success[0].Should().Be("EURUSD");
        trackMarketBookResponse.Fail[0].Should().Be("CADJPYl");
        trackMarketBookResponse.ErrorID.Should().Be(-1);
        trackMarketBookResponse.ErrorDescription.Should().Be("Please check the failed symbol names and if the broker supports Market Depth");
    }

    [Fact]
    public async Task TrackMarketBookAsync_AllSymbolsIncorrect_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithMsg("TRACK_MBOOK")
                                                                .WithSuccess([])
                                                                .WithFail(["EURUSDp", "CADJPYl"])
                                                                .WithErrorID(-1)
                                                                .WithErrorDescription("Please check the failed symbol names and if the broker supports Market Depth")
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/mbook").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackMarketBookResponse = await mtClient.TrackMarketBookAsync(["EURUSDp", "CADJPYl"]);

        // Assert
        trackMarketBookResponse.Msg.Should().Be("TRACK_MBOOK");
        trackMarketBookResponse.Success.Should().BeEmpty();
        trackMarketBookResponse.Fail.Should().NotBeEmpty();
        trackMarketBookResponse.Fail[0].Should().Be("EURUSDp");
        trackMarketBookResponse.Fail[1].Should().Be("CADJPYl");
        trackMarketBookResponse.ErrorID.Should().Be(-1);
        trackMarketBookResponse.ErrorDescription.Should().Be("Please check the failed symbol names and if the broker supports Market Depth");
    }

    [Fact]
    public async Task TrackMarketBookAsync_TrackingStoppedSuccessfully_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithMsg("TRACK_MBOOK")
                                                                .WithSuccess([])                                                                
                                                                .WithErrorID(0)
                                                                .WithErrorDescription("The operation completed successfully")
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/mbook").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackMarketBookResponse = await mtClient.TrackMarketBookAsync([""]);

        // Assert
        trackMarketBookResponse.Msg.Should().Be("TRACK_MBOOK");
        trackMarketBookResponse.Success.Should().BeEmpty();
        trackMarketBookResponse.Fail.Should().BeEmpty();
        trackMarketBookResponse.ErrorID.Should().Be(0);
        trackMarketBookResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task TrackMarketBookAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/mbook").Respond("application/json", "");

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackMarketBookResponse = await mtClient.TrackMarketBookAsync(["EURUSD"]);

        // Assert
        trackMarketBookResponse.ErrorID.Should().Be(QueryStatus.Error);
    }
}
