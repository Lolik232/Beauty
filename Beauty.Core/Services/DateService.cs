using Beauty.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Beauty.Core.Services
{
    public class DateService : IDateService
    {
        private readonly DateTimeFormatInfo dateTimeFormatInfo;

        public DateService(DateTimeFormatInfo dateTimeFormatInfo)
        {
            this.dateTimeFormatInfo = dateTimeFormatInfo;
        }

        public IEnumerable<string> GetGenitiveMonthNames()
        {
            var months = dateTimeFormatInfo.MonthGenitiveNames.ToList();

            var emptyMonth = months.LastOrDefault();
            months.Remove(emptyMonth);

            return months;
        }

        public string GetGenitiveMonthName(int index)
        {
            var months = GetGenitiveMonthNames();
            return months.ElementAt(index);
        }

        public int GetGenitiveMonthIndex(string monthName)
        {
            var months = GetGenitiveMonthNames() as IList<string>;
            return months.IndexOf(monthName);
        }

        public IEnumerable<int> GetYearsInRange(int minValue, int maxValue)
        {
            return Enumerable.Range(minValue, maxValue - minValue + 1);
        }

        public int GetDaysCountInMonth(int year, int monthIndex)
        {
            return DateTime.DaysInMonth(year, monthIndex);
        }

        public int GetDaysCountInMonth(int year, string monthName)
        {
            var monthIndex = GetGenitiveMonthIndex(monthName) + 1;
            return DateTime.DaysInMonth(year, monthIndex);
        }

        public IEnumerable<int> GetDaysFromMonth(int year, string monthName)
        {
            var daysCountInMonth = GetDaysCountInMonth(year, monthName);
            return Enumerable.Range(1, daysCountInMonth);
        }
    }
}
