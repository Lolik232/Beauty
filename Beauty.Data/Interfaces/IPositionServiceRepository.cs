using Beauty.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Data.Interfaces
{
    public interface IPositionServiceRepository : IRepository<PositionService>
    {
        Task<IEnumerable<Worker>> FindServiceWorkersAsync(int serviceId);
    }
}
