using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Extensions
{
    public static class PositionsEnumerableExtensions
    {
        public static string ToLine(this IEnumerable<Position> positions)
        {
            var positionsList = positions as List<Position>;

            var positionsAsLine = positionsList.FirstOrDefault()?.Title;

            for (int index = 1; index < positionsList.Count; index++)
            {
                positionsAsLine += $", {positionsList[index].Title}";
            }

            return positionsAsLine;
        }
    }
}
