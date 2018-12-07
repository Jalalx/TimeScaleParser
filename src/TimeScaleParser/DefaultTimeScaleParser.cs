using System;
using System.Globalization;

namespace TimeScaleParser
{
    public class DefaultTimeScaleParser : ITimeScaleParser
    {
        public DefaultTimeScaleParser(Calendar calendar)
        {
            Calendar = calendar;
        }

        public Calendar Calendar { get; }

        public TimeScale Parse(string scale)
        {
            if (scale == null)
            {
                throw new ArgumentNullException(nameof(scale));
            }

            if (string.IsNullOrWhiteSpace(scale))
            {
                return TimeScale.Empty;
            }

            throw new NotImplementedException();
        }
    }
}
