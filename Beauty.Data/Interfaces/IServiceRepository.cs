using Beauty.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Data.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория услуг
    /// </summary>
    public interface IServiceRepository : IRepository<Service>
    {
        /// <summary>
        /// Возвращает все услуги, связанные с записью
        /// </summary>
        /// <param name="enrollmentId">Идентификатор записи</param>
        Task<IEnumerable<Service>> FindEnrollmentServicesAsync(int enrollmentId);
    }
}
