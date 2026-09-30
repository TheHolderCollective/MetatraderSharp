using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT5;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT5;

public class GetOrderInfoAsync_Tests
{
    [Fact]
    public async Task GetOrderInfoAsync_SuccessfulDeserialization_OpenedOrder_Test()
    {
        // Arrange
        var mockOrderInfo = new OrderInfoBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/info").Respond("application/json", mockOrderInfo.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var orderInfo = await mtClient.GetOrderInfoAsync(296629269);

        // Assert
        orderInfo.Msg.Should().Be("ORDER_INFO");
        orderInfo.OpenedOrder[0].Ticket.Should().Be(99647050);
        orderInfo.OpenedOrder[0].OpenTime.Should().Be("2026.09.02 07:20:05.528");
        orderInfo.OpenedOrder[0].TimeUpdate.Should().Be("2026.09.02 07:20:05.528");
        orderInfo.OpenedOrder[0].Type.Should().Be("ORDER_TYPE_BUY");
        orderInfo.OpenedOrder[0].Magic.Should().Be(0);
        orderInfo.OpenedOrder[0].Identifier.Should().Be(99647050);
        orderInfo.OpenedOrder[0].Reason.Should().Be(0);
        orderInfo.OpenedOrder[0].Volume.Should().Be(0.01);
        orderInfo.OpenedOrder[0].PriceOpen.Should().Be(1.1575);
        orderInfo.OpenedOrder[0].StopLoss.Should().Be(0);
        orderInfo.OpenedOrder[0].TakeProfit.Should().Be(0);
        orderInfo.OpenedOrder[0].PriceCurrent.Should().Be(1.15375);
        orderInfo.OpenedOrder[0].Swap.Should().Be(-0.85);
        orderInfo.OpenedOrder[0].Profit.Should().Be(-3.75);
        orderInfo.OpenedOrder[0].Symbol.Should().Be("EURUSD");
        orderInfo.OpenedOrder[0].Comment.Should().Be("");
        orderInfo.OpenedOrder[0].ExternalID.Should().Be("");
        orderInfo.OpenedOrder[0].Change.Should().Be(-0.32);
        orderInfo.PendingOrder.Should().BeEmpty();
        orderInfo.ErrorID.Should().Be(0);
        orderInfo.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetOrderInfoAsync_SuccessfulDeserialization_PendingOrder_Test()
    {
        // Arrange
        var mockOrderInfo = new OrderInfoBuilder().WithOpenedOrder([])
                                                  .WithPendingOrder([new PendingOrderBuilder().Build()])
                                                  .Build();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/info").Respond("application/json", mockOrderInfo.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var orderInfo = await mtClient.GetOrderInfoAsync(111173847);

        // Assert
        orderInfo.Msg.Should().Be("ORDER_INFO");
        orderInfo.OpenedOrder.Should().BeEmpty();
        orderInfo.PendingOrder[0].Ticket.Should().Be(111173847);
        orderInfo.PendingOrder[0].OpenTime.Should().Be("2026.09.02 07:20:05.528");
        orderInfo.PendingOrder[0].TimeUpdate.Should().Be("2026.09.02 07:20:05.528");
        orderInfo.PendingOrder[0].Type.Should().Be("ORDER_TYPE_SELL_LIMIT");
        orderInfo.PendingOrder[0].Magic.Should().Be(0);
        orderInfo.PendingOrder[0].Identifier.Should().Be(99647050);
        orderInfo.PendingOrder[0].Reason.Should().Be(0);
        orderInfo.PendingOrder[0].Volume.Should().Be(0.01);
        orderInfo.PendingOrder[0].PriceOpen.Should().Be(1.16801);
        orderInfo.PendingOrder[0].StopLoss.Should().Be(0);
        orderInfo.PendingOrder[0].TakeProfit.Should().Be(0);
        orderInfo.PendingOrder[0].PriceCurrent.Should().Be(1.15375);
        orderInfo.PendingOrder[0].Swap.Should().Be(-0.85);
        orderInfo.PendingOrder[0].Profit.Should().Be(-3.75);
        orderInfo.PendingOrder[0].Symbol.Should().Be("EURUSD");
        orderInfo.PendingOrder[0].Comment.Should().Be("");
        orderInfo.PendingOrder[0].ExternalID.Should().Be("");
        orderInfo.PendingOrder[0].Change.Should().Be(-0.32);
        orderInfo.PendingOrder[0].TimeDone.Should().Be("1970.01.01 00:00:00.0");
        orderInfo.PendingOrder[0].TimeSetup.Should().Be("2026.09.15 21:07:32.138");
        orderInfo.PendingOrder[0].OrderReason.Should().Be(0);
        orderInfo.PendingOrder[0].PositionID.Should().Be(0);
        orderInfo.PendingOrder[0].PositionByID.Should().Be(0);
        orderInfo.PendingOrder[0].VolumeInitial.Should().Be(0.01);
        orderInfo.PendingOrder[0].VolumeCurrent.Should().Be(0.01);
        orderInfo.PendingOrder[0].PriceStopLimit.Should().Be(0);
        orderInfo.ErrorID.Should().Be(0);
        orderInfo.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetOrderInfoAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/order/info").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var orderInfo = await mtClient.GetOrderInfoAsync(296629269);

        // Assert
        orderInfo.ErrorID.Should().Be(QueryStatus.Error);
    }
}
