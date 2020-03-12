using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;

namespace Beauty.Data.Repositories
{
    public class StandartPositionRepository : BaseStandartRepository<Position>, IPositionRepository
    {
        public StandartPositionRepository(StandartContext context)
            : base(context)
        { }
    }
}
