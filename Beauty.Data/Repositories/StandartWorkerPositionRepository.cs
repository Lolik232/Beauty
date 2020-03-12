using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;

namespace Beauty.Data.Repositories
{
    public class StandartWorkerPositionRepository : BaseStandartRepository<WorkerPosition>, IWorkerPositionRepository
    {
        public StandartWorkerPositionRepository(StandartContext context)
            : base(context)
        { }
    }
}
