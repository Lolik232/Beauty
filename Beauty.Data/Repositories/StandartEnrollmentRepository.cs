using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Beauty.Data.Repositories
{
    public class StandartEnrollmentRepository : BaseStandartRepository<Enrollment>, IEnrollmentRepository
    {
        public StandartEnrollmentRepository(StandartContext context)
            : base(context)
        { }

        public async Task<IEnumerable<DateTime>> FindEnrollmentDatesAsync()
        {
            var dateTimes = await context.Enrollments
                            .Select(Enrollment => Enrollment.DateTime)
                            .ToListAsync();

            var dates = dateTimes
                        .Select(DateTime => DateTime.Date)
                        .Distinct()
                        .OrderByDescending(DateTime => DateTime.Day)
                        .ToList();

            return dates;
        }

        public async Task<IEnumerable<Enrollment>> FindAllAsync(string filterText)
        {
            var enrollments = await FindAllAsync();

            if (string.IsNullOrWhiteSpace(filterText))
            {
                return enrollments;
            }

            var regex = new Regex("[\\s()+-]");
            var phoneNumber = regex.Replace(filterText, string.Empty);

            enrollments = enrollments.Where(Enrollment => Enrollment.ClientFirstname.Contains(filterText)
                                            || regex.Replace(Enrollment.ClientPhoneNumber, string.Empty).Contains(phoneNumber)
                                            || Enrollment.DateTime.ToString("HH:mm").Contains(filterText)
                                            || Enrollment.DateTime.ToString("HH mm").Contains(filterText));

            return enrollments;
        }

        public async Task<IEnumerable<Enrollment>> FindAllAsync(string filterText, DateTime filterDate)
        {
            var enrollments = await FindAllAsync();

            enrollments = enrollments.Where(Enrollment => Enrollment.DateTime.Date.Equals(filterDate.Date));

            if (string.IsNullOrWhiteSpace(filterText))
            {
                return enrollments;
            }

            var regex = new Regex("[\\s()+-]");
            var phoneNumber = regex.Replace(filterText, string.Empty);

            enrollments = enrollments.Where(Enrollment => Enrollment.ClientFirstname.Contains(filterText)
                                            || regex.Replace(Enrollment.ClientPhoneNumber, string.Empty).Contains(phoneNumber)
                                            || Enrollment.DateTime.ToString("HH:mm").Contains(filterText)
                                            || Enrollment.DateTime.ToString("HH mm").Contains(filterText));

            return enrollments;
        }
    }
}
