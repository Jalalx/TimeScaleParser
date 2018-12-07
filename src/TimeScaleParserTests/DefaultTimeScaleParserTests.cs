using System;
using System.Globalization;
using TimeScaleParser;
using Xunit;

namespace TimeScaleParserTests
{
    public class DefaultTimeScaleParserTests
    {
        [Fact]
        public void Parse_ForNullValue_ThrowsArgumentNullException()
        {
            var parser = new DefaultTimeScaleParser(new GregorianCalendar());

            var ex = Record.Exception(() => parser.Parse(null));

            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void Parse_ForEmptyString_ReturnsEmptyScale()
        {
            var parser = new DefaultTimeScaleParser(new GregorianCalendar());

            var scale = parser.Parse("");

            Assert.Null(scale.StartDate);
            Assert.Null(scale.EndDate);

            Assert.Equal(TimeScale.Empty, scale);
        }
    }
}
