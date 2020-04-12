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

        public async Task<IEnumerable<WorkerDTO>> GetAdministratorsAsync()
        {
            var workers = await unitOfWork.WorkerPositions.FindAdministratorsAsync();

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
    }
}