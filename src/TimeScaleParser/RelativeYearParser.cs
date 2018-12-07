using System;
using System.Globalization;

namespace TimeScaleParser
{

    public class RelativeYearParser : ITimeScaleParser
    {
        public const string NotationPrefix = "yr";

        private readonly ISystemClock _systemClock;
        private readonly Calendar _calendar;

        public RelativeYearParser(ISystemClock systemClock, Calendar calendar)
        {
            _systemClock = systemClock;
            _calendar = calendar;
        }

        public TimeScale Parse(string scale)
        {
            if (scale == null)
            {
                throw new ArgumentNullException(nameof(scale));
            }

            var trimmedScale = scale.Trim().ToLower();
            var yearNotationPart = scale.Substring(0, NotationPrefix.Length);
            if (yearNotationPart != NotationPrefix)
            {
                throw new ArgumentException("Value is not a valid year notation.", nameof(scale));
            }

            var yearNumberPart = scale.Substring(NotationPrefix.Length);

            int yearNumber;
            if (!int.TryParse(yearNumberPart, out yearNumber))
            {
                throw new ArgumentException("Value is not a valid year notation.", nameof(scale));
            }

            var startDate = _systemClock.Now();
            var endDate = _calendar.AddYears(startDate, yearNumber);

            return new TimeScale(startDate, endDate);
        }
    }
}
