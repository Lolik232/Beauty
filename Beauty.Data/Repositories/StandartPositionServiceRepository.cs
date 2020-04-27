using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.Data.Repositories
{
    public class StandartPositionServiceRepository : BaseStandartRepository<PositionService>, IPositionServiceRepository
    {
        public StandartPositionServiceRepository(StandartContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Worker>> FindServiceWorkersAsync(int serviceId)
        {
            var servicePositions = await context.PositionServices
                                   .Include(PositionService => PositionService.Position)
                                   .Where(PositionService => PositionService.ServiceId.Equals(serviceId))
                                   .Select(PositionService => PositionService.Position)
                                   .ToListAsync();

            var serviceWorkers = new List<Worker>();

            foreach (var servicePosition in servicePositions)
            {
                var positionWorkers = await context.WorkerPositions
                                      .Include(WorkerPosition => WorkerPosition.Worker)
                                      .Where(WorkerPosition => WorkerPosition.PositionId.Equals(servicePosition.Id))
                                      .Select(WorkerPosition => WorkerPosition.Worker)
                                      .ToListAsync();

                serviceWorkers.AddRange(positionWorkers);
            }

            return serviceWorkers.Distinct();
        }
    }
}
