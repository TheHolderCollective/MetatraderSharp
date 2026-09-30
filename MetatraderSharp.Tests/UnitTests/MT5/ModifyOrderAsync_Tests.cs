using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses.MT5;
using MetatraderSharp.Tests.Builders.MT5;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT5;

public class ModifyOrderAsync_Tests
{
    [Fact]
    public async Task ModifyOrderAsync_OrderSuccessfullyModified_Test()
    {
        // Arrange
        var mockOrderModifyResponse = new OrderResponseBuilder<OrderModifyResponse>().WithMsg("ORDER_MODIFY")
                                                                                     .WithTicket(120471643)
                                                                                     .WithType("SL_UPDATED")
                                                                                     .WithVolume(0.02)
                                                                                     .WithOrder(0)
                                                                                     .WithRequestID(3113131648)
                                                                                     .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/modify").Respond("application/json", mockOrderModifyResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var orderModifyResponse = await mtClient.ModifyOrderAsync(120471643, 1.13295);

        // Assert
        orderModifyResponse.Msg.Should().Be("ORDER_MODIFY");
        orderModifyResponse.Ticket.Should().Be(120471643);
        orderModifyResponse.Type.Should().Be("SL_UPDATED");
        orderModifyResponse.RetCode.Should().Be(10009);
        orderModifyResponse.Deal.Should().Be(0);
        orderModifyResponse.Order.Should().Be(0);
        orderModifyResponse.Volume.Should().Be(0.02);
        orderModifyResponse.Price.Should().Be(0);
        orderModifyResponse.Bid.Should().Be(0);
        orderModifyResponse.Ask.Should().Be(0);
        orderModifyResponse.RequestID.Should().Be(3113131648);
        orderModifyResponse.RetCodeExternal.Should().Be(0);
        orderModifyResponse.ErrorID.Should().Be(0);
        orderModifyResponse.ErrorDescription.Should().Be("The operation completed successfully");
    }


    [Fact]
    public async Task ModifyOrderAsync_TicketDoesntExist_Test()
    {
        // Arrange
        var mockOrderModifyResponse = new OrderResponseBuilder<OrderModifyResponse>().WithMsg("ORDER_MODIFY")
                                                                                    .WithTicket(1204716433)
                                                                                    .WithErrorID(4754)
                                                                                    .WithErrorDescription("Order not found")
                                                                                    .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/modify").Respond("application/json", mockOrderModifyResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var orderModifyResponse = await mtClient.ModifyOrderAsync(1204684733, 1.13295);

        // Assert
        orderModifyResponse.Msg.Should().Be("ORDER_MODIFY");
        orderModifyResponse.Ticket.Should().Be(1204716433);
        orderModifyResponse.ErrorID.Should().Be(4754);
        orderModifyResponse.ErrorDescription.Should().Be("Order not found");
    }

    [Fact]
    public async Task ModifyOrderAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/modify").Respond("application/json", "");

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(httpClient);

        // Act
        var orderModifyResponse = await mtClient.ModifyOrderAsync(120471643, 1.13295);

        //Assert
        orderModifyResponse.ErrorID.Should().Be(QueryStatus.Error);
    }
}
