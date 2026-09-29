using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses.Common;
using MetatraderSharp.Tests.Builders.MT4;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT4;

public class GetOrderListAsync_Tests
{
    [Fact]
    public async Task GetOrderListAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockOrderList = new OrderListBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/list").Respond("application/json", mockOrderList.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var orderList = await mtClient.GetOrderListAsync();

        // Assert
        orderList.Msg.Should().Be("ORDER_LIST");
        orderList.Trades[0].Ticket.Should().Be(296629269);
        orderList.Trades[0].Magic.Should().Be(0);
        orderList.Trades[0].Symbol.Should().Be("USDCAD");
        orderList.Trades[0].Lots.Should().Be(0.01);
        orderList.Trades[0].Type.Should().Be("sell");
        orderList.Trades[0].PriceOpen.Should().Be(1.37842);
        orderList.Trades[0].PriceClose.Should().Be(0);
        orderList.Trades[0].OpenTime.Should().Be("2026.09.08 22:51:20");
        orderList.Trades[0].CloseTime.Should().Be("");
        orderList.Trades[0].StopLoss.Should().Be(0);
        orderList.Trades[0].Swap.Should().Be(0);
        orderList.Trades[0].Commission.Should().Be(0);
        orderList.Trades[0].TakeProfit.Should().Be(0);
        orderList.Trades[0].Profit.Should().Be(-0.13);
        orderList.Trades[0].Comment.Should().Be("");
        orderList.Trades[0].Expiration.Should().Be("1970.01.01 00:00:00");
        orderList.Trades[1].Ticket.Should().Be(296629041);
        orderList.Trades[1].Magic.Should().Be(0);
        orderList.Trades[1].Symbol.Should().Be("EURUSD");
        orderList.Trades[1].Lots.Should().Be(0.01);
        orderList.Trades[1].Type.Should().Be("buy");
        orderList.Trades[1].PriceOpen.Should().Be(1.16253);
        orderList.Trades[1].PriceClose.Should().Be(0);
        orderList.Trades[1].OpenTime.Should().Be("2026.09.08 22:50:42");
        orderList.Trades[1].CloseTime.Should().Be("");
        orderList.Trades[1].StopLoss.Should().Be(0);
        orderList.Trades[1].Swap.Should().Be(0);
        orderList.Trades[1].Commission.Should().Be(0);
        orderList.Trades[1].TakeProfit.Should().Be(0);
        orderList.Trades[1].Profit.Should().Be(-0.14);
        orderList.Trades[1].Comment.Should().Be("");
        orderList.Trades[1].Expiration.Should().Be("1970.01.01 00:00:00");
        orderList.ErrorID.Should().Be(0);
        orderList.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task GetOrderListAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/list").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var orderList = await mtClient.GetOrderListAsync();

        // Assert
        orderList.ErrorID.Should().Be(QueryStatus.Error);
    }
}
