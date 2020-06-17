using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Data.Repositories
{
    public class StandartServiceRepository : BaseStandartRepository<Service>, IServiceRepository
    {
        public StandartServiceRepository(StandartContext context)
            : base(context)
        { }
    }
}
