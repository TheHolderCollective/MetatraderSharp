using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT4;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT4;

public class GetIndicatorValuesAsync_Tests
{
    [Fact]
    public async Task GetATRValuesAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockIndicator = new IndicatorBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/*").Respond("application/json", mockIndicator.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var indicator = await mtClient.GetATRValuesAsync(14, 0, "EURUSD", TimeframesMT4.Period_M15);

        // Assert
        indicator.Msg.Should().Be("ATR_INDICATOR");
        indicator.DataValue.Should().Be(7.714E-05);
        indicator.ErrorID.Should().Be(0);
        indicator.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task GetATRValuesAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/*").Respond("application/json","");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var indicator = await mtClient.GetATRValuesAsync(14, 0, "EURUSD", TimeframesMT4.Period_M15);

        // Assert
        indicator.ErrorID.Should().Be(QueryStatus.Error);
    }

    [Fact]
    public async Task GetMAValuesAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockIndicator = new IndicatorBuilder().WithMsg("MA_INDICATOR").WithDataValue(1.13724905).Build();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/*").Respond("application/json", mockIndicator.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var indicator = await mtClient.GetMAValuesAsync(AppliedPrice.Price_Close, MA_Method.Mode_EMA, 21, 1, "EURUSD", TimeframesMT4.Period_M15);

        // Assert
        indicator.Msg.Should().Be("MA_INDICATOR");
        indicator.DataValue.Should().Be(1.13724905);
        indicator.ErrorID.Should().Be(0);
        indicator.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task GetMAValuesAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/*").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var indicator = await mtClient.GetMAValuesAsync(AppliedPrice.Price_Close, MA_Method.Mode_EMA, 21, 1, "EURUSD", TimeframesMT4.Period_M15);

        // Assert
        indicator.ErrorID.Should().Be(QueryStatus.Error);
    }

    [Fact]
    public async Task GetCustomIndicatorValuesAsync_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockIndicator = new IndicatorBuilder().WithMsg("CUSTOM_INDICATOR").WithDataValue(0.00000999).Build();

        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/*").Respond("application/json", mockIndicator.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var indicator = await mtClient.GetCustomIndicatorValuesAsync("OsMA", 0, 0, "EURUSD",TimeframesMT4.Period_M15);

        // Assert
        indicator.Msg.Should().Be("CUSTOM_INDICATOR");
        indicator.DataValue.Should().Be(0.00000999);
        indicator.ErrorID.Should().Be(0);
        indicator.ErrorDescription.Should().Be("no error");
    }

    [Fact]
    public async Task GetCustomIndicatorValuesAsync_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/indicator/*").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT4Client(client);

        // Act
        var indicator = await mtClient.GetCustomIndicatorValuesAsync("OsMA", 0, 0, "EURUSD", TimeframesMT4.Period_M15);

        // Assert
        indicator.ErrorID.Should().Be(QueryStatus.Error);
    }
}
