using System;

namespace TimeScaleParser
{
    public class SystemClock : ISystemClock
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }

    public interface ISystemClock
    {
        DateTime Now();
    }
}
