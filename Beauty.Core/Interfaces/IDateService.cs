using System.Collections.Generic;

namespace Beauty.Core.Interfaces
{
    public interface IDateService
    {
        IEnumerable<string> GetGenitiveMonthNames();
        string GetGenitiveMonthName(int index);
        int GetGenitiveMonthIndex(string monthName);
        IEnumerable<int> GetYearsInRange(int minValue, int maxValue);
        int GetDaysCountInMonth(int year, int monthIndex);
        int GetDaysCountInMonth(int year, string monthName);
        IEnumerable<int> GetDaysFromMonth(int year, string monthName);
    }
}
