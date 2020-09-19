using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime dt1 = new DateTime(2020, 9, 17); //Thu
            DateTime dt2 = new DateTime(2020, 9, 21); //Mon
            Job job = new Job();
            job.StartDate = dt1;
            job.EndDate = dt2;

            TimeSpan ts = dt2 - dt1;
            Console.WriteLine("Hello World!");
        }
    }
}
