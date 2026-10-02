using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses.Common;
using MetatraderSharp.Tests.Builders;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.Websockets;

public class TrackOHLCsAsync_Tests
{
    private readonly SymbolRequest correctSymbolRequest1;
    private readonly SymbolRequest correctSymbolRequest2;
    private readonly SymbolRequest incorrectSymbolRequest1;
    private readonly SymbolRequest incorrectSymbolRequest2;

    public TrackOHLCsAsync_Tests()
    {
        correctSymbolRequest1 = new SymbolRequest("EURUSD", TimeframesMT5.Period_M1, 2);
        correctSymbolRequest2 = new SymbolRequest("USDJPY", TimeframesMT5.Period_M1, 1);
        incorrectSymbolRequest1 = new SymbolRequest("EURUSDs", TimeframesMT5.Period_M1, 1);
        incorrectSymbolRequest2 = new SymbolRequest("USDJPYk", TimeframesMT5.Period_M1, 1);
    }

    [Fact]
    public async Task TrackOHLCsAsync_AllSymbolsCorrect_Test()
    {
        // Arrange
        var trackOHLCRequest = new TrackOHLCRequest([correctSymbolRequest1, correctSymbolRequest2]);
        var mockTrackOHLCResponse = new TrackResponseBuilder().WithMsg("TRACK_OHLC")
                                                              .WithSuccess(["EURUSD", "USDJPY"])
                                                              .WithErrorID(0)
                                                              .WithErrorDescription("The operation completed successfully")
                                                              .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/ohlc").Respond("application/json", mockTrackOHLCResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackOHLCResponse = await mtClient.TrackOHLCsAsync(trackOHLCRequest);

        // Assert
        trackOHLCResponse.Msg.Should().Be("TRACK_OHLC");
        trackOHLCResponse.Success.Should().NotBeEmpty();
        trackOHLCResponse.Success[0].Should().Be("EURUSD");
        trackOHLCResponse.Success[1].Should().Be("USDJPY");
        trackOHLCResponse.Fail.Should().BeEmpty();
        trackOHLCResponse.ErrorID.Should().Be(0);
        trackOHLCResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task TrackOHLCsAsync_OneIncorrectSymbol_Test()
    {
        // Arrange
        var trackOHLCRequest = new TrackOHLCRequest([correctSymbolRequest1, incorrectSymbolRequest2]);
        var mockTrackOHLCResponse = new TrackResponseBuilder().WithMsg("TRACK_OHLC")
                                                              .WithSuccess(["EURUSD"])
                                                              .WithFail(["USDJPYk"])
                                                              .WithErrorID(0)
                                                              .WithErrorDescription("The operation completed successfully")
                                                              .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/ohlc").Respond("application/json", mockTrackOHLCResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackOHLCResponse = await mtClient.TrackOHLCsAsync(trackOHLCRequest);

        // Assert
        trackOHLCResponse.Msg.Should().Be("TRACK_OHLC");
        trackOHLCResponse.Success.Should().NotBeEmpty();
        trackOHLCResponse.Fail.Should().NotBeEmpty(); 
        trackOHLCResponse.Success[0].Should().Be("EURUSD");
        trackOHLCResponse.Fail[0].Should().Be("USDJPYk");
        trackOHLCResponse.ErrorID.Should().Be(0);
        trackOHLCResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task TrackOHLCsAsync_AllSymbolsIncorrect_Test()
    {
        // Arrange
        var trackOHLCRequest = new TrackOHLCRequest([incorrectSymbolRequest1, incorrectSymbolRequest2]);
        var mockTrackOHLCResponse = new TrackResponseBuilder().WithMsg("TRACK_OHLC")
                                                              .WithSuccess([])
                                                              .WithFail(["EURUSDs","USDJPYk"])
                                                              .WithErrorDescription("Unexpected internal error")                                                              
                                                              .WithErrorID(4220)
                                                              .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/ohlc").Respond("application/json", mockTrackOHLCResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackOHLCResponse = await mtClient.TrackOHLCsAsync(trackOHLCRequest);

        // Assert
        trackOHLCResponse.Msg.Should().Be("TRACK_OHLC");
        trackOHLCResponse.Success.Should().BeEmpty();
        trackOHLCResponse.Fail.Should().NotBeEmpty();
        trackOHLCResponse.Fail[0].Should().Be("EURUSDs");
        trackOHLCResponse.Fail[1].Should().Be("USDJPYk");
        trackOHLCResponse.ErrorID.Should().Be(4220);
        trackOHLCResponse.ErrorDescription.Should().Be("Unexpected internal error");
    }

    [Fact]
    public async Task TrackOHLCsAsync_TrackingStoppedSuccessfully_Test()
    {
        // Arrange
        var trackOHLCRequest = new TrackOHLCRequest([]);
        var mockTrackPricesResponse = new TrackResponseBuilder().WithMsg("TRACK_OHLC")
                                                                .WithSuccess([])
                                                                .WithErrorID(0)
                                                                .WithErrorDescription("The operation completed successfully")
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/prices").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackOHLCResponse = await mtClient.TrackPricesAsync(TrackingCommand.Stop, [""]);

        // Assert
        trackOHLCResponse.Msg.Should().Be("TRACK_OHLC");
        trackOHLCResponse.Success.Should().BeEmpty();
        trackOHLCResponse.Fail.Should().BeEmpty();
        trackOHLCResponse.ErrorID.Should().Be(0);
        trackOHLCResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task TrackOHLCsAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var trackOHLCRequest = new TrackOHLCRequest([correctSymbolRequest1, correctSymbolRequest2]);
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/ohlc").Respond("application/json", "");

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var trackOHLCResponse = await mtClient.TrackOHLCsAsync(trackOHLCRequest);

        // Assert
        trackOHLCResponse.ErrorID.Should().Be(QueryStatus.Error);
    }
}
