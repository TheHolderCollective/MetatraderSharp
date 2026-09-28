using RichardSzalay.MockHttp;
using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders;

namespace MetatraderSharp.Tests.MetatraderClientTests;

public class GetQuoteAsync_Tests
{
    [Fact]
    public async Task GetQuoteAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockQuote = new QuoteBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/quote").Respond("application/json", mockQuote.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var quote = await mtClient.GetQuoteAsync("EURUSD");

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

    [Fact]
    public async Task GetQuoteAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/quote").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var quote = await mtClient.GetQuoteAsync("EURUSD");

        // Assert
        quote.ErrorID.Should().Be(QueryStatus.Error);
    }

    [Fact]
    public async Task GetQuoteAsync_BadSymbol_Test()
    {
        // Arrange
        var mockQuote = new QuoteBuilder().WithAllExceptMessageNull()
                                          .WithSymbol("EURUSDw")
                                          .WithErrorID(4220)
                                          .WithErrorDescription("symbol select error")
                                          .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/quote").Respond("application/json", mockQuote.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var quote = await mtClient.GetQuoteAsync("EURUSDw");

        // Assert
        quote.Msg.Should().Be("QUOTE");
        quote.Symbol.Should().Be("EURUSDw");
        quote.Ask.Should().Be(0);
        quote.Bid.Should().Be(0);
        quote.Flags.Should().Be(0);
        quote.Time.Should().BeNull();
        quote.Volume.Should().Be(0);
        quote.ErrorID.Should().Be(4220);
        quote.ErrorDescription.Should().Be("symbol select error");
    }
}

