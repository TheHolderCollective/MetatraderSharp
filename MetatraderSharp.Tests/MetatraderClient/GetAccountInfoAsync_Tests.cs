using RichardSzalay.MockHttp;
namespace MetatraderSharp.Tests.MetatraderClient;

public class GetAccountInfoAsync_Tests
{
    [Fact]
    public void GetAccountInfoAsync_Success_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/account")
                .Respond("application/json", "{\r\n  \"MSG\": \"ACCOUNT_STATUS\",\r\n  " +
                                             "\"COMPANY\": \"MetaQuotes Software Corp.\",\r\n  \"CURRENCY\": \"USD\",\r\n " +
                                             " \"NAME\": \"User Demo\",\r\n  \"SERVER\": \"MetaQuotes-Demo\",\r\n  \"LOGIN\": 169477868,\r\n  " +
                                             "\"TRADE_MODE\": 0,\r\n  \"LEVERAGE\": 200,\r\n  \"LIMIT_ORDERS\": 100,\r\n  " +
                                             "\"MARGIN_SO_MODE\": 0,\r\n  \"TRADE_ALLOWED\": 1,\r\n  \"TRADE_EXPERT\": 1,\r\n  " +
                                             "\"BALANCE\": 10.02,\r\n  \"CREDIT\": 0,\r\n  \"PROFIT\": 0,\r\n  \"EQUITY\": 10.02,\r\n  " +
                                             "\"MARGIN\": 0,\r\n  \"MARGIN_FREE\": 10.02,\r\n  \"MARGIN_LEVEL\": 0,\r\n  \"MARGIN_SO_CAL\": 75,\r\n  " +
                                             "\"MARGIN_SO_SO\": 30,\r\n  \"ERROR_ID\": 0,\r\n  \"ERROR_DESCRIPTION\": \"no error\"\r\n}");
        var client = mockHttp.ToHttpClient();

        // Act


        // Assert
    }
}

