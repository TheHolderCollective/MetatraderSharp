using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses.MT4;
using MetatraderSharp.Tests.Builders.MT4;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT4;

public class PlaceOrderAsync_Tests
{
    [Fact]
    public async Task PlaceOrderAsync_OrderPlacedSuccessfully_Test()
    {
        // Arrange
        var mockOrderSendResponse = new OrderResponseBuilder<OrderSendResponse>().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order").Respond("application/json", mockOrderSendResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var orderSendResponse = await mtClient.PlaceOrderAsync("EURUSD", OrderType.ORDER_TYPE_BUY, 0.01);

        // Assert
        orderSendResponse.Msg.Should().Be("ORDER_SEND");
        orderSendResponse.Ticket.Should().Be(296644727);
        orderSendResponse.ErrorID.Should().Be(0);
        orderSendResponse.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task PlaceOrderAsync_InvalidSymbol_Test()
    {
        // Arrange
        var mockOrderSendResponse = new OrderResponseBuilder<OrderSendResponse>().WithTicket(-1)
                                                                                .WithErrorID(4106)
                                                                                .WithErrorDescription("unknown symbol")
                                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order").Respond("application/json", mockOrderSendResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var orderSendResponse = await mtClient.PlaceOrderAsync("EURUSDl", OrderType.ORDER_TYPE_BUY, 0.01);

        // Assert
        orderSendResponse.Msg.Should().Be("ORDER_SEND");
        orderSendResponse.Ticket.Should().Be(-1);
        orderSendResponse.ErrorID.Should().Be(4106);
        orderSendResponse.ErrorDescription.Should().Be("unknown symbol");
    }

    [Fact]
    public async Task PlaceOrderAsync_InvalidVolume_Test()
    {
        // Arrange
        var mockOrderSendResponse = new OrderResponseBuilder<OrderSendResponse>().WithTicket(-1)
                                                                                .WithErrorID(4051)
                                                                                .WithErrorDescription("invalid function parameter value")
                                                                                .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order").Respond("application/json", mockOrderSendResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var orderSendResponse = await mtClient.PlaceOrderAsync("EURUSD", OrderType.ORDER_TYPE_BUY, 0.00);

        // Assert
        orderSendResponse.Msg.Should().Be("ORDER_SEND");
        orderSendResponse.Ticket.Should().Be(-1);
        orderSendResponse.ErrorID.Should().Be(4051);
        orderSendResponse.ErrorDescription.Should().Be("invalid function parameter value");
    }

    [Fact]
    public async Task PlaceOrderAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order").Respond("application/json", "");

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var orderSendResponse = await mtClient.PlaceOrderAsync("EURUSD", OrderType.ORDER_TYPE_BUY, 0.01);

        // Assert
        orderSendResponse.ErrorID.Should().Be(QueryStatus.Error);
    }


}
