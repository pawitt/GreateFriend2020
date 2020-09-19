using System;
using System.Linq;

namespace TradeBooks.Models
{
    public class Job
    {
        public Job()
        {
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        /*
        public int WorkingDays {
            get
            {
                int count = 0;
                var d = StartDate;
                while (d<= EndDate)
                {
                    if (d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                        count++;
                    d.AddDays(1);
                }
                
                return count;
            }              
        }
        */
        public int CountWorkingDays(DateTime[] holidays = null)
        {
            //if (StartDate>EndDate)
            //{
            //    throw new InvalidOperationException();
            //}
            if (StartDate > EndDate)
            {
                throw new InvalidOperationException("ERR-91: Invalid date");
            }
            int count = 0;
            var d = StartDate;
            if (holidays == null) holidays = new DateTime[0];

            while (d <= EndDate)
            {
                if (d.DayOfWeek != DayOfWeek.Saturday
                    && d.DayOfWeek != DayOfWeek.Sunday
                    && !holidays.Contains(d))
                {
                    count++;
                }
                d = d.AddDays(1);
            }
            return count;
        }
    }
}