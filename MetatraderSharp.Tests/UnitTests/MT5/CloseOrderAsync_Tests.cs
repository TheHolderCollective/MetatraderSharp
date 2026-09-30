using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses.MT5;
using MetatraderSharp.Tests.Builders.MT5;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT5;

public class CloseOrderAsync_Tests
{
    [Fact]
    public async Task CloseOrderAsync_OrderPartiallyClosedSuccessfully_Test()
    {
        // Arrange
        var mockOrderCloseResponse = new OrderResponseBuilder<OrderCloseResponse>().WithTicket(120467847)
                                                                                   .WithType("PARTIALLY_CLOSED")
                                                                                   .WithOrder(120467847)
                                                                                   .WithVolume(0.01)
                                                                                   .WithRequestID(3113131644)
                                                                                   .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/close").Respond("application/json", mockOrderCloseResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var orderCloseResponse = await mtClient.CloseOrderAsync(120467847);

        // Assert
        orderCloseResponse.Msg.Should().Be("ORDER_CLOSE");
        orderCloseResponse.Ticket.Should().Be(120467847);
        orderCloseResponse.Type.Should().Be("PARTIALLY_CLOSED");
        orderCloseResponse.RetCode.Should().Be(10009);
        orderCloseResponse.Deal.Should().Be(0);
        orderCloseResponse.Order.Should().Be(120467847);
        orderCloseResponse.Volume.Should().Be(0.01);
        orderCloseResponse.Price.Should().Be(0);
        orderCloseResponse.Bid.Should().Be(0);
        orderCloseResponse.Ask.Should().Be(0);
        orderCloseResponse.RequestID.Should().Be(3113131644);
        orderCloseResponse.RetCodeExternal.Should().Be(0);
        orderCloseResponse.ErrorID.Should().Be(0);
        orderCloseResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task CloseOrderAsync_OrderFullyClosedSuccessfully_Test()
    {
        // Arrange
        var mockOrderCloseResponse = new OrderResponseBuilder<OrderCloseResponse>().WithTicket(120467847)
                                                                                   .WithType("FULLY_CLOSED")
                                                                                   .WithOrder(120467847)
                                                                                   .WithRequestID(3113131646)
                                                                                   .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/close").Respond("application/json", mockOrderCloseResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var orderCloseResponse = await mtClient.CloseOrderAsync(120467847);

        // Assert
        orderCloseResponse.Msg.Should().Be("ORDER_CLOSE");
        orderCloseResponse.Ticket.Should().Be(120467847);
        orderCloseResponse.Type.Should().Be("FULLY_CLOSED");
        orderCloseResponse.RetCode.Should().Be(10009);
        orderCloseResponse.Deal.Should().Be(0);
        orderCloseResponse.Order.Should().Be(120467847);
        orderCloseResponse.Volume.Should().Be(0.01);
        orderCloseResponse.Price.Should().Be(0);
        orderCloseResponse.Bid.Should().Be(0);
        orderCloseResponse.Ask.Should().Be(0);
        orderCloseResponse.RequestID.Should().Be(3113131646);
        orderCloseResponse.RetCodeExternal.Should().Be(0);
        orderCloseResponse.ErrorID.Should().Be(0);
        orderCloseResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }


    [Fact]
    public async Task CloseOrderAsync_TicketDoesntExist_Test()
    {
        // Arrange
        var mockOrderCloseResponse = new OrderResponseBuilder<OrderCloseResponse>().WithTicket(120468473)                                                                                   
                                                                                   .WithErrorID(4754)
                                                                                   .WithErrorDescription("Order not found")
                                                                                   .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/close").Respond("application/json", mockOrderCloseResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var orderCloseResponse = await mtClient.CloseOrderAsync(120468473);

        // Assert
        orderCloseResponse.Msg.Should().Be("ORDER_CLOSE");
        orderCloseResponse.Ticket.Should().Be(120468473);
        orderCloseResponse.ErrorID.Should().Be(4754);
        orderCloseResponse.ErrorDescription.Should().Be("Order not found");
    }

    [Fact]
    public async Task CloseOrderAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/close").Respond("application/json", "");

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var orderCloseResponse = await mtClient.CloseOrderAsync(120467847);

        // Assert
        orderCloseResponse.ErrorID.Should().Be(QueryStatus.Error);
    }
}

