using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Collections.Generic;
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
            return await FindAllAsync();
        }
    }
}
