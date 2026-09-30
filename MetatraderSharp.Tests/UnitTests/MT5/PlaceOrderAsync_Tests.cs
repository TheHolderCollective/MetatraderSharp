using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT5;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT5;

public class PlaceOrderAsync_Tests
{
    [Fact]
    public async Task PlaceOrderAsync_OrderPlacedSuccessfully_Test()
    {
        // Arrange
        var mockOrderSendResponse = new OrderSendResponseBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order").Respond("application/json", mockOrderSendResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var orderSendResponse = await mtClient.PlaceOrderAsync("EURUSD", OrderType.ORDER_TYPE_BUY, 0.01);

        // Assert
        orderSendResponse.Msg.Should().Be("ORDER_SEND");
        orderSendResponse.Type.Should().Be("ORDER_TYPE_SELL");
        orderSendResponse.RetCode.Should().Be(10009);
        orderSendResponse.Deal.Should().Be(0);
        orderSendResponse.Order.Should().Be(112109367);
        orderSendResponse.Volume.Should().Be(0.01);
        orderSendResponse.Price.Should().Be(0);
        orderSendResponse.Bid.Should().Be(0);
        orderSendResponse.Ask.Should().Be(0);
        orderSendResponse.RequestID.Should().Be(3038003652);
        orderSendResponse.RetCodeExternal.Should().Be(0);
        orderSendResponse.ErrorID.Should().Be(0);
        orderSendResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task PlaceOrderAsync_InvalidSymbol_Test()
    {
        // Arrange
        var mockOrderSendResponse = new OrderSendResponseBuilder().WithType("ORDER_TYPE_BUY")
                                                                  .WithRetCode(10013)
                                                                  .WithOrder(0)
                                                                  .WithVolume(0)
                                                                  .WithRequestID(0)
                                                                  .WithErrorID(4301)
                                                                  .WithErrorDescription("Unknown symbol")
                                                                  .Build();
      
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order").Respond("application/json", mockOrderSendResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var orderSendResponse = await mtClient.PlaceOrderAsync("EURUSDl", OrderType.ORDER_TYPE_BUY, 0.01);

        // Assert
        orderSendResponse.Msg.Should().Be("ORDER_SEND");
        orderSendResponse.Type.Should().Be("ORDER_TYPE_BUY");
        orderSendResponse.RetCode.Should().Be(10013);
        orderSendResponse.Deal.Should().Be(0);
        orderSendResponse.Order.Should().Be(0);
        orderSendResponse.Volume.Should().Be(0);
        orderSendResponse.Price.Should().Be(0);
        orderSendResponse.Bid.Should().Be(0);
        orderSendResponse.Ask.Should().Be(0);
        orderSendResponse.RequestID.Should().Be(0);
        orderSendResponse.RetCodeExternal.Should().Be(0);
        orderSendResponse.ErrorID.Should().Be(4301);
        orderSendResponse.ErrorDescription.Should().Be("Unknown symbol");
    }

    [Fact]
    public async Task PlaceOrderAsync_InvalidVolume_Test()
    {
        // Arrange
        var mockOrderSendResponse = new OrderSendResponseBuilder().WithType("ORDER_TYPE_BUY")
                                                                  .WithRetCode(10014)
                                                                  .WithOrder(0)
                                                                  .WithVolume(0)
                                                                  .WithRequestID(0)
                                                                  .WithErrorID(4756)
                                                                  .WithErrorDescription("Trade request sending failed")
                                                                  .Build();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order").Respond("application/json", mockOrderSendResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var orderSendResponse = await mtClient.PlaceOrderAsync("EURUSD", OrderType.ORDER_TYPE_BUY, 0.00);

        // Assert
        orderSendResponse.Msg.Should().Be("ORDER_SEND");
        orderSendResponse.Type.Should().Be("ORDER_TYPE_BUY");
        orderSendResponse.RetCode.Should().Be(10014);
        orderSendResponse.Deal.Should().Be(0);
        orderSendResponse.Order.Should().Be(0);
        orderSendResponse.Volume.Should().Be(0);
        orderSendResponse.Price.Should().Be(0);
        orderSendResponse.Bid.Should().Be(0);
        orderSendResponse.Ask.Should().Be(0);
        orderSendResponse.RequestID.Should().Be(0);
        orderSendResponse.RetCodeExternal.Should().Be(0);
        orderSendResponse.ErrorID.Should().Be(4756);
        orderSendResponse.ErrorDescription.Should().Be("Trade request sending failed");
    }

    [Fact]
    public async Task PlaceOrderAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order").Respond("application/json", "");

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var orderSendResponse = await mtClient.PlaceOrderAsync("EURUSD", OrderType.ORDER_TYPE_BUY, 0.01);

        // Assert
        orderSendResponse.ErrorID.Should().Be(QueryStatus.Error);
    }

}
