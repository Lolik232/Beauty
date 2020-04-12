using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;

namespace Beauty.Data.Repositories
{
    public class StandartPositionServiceRepository : BaseStandartRepository<PositionService>, IPositionServiceRepository
    {
        public StandartPositionServiceRepository(StandartContext context)
            : base(context)
        { }
    }
}
