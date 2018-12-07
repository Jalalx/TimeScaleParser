using System;
using System.Globalization;
using TimeScaleParser;
using Xunit;

namespace TimeScaleParserTests
{
    public class RelativeYearParserTests
    {
        [Theory]
        [InlineData("2018-01-01", "yr0", "2018-01-01", "2018-01-01")]
        [InlineData("2018-01-01", "yr1", "2018-01-01", "2019-01-01")]
        [InlineData("2018-01-01", "yr5", "2018-01-01", "2023-01-01")]
        [InlineData("2018-01-01", "yr-1", "2018-01-01", "2017-01-01")]
        [InlineData("2018-01-01", "yr-10", "2018-01-01", "2008-01-01")]
        public void Parse_ForGivenTimeAndScale_ReturnsExpectedTimeAndScale(string instant, string scale, string expectedStartDate, string expectedEndDate)
        {
            var clock = new FreezedSystemClock(DateTime.Parse(instant));
            var calendar = new GregorianCalendar();
            var parser = new RelativeYearParser(clock, calendar);

            var actualTimeScale = parser.Parse(scale);

            Assert.Equal(expectedStartDate, actualTimeScale.StartDate.Value.ToString("yyyy-MM-dd"));
            Assert.Equal(expectedEndDate, actualTimeScale.EndDate.Value.ToString("yyyy-MM-dd"));
        }
    }

    public class FreezedSystemClock : ISystemClock
    {
        private readonly DateTime _instant;

        public FreezedSystemClock(DateTime instant)
        {
            _instant = instant;
        }

        public DateTime Now()
        {
            return _instant;
        }
    }
}
