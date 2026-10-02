using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT4;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT4;

public class CloseOrderAsync_Tests
{
    [Fact]
    public async Task CloseOrderAsync_OrderClosedSuccessfully_Test()
    {
        // Arrange
        var mockOrderCloseResponse = new OrderCloseResponseBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/close").Respond("application/json", mockOrderCloseResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var orderCloseResponse = await mtClient.CloseOrderAsync(296644727);

        // Assert
        orderCloseResponse.Msg.Should().Be("ORDER_CLOSE");
        orderCloseResponse.Ticket.Should().Be(296644727);
        orderCloseResponse.Type.Should().Be("FULLY_CLOSED");
        orderCloseResponse.ErrorID.Should().Be(0);
        orderCloseResponse.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task CloseOrderAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/close").Respond("application/json","");

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var orderCloseResponse = await mtClient.CloseOrderAsync(296644727);

        // Assert
        orderCloseResponse.ErrorID.Should().Be(QueryStatus.Error);
    }


    [Fact]
    public async Task CloseOrderAsync_TicketDoesntExist_Test()
    {
        // Arrange
        var mockOrderCloseResponse = new OrderCloseResponseBuilder().WithTicket(1516862197)
                                                                    .WithType(null)
                                                                    .WithErrorID(4108)
                                                                    .WithErrorDescription("invalid ticket")
                                                                    .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/close").Respond("application/json", mockOrderCloseResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var orderCloseResponse = await mtClient.CloseOrderAsync(1516862197);

        // Assert
        orderCloseResponse.Msg.Should().Be("ORDER_CLOSE");
        orderCloseResponse.Ticket.Should().Be(1516862197);
        orderCloseResponse.Type.Should().BeNull();
        orderCloseResponse.ErrorID.Should().Be(4108);
        orderCloseResponse.ErrorDescription.Should().Be("invalid ticket");
    }

    [Fact]
    public async Task CloseOrderAsync_OrderPartiallyClosedSuccessfully_Test()
    {
        // Arrange
        var mockOrderCloseResponse = new OrderCloseResponseBuilder().WithTicket(364998759)
                                                                    .WithType("PARTIALLY_CLOSED")
                                                                    .WithErrorID(0)
                                                                    .WithErrorDescription("no error")
                                                                    .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/close").Respond("application/json", mockOrderCloseResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var orderCloseResponse = await mtClient.CloseOrderAsync(364998759);

        // Assert
        orderCloseResponse.Msg.Should().Be("ORDER_CLOSE");
        orderCloseResponse.Ticket.Should().Be(364998759);
        orderCloseResponse.Type.Should().Be("PARTIALLY_CLOSED");
        orderCloseResponse.ErrorID.Should().Be(0);
        orderCloseResponse.ErrorDescription.Should().Be("no error");
    }
}