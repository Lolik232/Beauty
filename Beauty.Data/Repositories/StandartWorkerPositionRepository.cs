using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.Data.Repositories
{
    public class StandartWorkerPositionRepository : BaseStandartRepository<WorkerPosition>, IWorkerPositionRepository
    {
        public StandartWorkerPositionRepository(StandartContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Position>> FindWorkerPositionsAsync(int workerId)
        {
            var positions = await context.WorkerPositions
                            .Include(WorkerPosition => WorkerPosition.Position)
                            .Where(WorkerPosition => WorkerPosition.WorkerId.Equals(workerId))
                            .Select(WorkerPosition => WorkerPosition.Position)
                            .ToListAsync();

            return positions;
        }

        public async Task<IEnumerable<Worker>> FindAdministratorsAsync()
        {
            var administrators = await context.WorkerPositions
                                 .Include(WorkerPosition => WorkerPosition.Worker)
                                 .Where(WorkerPosition => WorkerPosition.PositionId.Equals(1) || WorkerPosition.PositionId.Equals(2) || WorkerPosition.PositionId.Equals(9))
                                 .Select(WorkerPosition => WorkerPosition.Worker)
                                 .ToListAsync();

            return administrators;
        }
    }
}
