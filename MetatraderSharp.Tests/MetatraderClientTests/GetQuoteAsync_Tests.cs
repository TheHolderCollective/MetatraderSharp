using RichardSzalay.MockHttp;
using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses;

namespace MetatraderSharp.Tests.MetatraderClientTests;

public class GetQuoteAsync_Tests
{

    [Fact]
    public async Task GetQuoteAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/quote")
                .Respond("application/json", "{\r\n  \"MSG\": \"QUOTE\",\r\n  \"SYMBOL\": \"EURUSD\",\r\n  \"ASK\": 1.16627,\r\n  \"BID\": 1.1662,\r\n  " +
                                             " \"FLAGS\": 6,\r\n  \"TIME\": \"2026.08.24 22:45:29.0\",\r\n  \"VOLUME\": 0,\r\n  \"ERROR_ID\": 0,\r\n  " +
                                             "\"ERROR_DESCRIPTION\": \"no error\"\r\n}");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        Quote quote = await mtClient.GetQuoteAsync("EURUSD");

        // Assert
        quote.Msg.Should().Be("QUOTE");
        quote.Symbol.Should().Be("EURUSD");
        quote.Ask.Should().Be(1.16627);
        quote.Bid.Should().Be(1.1662);
        quote.Flags.Should().Be(6);
        quote.Time.Should().Be("2026.08.24 22:45:29.0");
        quote.Volume.Should().Be(0);
        quote.ErrorID.Should().Be(0);
        quote.ErrorDescription.Should().Be("no error");

    }
}

