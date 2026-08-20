using RichardSzalay.MockHttp;
using MetatraderSharp.MetatraderClient;
using MT4Responses = MetatraderSharp.MTsocketAPI.Responses.MT4;
using MT5Responses = MetatraderSharp.MTsocketAPI.Responses.MT5;

namespace MetatraderSharp.Tests.MetatraderClient;

public class GetTerminalInfoAsync_Tests
{
    [Fact]
    public void GetTerminalInfoAsync_Success_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/account")
                .Respond("application/json", "{\r\n  \"MSG\": \"TERMINAL_INFO\",\r\n  \"LANGUAGE\": \"English\",\r\n  " +
                                             "\"COMPANY\": \"AxiCorp Financial Services Pty Ltd\",\r\n  \"NAME\": \"MetaTrader 4 Axi Terminal\",\r\n " +
                                             " \"PATH\": \"C:\\\\Program Files (x86)\\\\MetaTrader 4 Axi Terminal\",\r\n " +
                                             " \"DATA_PATH\": \"C:\\\\Users\\\\User\\\\AppData\\\\Roaming\\\\MetaQuotes\\\\Terminal\\\\17B5FF217FE004B792EFA9D824B75EEC\",\r\n  " +
                                             "\"COMMONDATA_PATH\": \"C:\\\\Users\\\\User\\\\AppData\\\\Roaming\\\\MetaQuotes\\\\Terminal\\\\Common\",\r\n  " +
                                             "\"BUILD\": 1473,\r\n  \"COMMUNITY_ACCOUNT\": 0,\r\n  \"COMMUNITY_CONNECTION\": 0,\r\n  " +
                                             "\"CONNECTED\": 1,\r\n  \"DLLS_ALLOWED\": 0,\r\n  \"TRADE_ALLOWED\": 1,\r\n  \"EMAIL_ENABLED\": 0,\r\n " +
                                             " \"FTP_ENABLED\": 0,\r\n  \"NOTIFICATIONS_ENABLED\": 1,\r\n  \"MAXBARS\": 65000,\r\n  \"MQID\": 1,\r\n  " +
                                             "\"CODEPAGE\": 0,\r\n  \"CPU_CORES\": 4,\r\n  \"DISK_SPACE\": 132584,\r\n  \"MEMORY_PHYSICAL\": 16272,\r\n  " +
                                             "\"MEMORY_TOTAL\": 4095,\r\n  \"MEMORY_AVAILABLE\": 3751,\r\n  \"MEMORY_USED\": 344,\r\n  \"SCREEN_DPI\": 96,\r\n  " +
                                             "\"PING_LAST\": 68077,\r\n  \"ERROR_ID\": 0,\r\n  \"ERROR_DESCRIPTION\": \"no error\",\r\n  " +
                                             "\"DEMO\": \"MTsocketAPI running in DEMO mode (www.mtsocketapi.com)\"");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act


        // Assert
    }
}

