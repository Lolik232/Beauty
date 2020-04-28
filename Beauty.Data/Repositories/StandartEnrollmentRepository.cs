using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.Data.Repositories
{
    public class StandartEnrollmentRepository : BaseStandartRepository<Enrollment>, IEnrollmentRepository
    {
        public StandartEnrollmentRepository(StandartContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Enrollment>> FindAllAsync(string filterText)
        {
            var enrollments = await FindAllAsync();

            if (string.IsNullOrWhiteSpace(filterText))
            {
                return enrollments;
            }

            enrollments = enrollments.Where(Enrollment => Enrollment.ClientFirstname.Contains(filterText)
                                            || Enrollment.ClientPhoneNumber.Contains(filterText)
                                            || Enrollment.DateTime.ToString("HH:mm").Contains(filterText)
                                            || Enrollment.DateTime.ToString("HH mm").Contains(filterText));

            return enrollments;
        }

        public async Task<IEnumerable<Enrollment>> FindRelevantEnrollmentsAsync()
        {
            var currentDate = DateTime.Now;

            var enrollments = await context.Enrollments
                              .Where(Enrollment => Enrollment.DateTime.Day.Equals(currentDate.Day)
                                     && Enrollment.DateTime.Month.Equals(currentDate.Month)
                                     && Enrollment.DateTime.Year.Equals(currentDate.Year))
                              .ToListAsync();

            return enrollments;
        }

        public async Task<IEnumerable<Enrollment>> FindRelevantEnrollmentsAsync(string filterText)
        {
            var enrollments = await FindRelevantEnrollmentsAsync();

            if (string.IsNullOrWhiteSpace(filterText))
            {
                return enrollments;
            }

            enrollments = enrollments.Where(Enrollment => Enrollment.ClientFirstname.Contains(filterText)
                                            || Enrollment.ClientPhoneNumber.Contains(filterText)
                                            || Enrollment.DateTime.ToString("HH:mm").Contains(filterText)
                                            || Enrollment.DateTime.ToString("HH mm").Contains(filterText));

            return enrollments;
        }
    }
}
