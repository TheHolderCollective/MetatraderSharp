using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT4;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT4;

public class GetOrderHistoryAsync_Tests
{
    [Fact]
    public async Task GetOrderHistoryAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockOrderHistory = new OrderHistoryBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/history/orders*").Respond("application/json", mockOrderHistory.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var orderHistory = await mtClient.GetOrderHistoryAsync("2026.09.01 00:00:00", "2026.09.20 00:00:00");

        // Assert
        orderHistory.Msg.Should().Be("TRADE_HISTORY");
        orderHistory.Trades.Should().NotBeNull();
        orderHistory.Trades.Should().NotBeEmpty().And.HaveCount(2);

        orderHistory.Trades[0].Ticket.Should().Be(296629269);
        orderHistory.Trades[0].Magic.Should().Be(0);
        orderHistory.Trades[0].Symbol.Should().Be("USDCAD");
        orderHistory.Trades[0].Lots.Should().Be(0.01);
        orderHistory.Trades[0].Type.Should().Be("sell");
        orderHistory.Trades[0].PriceOpen.Should().Be(1.37842);
        orderHistory.Trades[0].PriceClose.Should().Be(0);
        orderHistory.Trades[0].OpenTime.Should().Be("2026.09.08 22:51:20");
        orderHistory.Trades[0].CloseTime.Should().Be("");
        orderHistory.Trades[0].StopLoss.Should().Be(0);
        orderHistory.Trades[0].Swap.Should().Be(0);
        orderHistory.Trades[0].Commission.Should().Be(0);
        orderHistory.Trades[0].TakeProfit.Should().Be(0);
        orderHistory.Trades[0].Profit.Should().Be(-0.13);
        orderHistory.Trades[0].Comment.Should().Be("");
        orderHistory.Trades[0].Expiration.Should().Be("1970.01.01 00:00:00");

        orderHistory.Trades[1].Ticket.Should().Be(296629041);
        orderHistory.Trades[1].Magic.Should().Be(0);
        orderHistory.Trades[1].Symbol.Should().Be("EURUSD");
        orderHistory.Trades[1].Lots.Should().Be(0.01);
        orderHistory.Trades[1].Type.Should().Be("buy");
        orderHistory.Trades[1].PriceOpen.Should().Be(1.16253);
        orderHistory.Trades[1].PriceClose.Should().Be(0);
        orderHistory.Trades[1].OpenTime.Should().Be("2026.09.08 22:50:42");
        orderHistory.Trades[1].CloseTime.Should().Be("");
        orderHistory.Trades[1].StopLoss.Should().Be(0);
        orderHistory.Trades[1].Swap.Should().Be(0);
        orderHistory.Trades[1].Commission.Should().Be(0);
        orderHistory.Trades[1].TakeProfit.Should().Be(0);
        orderHistory.Trades[1].Profit.Should().Be(-0.14);
        orderHistory.Trades[1].Comment.Should().Be("");
        orderHistory.Trades[1].Expiration.Should().Be("1970.01.01 00:00:00");

        orderHistory.ErrorID.Should().Be(0);
        orderHistory.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task GetOrderHistoryAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/history/orders*").Respond("application/json","");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var orderHistory = await mtClient.GetOrderHistoryAsync("2026.09.01 00:00:00", "2026.09.20 00:00:00");

        // Assert
        orderHistory.ErrorID.Should().Be(QueryStatus.Error);
    }
}
