using Beauty.Data.Models;
using Beauty.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IEnrollmentRepository Enrollments { get; }
        IPositionRepository Positions { get; }
        IWorkerRepository Workers { get; }
        IWorkerPositionRepository WorkerPositions { get; }
        Task UpdateAsync(object model);
        Task<int> SaveAsync();
    }
}
