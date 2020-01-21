using Beauty.Data.Interfaces;
using Beauty.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beauty.Data.Models;

namespace Beauty.Data.Repositories
{
    public class WorkerPositionRepository : BaseRepository<WorkerPosition>, IWorkerPositionRepository
    {
        public WorkerPositionRepository(Context context)
            : base(context)
        { }
    }
}
