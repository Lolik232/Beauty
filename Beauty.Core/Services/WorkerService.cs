using Beauty.Core.DTOs;
using Beauty.Core.Extensions;
using Beauty.Core.Interfaces;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Collections.Generic;
using System.Linq;
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

        private async Task<IEnumerable<WorkerDTO>> ToDTOsAsync(IEnumerable<Worker> workers)
        {
            var workerDTOs = workers.Select(Worker => new WorkerDTO()
            {
                Id = Worker.Id
            }).ToList();

            foreach (var workerDTO in workerDTOs)
            {
                workerDTO.Shortname = await unitOfWork.Workers.FindWorkerShortnameAsync(workerDTO.Id);

                var positions = await unitOfWork.WorkerPositions.FindWorkerPositionsAsync(workerDTO.Id);
                workerDTO.Positions = positions.ToLine();
            }

            return workerDTOs;
        }

        public async Task<IEnumerable<WorkerDTO>> GetAdministratorsAsync()
        {
            var workers = await unitOfWork.WorkerPositions.FindAdministratorsAsync();

            return await ToDTOsAsync(workers);
        }

        public async Task<IEnumerable<WorkerDTO>> GetServiceWorkersAsync(int serviceId)
        {
            var workers = await unitOfWork.PositionServices.FindServiceWorkersAsync(serviceId);

            return await ToDTOsAsync(workers); 
        }

        public async Task<string> GetWorkerShortnameAsync(int workerId)
        {
            return await unitOfWork.Workers.FindWorkerShortnameAsync(workerId);
        }
    }
}