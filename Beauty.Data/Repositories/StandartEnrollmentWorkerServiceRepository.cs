using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.Data.Repositories
{
    public class StandartEnrollmentWorkerServiceRepository : BaseStandartRepository<EnrollmentWorkerService>, IEnrollmentWorkerServiceRepository
    {
        public StandartEnrollmentWorkerServiceRepository(StandartContext context)
            : base(context)
        { }

        public async Task<IEnumerable<EnrollmentWorkerService>> FindEnrollmentWorkerServicesAsync(int enrollmentId)
        {
            var enrollmentWorkerServices = await context.EnrollmentWorkerServices
                                           .Include(EnrollmentWorkerService => EnrollmentWorkerService.Service)
                                           .Include(EnrollmentWorkerService => EnrollmentWorkerService.Worker)
                                           .Where(EnrollmentWorkerService => EnrollmentWorkerService.EnrollmentId.Equals(enrollmentId))
                                           .ToListAsync();

            return enrollmentWorkerServices;
        }
    }
}
