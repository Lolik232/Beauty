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
    }
}
