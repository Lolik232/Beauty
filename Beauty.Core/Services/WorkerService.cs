using Beauty.Core.Interfaces;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IUnitOfWork unitOfWork;

        public WorkerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Worker>> GetAdministratorsAsync()
        {
            return await unitOfWork.Workers.FindAdministratorsAsync();
        }
    }
}