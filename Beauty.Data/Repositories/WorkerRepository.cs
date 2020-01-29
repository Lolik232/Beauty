using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Beauty.Data.Contexts;

namespace Beauty.Data.Repositories
{
    public class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(Context context)
            : base(context)
        { }

        public async Task<IEnumerable<Position>> FindPositionsAsync(int? workerId)
        {
            var positions = await context.WorkerPositions
                            .Include(WorkerPosition => WorkerPosition.Position)
                            .Where(WorkerPosition => WorkerPosition.WorkerId.Equals(workerId.Value))
                            .Select(WorkerPosition => WorkerPosition.Position)
                            .ToListAsync();

            return positions;
        }

        public async Task<IEnumerable<Worker>> FindAdministratorsAsync()
        {
            var administrators = await context.WorkerPositions
                                 .Include(WorkerPosition => WorkerPosition.Worker)
                                 .Where(WorkerPosition => WorkerPosition.PositionId.Equals(2))
                                 .Select(WorkerPosition => WorkerPosition.Worker)
                                 .ToListAsync();

            return administrators;
        }
    }
}
