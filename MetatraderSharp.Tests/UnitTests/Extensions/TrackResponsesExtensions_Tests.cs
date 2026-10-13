using FluentAssertions;
using MetatraderSharp.Extensions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.Extensions;

public class TrackResponsesExtensions_Tests
{
    [Fact]
    public async Task TrackResponsesExtensions_SymbolCount_SuccessOnly_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithSuccess(["CADJPY", "EURUSD"])
                                                                .WithFail([])
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/prices").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);
        var trackResponse = await mtClient.TrackPricesAsync(TrackingCommand.Start, ["CADJPY", "EURUSD"]);

        // Act
        int successCount = trackResponse.SuccessCount();
        int failCount = trackResponse.FailCount();
        int totalCount = trackResponse.SymbolCount();

        // Assert
        successCount.Should().Be(2);
        failCount.Should().Be(0);
        totalCount.Should().Be(2);
    }

    [Fact]
    public async Task TrackResponsesExtensions_SymbolCount_FailOnly_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithSuccess([])
                                                                .WithFail(["CADJPY", "EURUSD"])
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/prices").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);
        var trackResponse = await mtClient.TrackPricesAsync(TrackingCommand.Start, ["CADJPY", "EURUSD"]);

        //Act
        int successCount = trackResponse.SuccessCount();
        int failCount = trackResponse.FailCount();
        int totalCount = trackResponse.SymbolCount();

        // Assert
        successCount.Should().Be(0);
        failCount.Should().Be(2);
        totalCount.Should().Be(2);
    }

    [Fact]
    public async Task TrackResponsesExtensions_SymbolCount_All_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithSuccess(["AUDUSD"])
                                                                .WithFail(["CADJPY", "EURUSD"])
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/prices").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);
        var trackResponse = await mtClient.TrackPricesAsync(TrackingCommand.Start, ["AUDUSD", "CADJPY", "EURUSD"]);

        //Act
        int successCount = trackResponse.SuccessCount();
        int failCount = trackResponse.FailCount();
        int totalCount = trackResponse.SymbolCount();

        // Assert
        successCount.Should().Be(1);
        failCount.Should().Be(2);
        totalCount.Should().Be(3);
    }

    [Fact]
    public async Task TrackResponsesExtensions_SuccessfulSymbols_Test()
    {
        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithSuccess(["CADJPY", "EURUSD"])
                                                                .WithFail([])
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/prices").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);
        var trackResponse = await mtClient.TrackPricesAsync(TrackingCommand.Start, ["CADJPY", "EURUSD"]);

        // Act
        var successfulSymbols = trackResponse.SuccessfulSymbols();
        var failedSymbols = trackResponse.FailedSymbols();

        // Assert
        successfulSymbols.Should().Be("CADJPY EURUSD");
        failedSymbols.Should().Be(string.Empty);
    }

    [Fact]
    public async Task TrackResponsesExtensions_FailedSymbols_Test()
    {

        // Arrange
        var mockTrackPricesResponse = new TrackResponseBuilder().WithSuccess([])
                                                                .WithFail(["CADJPY", "EURUSD"])
                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/track/prices").Respond("application/json", mockTrackPricesResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);
        var trackResponse = await mtClient.TrackPricesAsync(TrackingCommand.Start, ["CADJPY", "EURUSD"]);

        // Act
        var successfulSymbols = trackResponse.SuccessfulSymbols();
        var failedSymbols = trackResponse.FailedSymbols();

        // Assert
        successfulSymbols.Should().Be(string.Empty);
        failedSymbols.Should().Be("CADJPY EURUSD");
    }
}
