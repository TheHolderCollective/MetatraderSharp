using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses.MT4;
using MetatraderSharp.Tests.Builders.MT4;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT4;

public class ModifyOrderAsync_Tests
{
    [Fact]
    public async Task ModifyOrderAsync_OrderSuccessfullyModified_Test()
    {
        // Arrange
        var mockOrderModifyResponse = new OrderResponseBuilder<OrderModifyResponse>().WithMsg("ORDER_MODIFY").Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/modify").Respond("application/json", mockOrderModifyResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var orderModifyResponse = await mtClient.ModifyOrderAsync(296644727,0.01);

        // Assert
        orderModifyResponse.Msg.Should().Be("ORDER_MODIFY");
        orderModifyResponse.Ticket.Should().Be(296644727);
        orderModifyResponse.ErrorID.Should().Be(0);
        orderModifyResponse.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task ModifyOrderAsync_OrderNoChange_Test()
    {
        // Arrange
        var mockOrderModifyResponse = new OrderResponseBuilder<OrderModifyResponse>().WithMsg("ORDER_MODIFY")
                                                                                     .WithErrorID(1)
                                                                                     .WithErrorDescription("no error, trade conditions not changed")
                                                                                     .Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/modify").Respond("application/json", mockOrderModifyResponse.ToString());

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var orderModifyResponse = await mtClient.ModifyOrderAsync(296644727, 0.00);

        // Assert
        orderModifyResponse.Msg.Should().Be("ORDER_MODIFY");
        orderModifyResponse.Ticket.Should().Be(296644727);
        orderModifyResponse.ErrorID.Should().Be(1);
        orderModifyResponse.ErrorDescription.Should().Be("no error, trade conditions not changed");
    }

    [Fact]
    public async Task ModifyOrderAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/modify").Respond("application/json", "");

        var httpClient = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(httpClient);

        // Act
        var orderModifyResponse = await mtClient.ModifyOrderAsync(296644727, 0.01);

        // Assert
        orderModifyResponse.ErrorID.Should().Be(QueryStatus.Error);
    }
}
