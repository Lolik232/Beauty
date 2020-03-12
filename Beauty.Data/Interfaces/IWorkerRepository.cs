using Beauty.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Data.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория сотрудников
    /// </summary>
    public interface IWorkerRepository : IRepository<Worker>
    {
        /// <summary>
        /// Возвращает должности сотрудника
        /// </summary>
        /// <param name="workerId">Идентификатор сотрудника</param>
        Task<IEnumerable<Position>> FindPositionsAsync(int? workerId);

        /// <summary>
        /// Возвращает список администраторов
        /// </summary>
        Task<IEnumerable<Worker>> FindAdministratorsAsync();
    }
}
