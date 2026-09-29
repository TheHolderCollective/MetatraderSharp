using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT4;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT4;

public class GetOrderInfoAsync_Tests
{
    [Fact]
    public async Task GetOrderInfoAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockOrderInfo = new OrderInfoBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/info").Respond("application/json", mockOrderInfo.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var orderInfo = await mtClient.GetOrderInfoAsync(296629269);

        // Assert
        orderInfo.Msg.Should().Be("ORDER_INFO");
        orderInfo.Trade.Should().NotBeNull();
        orderInfo.ErrorID.Should().Be(0);
        orderInfo.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task GetOrderInfoAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/info").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var orderInfo = await mtClient.GetOrderInfoAsync(296629269);

        // Assert
        orderInfo.ErrorID.Should().Be(QueryStatus.Error);
    }


}
