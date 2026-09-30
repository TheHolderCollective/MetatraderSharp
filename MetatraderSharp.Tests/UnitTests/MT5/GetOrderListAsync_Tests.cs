using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT5;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT5;

public class GetOrderListAsync_Tests
{
    [Fact]
    public async Task GetOrderListAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockOrderInfo = new OrderListBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/list").Respond("application/json", mockOrderInfo.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var orderList = await mtClient.GetOrderListAsync();

        // Assert
        orderList.Msg.Should().Be("ORDER_LIST");
        orderList.Count.Should().Be(2);
        orderList.OpenedOrders[0].Ticket.Should().Be(99647050);
        orderList.OpenedOrders[0].OpenTime.Should().Be("2026.09.02 07:20:05.528");
        orderList.OpenedOrders[0].TimeUpdate.Should().Be("2026.09.02 07:20:05.528");
        orderList.OpenedOrders[0].Type.Should().Be("ORDER_TYPE_BUY");
        orderList.OpenedOrders[0].Magic.Should().Be(0);
        orderList.OpenedOrders[0].Identifier.Should().Be(99647050);
        orderList.OpenedOrders[0].Reason.Should().Be(0);
        orderList.OpenedOrders[0].Volume.Should().Be(0.01);
        orderList.OpenedOrders[0].PriceOpen.Should().Be(1.1575);
        orderList.OpenedOrders[0].StopLoss.Should().Be(0);
        orderList.OpenedOrders[0].TakeProfit.Should().Be(0);
        orderList.OpenedOrders[0].PriceCurrent.Should().Be(1.15375);
        orderList.OpenedOrders[0].Swap.Should().Be(-0.85);
        orderList.OpenedOrders[0].Profit.Should().Be(-3.75);
        orderList.OpenedOrders[0].Symbol.Should().Be("EURUSD");
        orderList.OpenedOrders[0].Comment.Should().Be("");
        orderList.OpenedOrders[0].ExternalID.Should().Be("");
        orderList.OpenedOrders[0].Change.Should().Be(-0.32);
        orderList.PendingOrders[0].Ticket.Should().Be(111173847);
        orderList.PendingOrders[0].OpenTime.Should().Be("2026.09.02 07:20:05.528");
        orderList.PendingOrders[0].TimeUpdate.Should().Be("2026.09.02 07:20:05.528");
        orderList.PendingOrders[0].Type.Should().Be("ORDER_TYPE_SELL_LIMIT");
        orderList.PendingOrders[0].Magic.Should().Be(0);
        orderList.PendingOrders[0].Identifier.Should().Be(99647050);
        orderList.PendingOrders[0].Reason.Should().Be(0);
        orderList.PendingOrders[0].Volume.Should().Be(0.01);
        orderList.PendingOrders[0].PriceOpen.Should().Be(1.16801);
        orderList.PendingOrders[0].StopLoss.Should().Be(0);
        orderList.PendingOrders[0].TakeProfit.Should().Be(0);
        orderList.PendingOrders[0].PriceCurrent.Should().Be(1.15375);
        orderList.PendingOrders[0].Swap.Should().Be(-0.85);
        orderList.PendingOrders[0].Profit.Should().Be(-3.75);
        orderList.PendingOrders[0].Symbol.Should().Be("EURUSD");
        orderList.PendingOrders[0].Comment.Should().Be("");
        orderList.PendingOrders[0].ExternalID.Should().Be("");
        orderList.PendingOrders[0].Change.Should().Be(-0.32);
        orderList.PendingOrders[0].TimeDone.Should().Be("1970.01.01 00:00:00.0");
        orderList.PendingOrders[0].TimeSetup.Should().Be("2026.09.15 21:07:32.138");
        orderList.PendingOrders[0].OrderReason.Should().Be(0);
        orderList.PendingOrders[0].PositionID.Should().Be(0);
        orderList.PendingOrders[0].PositionByID.Should().Be(0);
        orderList.PendingOrders[0].VolumeInitial.Should().Be(0.01);
        orderList.PendingOrders[0].VolumeCurrent.Should().Be(0.01);
        orderList.PendingOrders[0].PriceStopLimit.Should().Be(0);
        orderList.ErrorID.Should().Be(0);
        orderList.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetOrderListAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/list").Respond("application/json","");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var orderList = await mtClient.GetOrderListAsync();

        //Assert
        orderList.ErrorID.Should().Be(QueryStatus.Error);
    }

}
