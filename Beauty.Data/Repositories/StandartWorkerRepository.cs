using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Beauty.Data.Repositories
{
    public class StandartWorkerRepository : BaseStandartRepository<Worker>, IWorkerRepository
    {
        public StandartWorkerRepository(StandartContext context)
            : base(context)
        { }

        public async Task<string> FindWorkerShortnameAsync(int workerId)
        {
            var worker = await FindAsync(workerId);

            return ($"{worker.Lastname} {worker.Firstname} {worker.Middlename}").Trim();
        }
    }
}
