using FluentAssertions;
using MetatraderSharp.MetatraderClient;
using MetatraderSharp.Tests.Builders.MT5;
using RichardSzalay.MockHttp;

namespace MetatraderSharp.Tests.MT5;

public class GetCalendarAsync_Tests
{
    [Fact]
    public async Task GetCalendarAsyncc_SuccessfulDeserialization_Test()
    {
        // Arrange
        var mockCalendar = new CalendarBuilder().Build();
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/calendar").Respond("application/json", mockCalendar.ToString());

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var calendar = await mtClient.GetCalendarAsync("2025.01.26 16:30:00", "2025.01.28 16:30:00");

        // Assert
        calendar.Msg.Should().Be("CALENDAR_LIST");
        calendar.Events[0].Time.Should().Be("2025.01.27 16:30:00");
        calendar.Events[0].EventCountryID.Should().Be(840);
        calendar.Events[0].EventDigits.Should().Be(2);
        calendar.Events[0].EventCode.Should().Be("chicago-fed-national-activity-index");
        calendar.Events[0].EventFrequency.Should().Be("CALENDAR_FREQUENCY_MONTH");
        calendar.Events[0].EventID.Should().Be(840080001);
        calendar.Events[0].EventImportance.Should().Be("CALENDAR_IMPORTANCE_LOW");
        calendar.Events[0].EventMultiplier.Should().Be("CALENDAR_MULTIPLIER_NONE");
        calendar.Events[0].EventName.Should().Be("Chicago Fed National Activity Index");
        calendar.Events[0].EventSector.Should().Be("CALENDAR_SECTOR_BUSINESS");
        calendar.Events[0].EventSourceUrl.Should().Be("https://www.chicagofed.org");
        calendar.Events[0].EventTimeMode.Should().Be("CALENDAR_TIMEMODE_DATETIME");
        calendar.Events[0].EventType.Should().Be("CALENDAR_TYPE_INDICATOR");
        calendar.Events[0].EventUnit.Should().Be("CALENDAR_UNIT_NONE");
        calendar.Events[0].ActualValue.Should().Be(0.15);
        calendar.Events[0].ForecastValue.Should().Be(0.24);
        calendar.Events[0].PreviousValue.Should().Be(-0.12);
        calendar.Events[0].RevisedValue.Should().Be(-0.01);
        calendar.Events[0].ImpactType.Should().Be("CALENDAR_UNIT_CURRENCY");
        calendar.Events[0].Revision.Should().Be(0);
        calendar.Events[0].Period.Should().Be("2024.12.01 00:00:00");
        calendar.ErrorID.Should().Be(0);
        calendar.ErrorDescription.Should().Be("The operation completed successfully");
    }

    [Fact]
    public async Task GetCalendarAsyncc_UnsuccessfulDeserialization_Test()
    {
        // Arrange
        var mockHttp = new MockHttpMessageHandler();
        mockHttp.When("http://127.0.0.1:81/v1/calendar").Respond("application/json", "");

        var client = mockHttp.ToHttpClient();
        var mtClient = new MT5Client(client);

        // Act
        var calendar = await mtClient.GetCalendarAsync("2025.01.26 16:30:00", "2025.01.28 16:30:00");

        // Assert
        calendar.ErrorID.Should().Be(QueryStatus.Error);
    }

}
