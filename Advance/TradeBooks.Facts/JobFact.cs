using System;
using System.Collections.Generic;
using System.IO;
using TradeBooks.Models;
using Xunit;

namespace TradeBooks.Facts
{
    public class JobFact
    {
        public class WorkingDays
        {
            [Fact]
            public void SameDayJob_CountAsOne()
            {
                // Arrange
                DateTime dt = new DateTime(2020,9,18);
                Job job = new Job();
                job.StartDate = dt;
                job.EndDate = dt;

                // Act
                int days = job.CountWorkingDays();
            
                // Assert
                Assert.Equal(1, days);
            }

            [Fact]
            public void TwoDayJob_CountAsTwo()
            {
                // Arrange
                DateTime dt1 = new DateTime(2020, 9, 17);
                DateTime dt2 = new DateTime(2020, 9, 18);
                Job job = new Job();
                job.StartDate = dt1;
                job.EndDate = dt2;

                // Act
                int days = job.CountWorkingDays();

                // Assert
                Assert.Equal(2, days);
            }

            [Fact]
            public void NotCountWeekendAsWorkingDay()
            {
                // Arrange
                DateTime dt1 = new DateTime(2020, 9, 17); //Thu
                DateTime dt2 = new DateTime(2020, 9, 21); //Mon
                Job job = new Job();
                job.StartDate = dt1;
                job.EndDate = dt2;

                int days = job.CountWorkingDays();
                
                // Assert
                Assert.Equal(3, days);
                
            }


            [Fact]
            public void NotCountHolidayAsWorkingDay()
            {
                // Arrange
                DateTime dt1 = new DateTime(2020, 9, 1); 
                DateTime dt2 = new DateTime(2020, 9, 10);
                DateTime[] holidays = new DateTime[]
                {
                    new DateTime(2020,9,4),
                    new DateTime(2020,9,6)
                };

                Job job = new Job();
                job.StartDate = dt1;
                job.EndDate = dt2;

                int days = job.CountWorkingDays(holidays);

                // Assert
                Assert.Equal(7, days);

            }

            [Theory]
            [InlineData(1, 10, 6)]
            [InlineData(1, 30, 20)]
            [InlineData(26, 30, 3)]
            public void TestCases(int day1, int day2, int result)
            {
                DateTime dt1 = new DateTime(2020, 9, day1);
                DateTime dt2 = new DateTime(2020, 9, day2);
                DateTime[] holidays = new DateTime[]
                {
                    new DateTime(2020, 9, 4), // ª´àªÂÊ§¡ÃÒ¹µì
                    new DateTime(2020, 9, 7), // ª´àªÂÊ§¡ÃÒ¹µì
                };

                Job job = new Job();
                job.StartDate = dt1;
                job.EndDate = dt2;

                int days = job.CountWorkingDays(holidays);

                Assert.Equal(result, days);
            }


            public static IEnumerable<object[]> ReadTestCases()
            {

                using var reader = new StreamReader("TestCases_September2020.csv");
                reader.ReadLine(); // skip heading
                string s;
                while ((s=reader.ReadLine()) != null)
                {
                    var data = s.Split( new char[] { ',',' '}, StringSplitOptions.RemoveEmptyEntries );

                    //var day1 = int.Parse(data[0]);
                    if (!int.TryParse(data[0], out var day1)) continue;
                    if (!int.TryParse(data[1], out var day2)) continue;
                    if (!int.TryParse(data[2], out var result)) continue;

                    yield return new object[] { day1, day2, result };
                }

                //yield return new object[] { 1, 10, 6 };
                //yield return new object[] { 1, 30, 20 };



                //var list = new List<object[]>();
                //list.Add(new object[] { 1, 10, 6 });
                //list.Add(new object[] { 10, 30, 20 });
                //return list;
            }

            [Theory(DisplayName="CSV")]
            [MemberData(nameof(ReadTestCases))]
            public void NormalCountWorkingDays(int day1, int day2, int result)
            {
                DateTime dt1 = new DateTime(2020, 9, day1);
                DateTime dt2 = new DateTime(2020, 9, day2);
                DateTime[] holidays = new DateTime[]
                {
                    new DateTime(2020, 9, 4), // ª´àªÂÊ§¡ÃÒ¹µì
                    new DateTime(2020, 9, 7), // ª´àªÂÊ§¡ÃÒ¹µì
                };

                Job job = new Job();
                job.StartDate = dt1;
                job.EndDate = dt2;

                int days = job.CountWorkingDays(holidays);

                Assert.Equal(result, days);
            }

            //[Fact(Skip ="do it later", Timeout = 1000)]            
            [Fact(Timeout =1000)]
            //[Fact]
            public void InvalidDate_ThrowEx()
            {
                // Arrange
                DateTime dt1 = new DateTime(2020, 9, 10);
                DateTime dt2 = new DateTime(2020, 9, 1);
                
                Job job = new Job();
                job.StartDate = dt1;
                job.EndDate = dt2;

                //Assert.Throws<InvalidOperationException>(() =>
                Assert.ThrowsAny<Exception>(() =>
                {
                    int days = job.CountWorkingDays();                    
                });
            }
            [Fact]
            public void InvalidDate_ThrowEx_Example2()
            {
                // Arrange
                DateTime dt1 = new DateTime(2020, 9, 10);
                DateTime dt2 = new DateTime(2020, 9, 1);

                Job job = new Job();
                job.StartDate = dt1;
                job.EndDate = dt2;

                //Assert.Throws<InvalidOperationException>(() =>
                var ex=Assert.ThrowsAny<Exception>(() =>
                {
                    int days = job.CountWorkingDays();
                });
                Assert.NotNull(ex);
                Assert.Contains("ERR-91", ex.Message);
            }
        }
    }
}
