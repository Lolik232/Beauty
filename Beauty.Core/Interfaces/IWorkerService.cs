using Beauty.Data.Models;
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
        Task<IEnumerable<Worker>> GetAdministratorsAsync();
    }
}
