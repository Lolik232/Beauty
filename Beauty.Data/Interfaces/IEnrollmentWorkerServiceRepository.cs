using Beauty.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Data.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория записей, связанных с услугами
    /// </summary>
    public interface IEnrollmentWorkerServiceRepository : IRepository<EnrollmentWorkerService>
    {
        Task<IEnumerable<EnrollmentWorkerService>> FindEnrollmentWorkerServicesAsync(int enrollmentId);
    }
}
