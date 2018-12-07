using System;

namespace TimeScaleParser
{
    public class TimeScale
    {
        public static readonly TimeScale Empty = new TimeScale();

        public TimeScale()
        {
        }

        public TimeScale(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
