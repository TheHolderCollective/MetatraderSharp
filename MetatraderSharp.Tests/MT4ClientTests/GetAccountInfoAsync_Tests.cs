using RichardSzalay.MockHttp;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.MTsocketAPI.Responses.MT4;

namespace MetatraderSharp.Tests.MT4ClientTests;

public class GetAccountInfoAsync_Tests
{
    [Fact]
    public async Task GetAccountInfoAsync_Success_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/account")
                .Respond("application/json", "{\r\n  \"MSG\": \"ACCOUNT_STATUS\",\r\n  " +
                                             "\"COMPANY\": \"MetaQuotes Software Corp.\",\r\n  \"CURRENCY\": \"USD\",\r\n " +
                                             " \"NAME\": \"User Demo\",\r\n  \"SERVER\": \"MetaQuotes-Demo\",\r\n  \"LOGIN\": 123456789,\r\n  " +
                                             "\"TRADE_MODE\": 0,\r\n  \"LEVERAGE\": 200,\r\n  \"LIMIT_ORDERS\": 100,\r\n  " +
                                             "\"MARGIN_SO_MODE\": 0,\r\n  \"TRADE_ALLOWED\": 1,\r\n  \"TRADE_EXPERT\": 1,\r\n  " +
                                             "\"BALANCE\": 10.02,\r\n  \"CREDIT\": 0,\r\n  \"PROFIT\": 0,\r\n  \"EQUITY\": 10.02,\r\n  " +
                                             "\"MARGIN\": 0,\r\n  \"MARGIN_FREE\": 10.02,\r\n  \"MARGIN_LEVEL\": 0,\r\n  \"MARGIN_SO_CAL\": 75,\r\n  " +
                                             "\"MARGIN_SO_SO\": 30,\r\n  \"ERROR_ID\": 0,\r\n  \"ERROR_DESCRIPTION\": \"no error\"\r\n}");
        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        Account accountInfo = await mtClient.GetAccountInfoAsync();

        // Assert
        Assert.Equal("ACCOUNT_STATUS", accountInfo.Msg);
        Assert.Equal("MetaQuotes Software Corp.", accountInfo.Company);
        Assert.Equal("USD", accountInfo.Currency);
        Assert.Equal("User Demo", accountInfo.Name);
        Assert.Equal("MetaQuotes-Demo", accountInfo.Server);
        Assert.Equal(123456789, accountInfo.Login);
        Assert.Equal(0, accountInfo.TradeMode);
        Assert.Equal(200, accountInfo.Leverage);
        Assert.Equal(100, accountInfo.LimitOrders);
        Assert.Equal(0, accountInfo.MarginSoMode);
        Assert.Equal(1, accountInfo.TradeAllowed);
        Assert.Equal(1, accountInfo.TradeExpert);
        Assert.Equal(10, 02, accountInfo.Balance);
        Assert.Equal(0, accountInfo.Credit);
        Assert.Equal(0, accountInfo.Profit);
        Assert.Equal(10, 02, accountInfo.Equity);
        Assert.Equal(0, accountInfo.Margin);
        Assert.Equal(10, 02, accountInfo.MarginFree);
        Assert.Equal(0, accountInfo.MarginLevel);
        Assert.Equal(75, accountInfo.MarginSoCal);
        Assert.Equal(30, accountInfo.MarginSoSo);
        Assert.Equal(0, accountInfo.ErrorID);
        Assert.Equal("no error", accountInfo.ErrorDescription);
        Assert.Null(accountInfo.Demo);
    }
}

