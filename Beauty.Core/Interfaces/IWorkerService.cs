using Beauty.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с пользователями
    /// </summary>
    public interface IWorkerService
    {
        /// <summary>
        /// Возвращает список администраторов
        /// </summary>
        Task<IEnumerable<WorkerDTO>> GetAdministratorsAsync();

        Task<IEnumerable<WorkerDTO>> GetServiceWorkersAsync(int serviceId);

        Task<string> GetWorkerShortnameAsync(int workerId);
    }
}
