using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT5;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT5;

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
        var mtClient = new MT5Client(client);

        // Act
        var symbolInfo = await mtClient.GetSymbolInformationAsync("EURUSD");

        //Assert
        symbolInfo.Msg.Should().Be("SYMBOL_INFO");
        symbolInfo.Name.Should().Be("CADJPY");
        symbolInfo.Time.Should().Be("2026.09.14 23:40:25");
        symbolInfo.Digits.Should().Be(3);
        symbolInfo.SpreadFloat.Should().Be(1);
        symbolInfo.Spread.Should().Be(12);
        symbolInfo.TradeCalcMode.Should().Be(0);
        symbolInfo.TradeMode.Should().Be(4);
        symbolInfo.StartTime.Should().Be(0);
        symbolInfo.ExpirationTime.Should().Be(0);
        symbolInfo.TradesTopsLevel.Should().Be(1);
        symbolInfo.TradeFreezeLevel.Should().Be(0);
        symbolInfo.TradeExeMode.Should().Be(2);
        symbolInfo.SwapMode.Should().Be(1);
        symbolInfo.SwapRollOver3Days.Should().Be(3);
        symbolInfo.Point.Should().Be(0.001);
        symbolInfo.TradeTickValue.Should().Be(0.64758451);
        symbolInfo.TradeTickValueProfit.Should().Be(0.64758451);
        symbolInfo.TradeTickValueLoss.Should().Be(0.64761387);
        symbolInfo.TradeTickSize.Should().Be(0.001);
        symbolInfo.TradeContractSize.Should().Be(100000);
        symbolInfo.VolumeMin.Should().Be(0.01);
        symbolInfo.VolumeMax.Should().Be(100);
        symbolInfo.VolumeStep.Should().Be(0.01);
        symbolInfo.VolumeLimit.Should().Be(0);
        symbolInfo.SwapLong.Should().Be(2.96);
        symbolInfo.SwapShort.Should().Be(-7.04);
        symbolInfo.MarginInitial.Should().Be(0);
        symbolInfo.MarginMaintenance.Should().Be(0);
        symbolInfo.CurrencyBase.Should().Be("CAD");
        symbolInfo.CurrencyProfit.Should().Be("JPY");
        symbolInfo.CurrencyMargin.Should().Be("CAD");
        symbolInfo.Description.Should().Be("Canadian Dollar vs Japanese Yen");
        symbolInfo.Path.Should().Be(@"ROW_STANDARD_FX\ROW_STD_FX2\CADJPY");
        symbolInfo.SessionQuote[0].Monday.Should().Be("00:00-23:59");
        symbolInfo.SessionQuote[0].Tuesday.Should().Be("");
        symbolInfo.SessionQuote[0].Wednesday.Should().Be("");
        symbolInfo.SessionQuote[0].Thursday.Should().Be("");
        symbolInfo.SessionQuote[0].Friday.Should().Be("");
        symbolInfo.SessionQuote[1].Monday.Should().Be("");
        symbolInfo.SessionQuote[1].Tuesday.Should().Be("00:00-23:59");
        symbolInfo.SessionQuote[1].Wednesday.Should().Be("");
        symbolInfo.SessionQuote[1].Thursday.Should().Be("");
        symbolInfo.SessionQuote[1].Friday.Should().Be("");
        symbolInfo.SessionQuote[2].Monday.Should().Be("");
        symbolInfo.SessionQuote[2].Tuesday.Should().Be("");
        symbolInfo.SessionQuote[2].Wednesday.Should().Be("00:00-23:59");
        symbolInfo.SessionQuote[2].Thursday.Should().Be("");
        symbolInfo.SessionQuote[2].Friday.Should().Be("");
        symbolInfo.SessionQuote[3].Monday.Should().Be("");
        symbolInfo.SessionQuote[3].Tuesday.Should().Be("");
        symbolInfo.SessionQuote[3].Wednesday.Should().Be("");
        symbolInfo.SessionQuote[3].Thursday.Should().Be("00:00-23:59");
        symbolInfo.SessionQuote[3].Friday.Should().Be("");
        symbolInfo.SessionQuote[4].Monday.Should().Be("");
        symbolInfo.SessionQuote[4].Tuesday.Should().Be("");
        symbolInfo.SessionQuote[4].Wednesday.Should().Be("");
        symbolInfo.SessionQuote[4].Thursday.Should().Be("");
        symbolInfo.SessionQuote[4].Friday.Should().Be("00:00-23:59");
        symbolInfo.SessionTrade[0].Monday.Should().Be("00:00-23:59");
        symbolInfo.SessionTrade[0].Tuesday.Should().Be("");
        symbolInfo.SessionTrade[0].Wednesday.Should().Be("");
        symbolInfo.SessionTrade[0].Thursday.Should().Be("");
        symbolInfo.SessionTrade[0].Friday.Should().Be("");
        symbolInfo.SessionTrade[1].Monday.Should().Be("");
        symbolInfo.SessionTrade[1].Tuesday.Should().Be("00:00-23:59");
        symbolInfo.SessionTrade[1].Wednesday.Should().Be("");
        symbolInfo.SessionTrade[1].Thursday.Should().Be("");
        symbolInfo.SessionTrade[1].Friday.Should().Be("");
        symbolInfo.SessionTrade[2].Monday.Should().Be("");
        symbolInfo.SessionTrade[2].Tuesday.Should().Be("");
        symbolInfo.SessionTrade[2].Wednesday.Should().Be("00:00-23:59");
        symbolInfo.SessionTrade[2].Thursday.Should().Be("");
        symbolInfo.SessionTrade[2].Friday.Should().Be("");
        symbolInfo.SessionTrade[3].Monday.Should().Be("");
        symbolInfo.SessionTrade[3].Tuesday.Should().Be("");
        symbolInfo.SessionTrade[3].Wednesday.Should().Be("");
        symbolInfo.SessionTrade[3].Thursday.Should().Be("00:00-23:59");
        symbolInfo.SessionTrade[3].Friday.Should().Be("");
        symbolInfo.SessionTrade[4].Monday.Should().Be("");
        symbolInfo.SessionTrade[4].Tuesday.Should().Be("");
        symbolInfo.SessionTrade[4].Wednesday.Should().Be("");
        symbolInfo.SessionTrade[4].Thursday.Should().Be("");
        symbolInfo.SessionTrade[4].Friday.Should().Be("00:00-23:59");
        symbolInfo.ErrorID.Should().Be(0);
        symbolInfo.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetSymbolInformationAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/symbol/info*").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var symbolInfo = await mtClient.GetSymbolInformationAsync("EURUSD");

        //Assert
        symbolInfo.ErrorID.Should().Be(QueryStatus.Error);
    }
}