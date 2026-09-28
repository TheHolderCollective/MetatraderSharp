using RichardSzalay.MockHttp;
using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders;

namespace MetatraderSharp.Tests.MetatraderClient;

public class GetTerminalInfoAsync_Tests
{
    [Fact]
    public async Task GetTerminalInfoAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockTerminalInfo = new TerminalInfoBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/terminal").Respond("application/json", mockTerminalInfo.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var terminalInfo = await mtClient.GetTerminalInfoAsync();

        // Assert
        terminalInfo.Msg.Should().Be("TERMINAL_INFO");
        terminalInfo.Language.Should().Be("English");
        terminalInfo.Company.Should().Be("Testing Corporation Ltd");
        terminalInfo.Name.Should().Be("MetaTrader 4 Test Terminal");
        terminalInfo.Path.Should().Be(@"C:\Program Files (x86)\MetaTrader 4 Test Terminal");
        terminalInfo.DataPath.Should().Be(@"C:\Users\User\AppData\Roaming\MetaQuotes\Terminal\ABCDEFG0000000000012345678910111");
        terminalInfo.CommonDataPath.Should().Be(@"C:\Users\User\AppData\Roaming\MetaQuotes\Terminal\Common");
        terminalInfo.Build.Should().Be(1473);
        terminalInfo.CommunityAccount.Should().Be(0);
        terminalInfo.CommunityConnection.Should().Be(0);
        terminalInfo.Connected.Should().Be(1);
        terminalInfo.DLLsAllowed.Should().Be(0);
        terminalInfo.TradeAllowed.Should().Be(1);
        terminalInfo.EmailEnabled.Should().Be(0);
        terminalInfo.FtpEnabled.Should().Be(0);
        terminalInfo.NotificationsEnabled.Should().Be(1);
        terminalInfo.MaxBars.Should().Be(65000);
        terminalInfo.MQID.Should().Be(1);
        terminalInfo.CodePage.Should().Be(0);
        terminalInfo.CpuCores.Should().Be(4);
        terminalInfo.DiskSpace.Should().Be(132584);
        terminalInfo.MemoryPhysical.Should().Be(16272);
        terminalInfo.MemoryTotal.Should().Be(4095);
        terminalInfo.MemoryAvailable.Should().Be(3751);
        terminalInfo.MemoryUsed.Should().Be(344);
        terminalInfo.ScreenDPI.Should().Be(96);
        terminalInfo.PingLast.Should().Be(68077);
        terminalInfo.ErrorID.Should().Be(0);
        terminalInfo.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task GetTerminalInfoAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When("http://127.0.0.1:81/v1/terminal").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var terminalInfo = await mtClient.GetTerminalInfoAsync();

        // Assert
        terminalInfo.ErrorID.Should().Be(QueryStatus.Error);
    }
}