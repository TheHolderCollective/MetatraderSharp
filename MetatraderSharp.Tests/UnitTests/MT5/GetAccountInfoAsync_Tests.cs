using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT5;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT5;

public class GetAccountInfoAsync_Tests
{
    [Fact]
    public async Task GetAccountInfoAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockAccount = new AccountBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/account").Respond("application/json", mockAccount.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var accountInfo = await mtClient.GetAccountInfoAsync();

        // Assert
        accountInfo.Msg.Should().Be("ACCOUNT_STATUS");
        accountInfo.Company.Should().Be("Test Company");
        accountInfo.Currency.Should().Be("USD");
        accountInfo.Name.Should().Be("Account User");
        accountInfo.Server.Should().Be("Test-Demo");
        accountInfo.Login.Should().Be(123456789);
        accountInfo.TradeMode.Should().Be(0);
        accountInfo.Leverage.Should().Be(500);
        accountInfo.LimitOrders.Should().Be(0);
        accountInfo.MarginSoMode.Should().Be(0);
        accountInfo.TradeAllowed.Should().Be(1);
        accountInfo.TradeExpert.Should().Be(1);
        accountInfo.MarginMode.Should().Be(2);
        accountInfo.CurrencyDigits.Should().Be(2);
        accountInfo.FifoClose.Should().Be(0);
        accountInfo.HedgeAllowed.Should().Be(1);
        accountInfo.Balance.Should().Be(99911.62);
        accountInfo.Credit.Should().Be(0);
        accountInfo.Profit.Should().Be(-2.57);
        accountInfo.Equity.Should().Be(99909.05);
        accountInfo.Margin.Should().Be(2.32);
        accountInfo.MarginFree.Should().Be(99906.73);
        accountInfo.MarginLevel.Should().Be(4306424.57);
        accountInfo.MarginSoCal.Should().Be(99);
        accountInfo.MarginSoSo.Should().Be(20);
        accountInfo.ErrorID.Should().Be(0);
        accountInfo.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetAccountInfoAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/account").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var accountInfo = await mtClient.GetAccountInfoAsync();

        // Assert
        accountInfo.ErrorID.Should().Be(QueryStatus.Error);
    }
}