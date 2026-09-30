using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT5;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT5;

public class GetOrderHistoryAsync_Tests
{
    [Fact]
    public async Task GetOrderHistoryAsync_SuccessfulDeserialization_PositionsMode_Test()
    {
        // Arrange
        var mockOrderHistory = new OrderHistoryBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/history/orders").Respond("application/json", mockOrderHistory.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var orderHistory = await mtClient.GetOrderHistoryAsync("2026.09.01 00:00:00", "2026.09.20 00:00:00", OrderHistoryMode.POSITIONS);

        // Assert
        orderHistory.Msg.Should().Be("TRADE_HISTORY");
        orderHistory.Mode.Should().Be("POSITIONS");
        orderHistory.Positions[0].OpenTime.Should().Be("2026.09.02 07:20:05.528");
        orderHistory.Positions[0].Symbol.Should().Be("EURUSD");
        orderHistory.Positions[0].Ticket.Should().Be(99646055);
        orderHistory.Positions[0].Type.Should().Be("BUY");
        orderHistory.Positions[0].Volume.Should().Be(0);
        orderHistory.Positions[0].PriceOpen.Should().Be(0);
        orderHistory.Positions[0].Magic.Should().Be(0);
        orderHistory.Positions[0].CloseTime.Should().Be("2026.09.08 21:24:54.986");
        orderHistory.Positions[0].PriceClose.Should().Be(1.16266);
        orderHistory.Positions[0].Profit.Should().Be(-2.77);
        orderHistory.Positions[0].Commission.Should().Be(0);
        orderHistory.Positions[0].Swap.Should().Be(-0.89);
        orderHistory.Positions[0].StopLoss.Should().Be(0);
        orderHistory.Positions[0].TakeProfit.Should().Be(0);
        orderHistory.Positions[0].Change.Should().Be(0);
        orderHistory.Orders.Should().BeEmpty();
        orderHistory.OrdersDeals.Should().BeEmpty();
        orderHistory.Deals.Should().BeEmpty();
        orderHistory.ErrorID.Should().Be(0);
        orderHistory.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetOrderHistoryAsync_SuccessfulDeserialization_DealsMode_Test()
    {
        // Arrange
        var mockOrderHistory = new OrderHistoryBuilder().WithMode("DEALS")
                                                        .WithPositions([])
                                                        .WithDeals([new DealBuilder().Build()])
                                                        .Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/history/orders").Respond("application/json", mockOrderHistory.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var orderHistory = await mtClient.GetOrderHistoryAsync("2026.09.01 00:00:00", "2026.09.20 00:00:00", OrderHistoryMode.DEALS);

        // Assert
        orderHistory.Msg.Should().Be("TRADE_HISTORY");
        orderHistory.Mode.Should().Be("DEALS");
        orderHistory.Deals[0].Time.Should().Be("2026.09.02 07:20:05.528");
        orderHistory.Deals[0].DealNumber.Should().Be(78522301);
        orderHistory.Deals[0].Symbol.Should().Be("EURUSD");
        orderHistory.Deals[0].Order.Should().Be(99647050);
        orderHistory.Deals[0].Position.Should().Be(99647050);
        orderHistory.Deals[0].Type.Should().Be("BUY");
        orderHistory.Deals[0].Reason.Should().Be("DEAL_REASON_CLIENT");
        orderHistory.Deals[0].Direction.Should().Be("IN");
        orderHistory.Deals[0].Price.Should().Be(1.1575);
        orderHistory.Deals[0].Volume.Should().Be(0.01);
        orderHistory.Deals[0].StopLoss.Should().Be(0);
        orderHistory.Deals[0].TakeProfit.Should().Be(0);
        orderHistory.Deals[0].Commission.Should().Be(0);
        orderHistory.Deals[0].Profit.Should().Be(0);
        orderHistory.Deals[0].Swap.Should().Be(0);
        orderHistory.Deals[0].Magic.Should().Be(0);
        orderHistory.Deals[0].Comment.Should().Be("");
        orderHistory.Orders.Should().BeEmpty();
        orderHistory.OrdersDeals.Should().BeEmpty();
        orderHistory.Positions.Should().BeEmpty();
        orderHistory.ErrorID.Should().Be(0);
        orderHistory.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetOrderHistoryAsync_SuccessfulDeserialization_OrdersMode_Test()
    {
        // Arrange
        var mockOrderHistory = new OrderHistoryBuilder().WithMode("ORDERS")
                                                        .WithPositions([])
                                                        .WithOrders([new OrderBuilder().Build()])
                                                        .Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/history/orders").Respond("application/json", mockOrderHistory.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var orderHistory = await mtClient.GetOrderHistoryAsync("2026.09.01 00:00:00", "2026.09.20 00:00:00", OrderHistoryMode.ORDERS);

        // Assert
        orderHistory.Msg.Should().Be("TRADE_HISTORY");
        orderHistory.Mode.Should().Be("ORDERS");
        orderHistory.Orders[0].TimeSetup.Should().Be("2026.08.26 23:51:47.255");
        orderHistory.Orders[0].Symbol.Should().Be("EURUSD");
        orderHistory.Orders[0].Ticket.Should().Be(99647050);
        orderHistory.Orders[0].Type.Should().Be("BUY LIMIT");
        orderHistory.Orders[0].VolumeInitial.Should().Be(0.01);
        orderHistory.Orders[0].VolumeCurrent.Should().Be(0);
        orderHistory.Orders[0].Price.Should().Be(1.1575);
        orderHistory.Orders[0].StopLoss.Should().Be(0);
        orderHistory.Orders[0].TakeProfit.Should().Be(0);
        orderHistory.Orders[0].State.Should().Be("filled");
        orderHistory.Orders[0].Magic.Should().Be(0);
        orderHistory.Orders[0].Comment.Should().Be("");
        orderHistory.Orders[0].TimeDone.Should().Be("2026.09.02 07:20:05.528");
        orderHistory.Orders[0].Position.Should().Be(99647050);
        orderHistory.OrdersDeals.Should().BeEmpty();
        orderHistory.Positions.Should().BeEmpty();
        orderHistory.Deals.Should().BeEmpty();
        orderHistory.ErrorID.Should().Be(0);
        orderHistory.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetOrderHistoryAsync_SuccessfulDeserialization_OrdersDealsMode_Test()
    {
        // Arrange
        var mockOrderHistory = new OrderHistoryBuilder().WithMode("ORDERS_DEALS")
                                                        .WithPositions([])
                                                        .WithOrdersDeals([new OrdersDealsBuilder().Build()])
                                                        .Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/history/orders").Respond("application/json", mockOrderHistory.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var orderHistory = await mtClient.GetOrderHistoryAsync("2026.09.01 00:00:00", "2026.09.20 00:00:00", OrderHistoryMode.ORDERS_DEALS);

        // Assert
        orderHistory.Msg.Should().Be("TRADE_HISTORY");
        orderHistory.Mode.Should().Be("ORDERS_DEALS");
        orderHistory.OrdersDeals[0].Time.Should().Be("2026.08.26 23:51:47.255");
        orderHistory.OrdersDeals[0].Ticket.Should().Be(99647050);
        orderHistory.OrdersDeals[0].Symbol.Should().Be("EURUSD");
        orderHistory.OrdersDeals[0].Type.Should().Be("BUY LIMIT");
        orderHistory.OrdersDeals[0].Volume.Should().Be(0.01);
        orderHistory.OrdersDeals[0].Price.Should().Be(1.1575);
        orderHistory.OrdersDeals[0].Magic.Should().Be(0);
        orderHistory.OrdersDeals[0].Comment.Should().Be("");
        orderHistory.OrdersDeals[0].Deals[0].Time.Should().Be("2026.09.02 07:20:05.528");
        orderHistory.OrdersDeals[0].Deals[0].Ticket.Should().Be(78522301);
        orderHistory.OrdersDeals[0].Deals[0].Type.Should().Be("IN");
        orderHistory.OrdersDeals[0].Deals[0].Reason.Should().Be("DEAL_REASON_CLIENT");
        orderHistory.OrdersDeals[0].Deals[0].Volume.Should().Be(0.01);
        orderHistory.OrdersDeals[0].Deals[0].Price.Should().Be(1.1575);
        orderHistory.OrdersDeals[0].Deals[0].Commission.Should().Be(0);
        orderHistory.OrdersDeals[0].Deals[0].Profit.Should().Be(0);
        orderHistory.OrdersDeals[0].Deals[0].Swap.Should().Be(0);
        orderHistory.OrdersDeals[0].Deals[0].Magic.Should().Be(0);
        orderHistory.OrdersDeals[0].Deals[0].Comment.Should().Be("");
        orderHistory.Orders.Should().BeEmpty();
        orderHistory.Positions.Should().BeEmpty();
        orderHistory.Deals.Should().BeEmpty();
        orderHistory.ErrorID.Should().Be(0);
        orderHistory.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetOrderHistoryAsync_WrongDate_Test()
    {
        // Arrange
        var mockOrderHistory = new OrderHistoryBuilder().WithMode("ORDERS_DEALS")
                                                        .WithPositions([])
                                                        .WithErrorID(5031)
                                                        .WithErrorDescription("Wrong date in the string")
                                                        .Build();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/history/orders").Respond("application/json", mockOrderHistory.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var orderHistory = await mtClient.GetOrderHistoryAsync("2026.09.331 00:00:00", "2026.09.20 00:00:00", OrderHistoryMode.ORDERS_DEALS);

        // Assert
        orderHistory.Msg.Should().Be("TRADE_HISTORY");
        orderHistory.Mode.Should().Be("ORDERS_DEALS");
        orderHistory.Orders.Should().BeEmpty();
        orderHistory.OrdersDeals.Should().BeEmpty();
        orderHistory.Positions.Should().BeEmpty();
        orderHistory.Deals.Should().BeEmpty();
        orderHistory.ErrorID.Should().Be(5031);
        orderHistory.ErrorDescription.Should().Be("Wrong date in the string");
    }

    [Fact]
    public async Task GetOrderHistoryAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/history/orders").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var orderHistory = await mtClient.GetOrderHistoryAsync("2026.09.01 00:00:00", "2026.09.20 00:00:00", OrderHistoryMode.ORDERS);

        // Assert
        orderHistory.ErrorID.Should().Be(QueryStatus.Error);
    }
}
