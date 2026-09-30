using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT5;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT5;

public class GetIndicatorValuesAsync_Tests
{
    [Fact]
    public async Task GetATRValuesAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockIndicator = new IndicatorBuilder().WithMsg("ATR_INDICATOR")
                                                  .WithDataValues([0.000112])
                                                  .Build();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/atr*").Respond("application/json", mockIndicator.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var indicator = await mtClient.GetATRIndicatorValuesAsync(14, 0, "EURUSD", TimeframesMT5.Period_M1);

        // Assert
        indicator.Msg.Should().Be("ATR_INDICATOR");
        indicator.DataValues.Should().NotBeNull().And.NotBeEmpty();
        indicator.DataValues[0].Should().Be(0.000112);
        indicator.ErrorID.Should().Be(0);
        indicator.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetATRValuesAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/atr*").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var indicator = await mtClient.GetATRIndicatorValuesAsync(14, 0, "EURUSD", TimeframesMT5.Period_M1);

        // Assert
        indicator.ErrorID.Should().Be(QueryStatus.Error);
    }

    [Fact]
    public async Task GetMAValuesAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockIndicator = new IndicatorBuilder().WithMsg("MA_INDICATOR")
                                                  .WithDataValues([1.132983, 1.133019, 1.133065])
                                                  .Build();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/ma*").Respond("application/json", mockIndicator.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var indicator = await mtClient.GetMAIndicatorValuesAsync(AppliedPrice.Price_Close, MA_Method.Mode_EMA, 21, 1, 3, "EURUSD", TimeframesMT5.Period_M5);

        // Assert
        indicator.Msg.Should().Be("MA_INDICATOR");
        indicator.DataValues.Should().NotBeNull().And.NotBeEmpty();
        indicator.DataValues[0].Should().Be(1.132983);
        indicator.DataValues[1].Should().Be(1.133019);
        indicator.DataValues[2].Should().Be(1.133065);
        indicator.ErrorID.Should().Be(0);
        indicator.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetMAValuesAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/ma*").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var indicator = await mtClient.GetMAIndicatorValuesAsync(AppliedPrice.Price_Close, MA_Method.Mode_EMA, 21, 1, 3, "EURUSD", TimeframesMT5.Period_M5);

        // Assert
        indicator.ErrorID.Should().Be(QueryStatus.Error);
    }

    [Fact]
    public async Task GetCustomIndicatorValuesAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockIndicator = new IndicatorBuilder().WithMsg("CUSTOM_INDICATOR")
                                                  .WithDataValues([0.0001364, 0.0001439, 0.0001467, 0.0001498, 0.0001481])
                                                  .Build();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/custom").Respond("application/json", mockIndicator.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var indicator = await mtClient.GetCustomIndicatorValuesAsync("Examples\\OsMA", "EURUSD", TimeframesMT5.Period_M5, 0, 5, "21", "14");

        // Assert
        indicator.Msg.Should().Be("CUSTOM_INDICATOR");
        indicator.DataValues.Should().NotBeNull().And.NotBeEmpty();
        indicator.DataValues.Should().HaveCount(5);
        indicator.DataValues[0].Should().Be(0.0001364);
        indicator.DataValues[1].Should().Be(0.0001439);
        indicator.DataValues[2].Should().Be(0.0001467);
        indicator.DataValues[3].Should().Be(0.0001498);
        indicator.DataValues[4].Should().Be(0.0001481);
        indicator.ErrorID.Should().Be(0);
        indicator.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetCustomIndicatorValuesAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/custom").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var indicator = await mtClient.GetCustomIndicatorValuesAsync("Examples\\OsMA", "EURUSD", TimeframesMT5.Period_M5, 0, 5, "21", "14");

        // Assert
        indicator.ErrorID.Should().Be(QueryStatus.Error);
    }
}
