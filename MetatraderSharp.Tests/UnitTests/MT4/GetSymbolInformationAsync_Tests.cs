using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT4;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT4;

public class GetSymbolInformationAsync_Tests
{
    [Fact]
    public async Task GetSymbolInformationAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockSymbolInfo = new SymbolInformationBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/symbol/info*").Respond("application/json", mockSymbolInfo.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var symbolInfo = await mtClient.GetSymbolInformationAsync("EURUSD");

        // Assert
        symbolInfo.Msg.Should().Be("SYMBOL_INFO");
        symbolInfo.Name.Should().Be("EURUSD");
        symbolInfo.Time.Should().Be("2026.09.02 20:56:00");
        symbolInfo.Digits.Should().Be(5);
        symbolInfo.SpreadFloat.Should().Be(1);
        symbolInfo.Spread.Should().Be(7);
        symbolInfo.TradeCalcMode.Should().Be(0);
        symbolInfo.TradeMode.Should().Be(2);
        symbolInfo.StartTime.Should().Be(0);
        symbolInfo.ExpirationTime.Should().Be(0);
        symbolInfo.TradesTopsLevel.Should().Be(1);
        symbolInfo.TradeFreezeLevel.Should().Be(0);
        symbolInfo.TradeExeMode.Should().Be(2);
        symbolInfo.SwapMode.Should().Be(0);
        symbolInfo.SwapRollOver3Days.Should().Be(3);
        symbolInfo.Point.Should().Be(1E-05);
        symbolInfo.SymbolTradeTickValue.Should().Be(1);
        symbolInfo.SymbolTradeTickValueProfit.Should().Be(0);
        symbolInfo.SymbolTradeTickValueLoss.Should().Be(0);
        symbolInfo.TradeTickSize.Should().Be(1E-05);
        symbolInfo.TradeContractSize.Should().Be(100000);
        symbolInfo.VolumeMin.Should().Be(0.01);
        symbolInfo.VolumeMax.Should().Be(100);
        symbolInfo.VolumeStep.Should().Be(0.01);
        symbolInfo.SymbolVolumeLimit.Should().Be(0);
        symbolInfo.SwapLong.Should().Be(-6.71);
        symbolInfo.SwapShort.Should().Be(3.69);
        symbolInfo.MarginInitial.Should().Be(0);
        symbolInfo.MarginMaintenance.Should().Be(0);
        symbolInfo.CurrencyBase.Should().Be("EUR");
        symbolInfo.CurrencyProfit.Should().Be("USD");
        symbolInfo.CurrencyMargin.Should().Be("EUR");
        symbolInfo.Description.Should().Be("Euro vs US Dollar");
        symbolInfo.Path.Should().Be(@"FX STAN DEMO\EURUSD");
        symbolInfo.SessionQuote.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(5);
        symbolInfo.SessionTrade.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(5);
        symbolInfo.ErrorID.Should().Be(0);
        symbolInfo.ErrorDescription.Should().Be("no error");
    }


    [Fact]
    public async Task GetSymbolInformationAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/symbol/info*").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var symbolInfo = await mtClient.GetSymbolInformationAsync("EURUSD");

        // Assert
        symbolInfo.ErrorID.Should().Be(QueryStatus.Error);
    }
}
