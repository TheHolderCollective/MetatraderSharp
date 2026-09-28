using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT4;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT4ClientTests;

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
        var mtClient = new MT4Client(client);

        // Act
        var accountInfo = await mtClient.GetAccountInfoAsync();

        // Assert
        accountInfo.Msg.Should().Be("ACCOUNT_STATUS");
        accountInfo.Company.Should().Be("MetaQuotes Software Corp.");
        accountInfo.Currency.Should().Be("USD");
        accountInfo.Name.Should().Be("User Demo");
        accountInfo.Server.Should().Be("MetaQuotes-Demo");
        accountInfo.Login.Should().Be(123456789);
        accountInfo.TradeMode.Should().Be(0);
        accountInfo.Leverage.Should().Be(200);
        accountInfo.LimitOrders.Should().Be(100);
        accountInfo.MarginSoMode.Should().Be(0);
        accountInfo.TradeAllowed.Should().Be(1);
        accountInfo.TradeExpert.Should().Be(1);
        accountInfo.Balance.Should().Be(10.02);
        accountInfo.Credit.Should().Be(0);
        accountInfo.Profit.Should().Be(0);
        accountInfo.Equity.Should().Be(10.02);
        accountInfo.Margin.Should().Be(0);
        accountInfo.MarginFree.Should().Be(10.02);
        accountInfo.MarginLevel.Should().Be(0);
        accountInfo.MarginSoCal.Should().Be(75);
        accountInfo.MarginSoSo.Should().Be(30);
        accountInfo.ErrorID.Should().Be(0);
        accountInfo.ErrorDescription.Should().Be("no error");
    }
    [Fact]
    public async Task GetAccountInfoAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/account").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var accountInfo = await mtClient.GetAccountInfoAsync();

        // Assert
        accountInfo.ErrorID.Should().Be(QueryStatus.Error);
    }
}

