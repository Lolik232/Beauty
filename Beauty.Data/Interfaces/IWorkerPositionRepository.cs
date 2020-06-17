using Beauty.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Data.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория должностей, связанных с сотрудниками
    /// </summary>
    public interface IWorkerPositionRepository : IRepository<WorkerPosition>
    {
        /// <summary>
        /// Возвращает должности сотрудника
        /// </summary>
        /// <param name="workerId">Идентификатор сотрудника</param>
        Task<IEnumerable<Position>> FindWorkerPositionsAsync(int workerId);

        /// <summary>
        /// Возвращает список администраторов
        /// </summary>
        Task<IEnumerable<Worker>> FindAdministratorsAsync();
    }
}
