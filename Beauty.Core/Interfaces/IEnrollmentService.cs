using Beauty.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с записями
    /// </summary>
    public interface IEnrollmentService
    {
        /// <summary>
        /// Возвращает список актуальных записей
        /// </summary>
        Task<IEnumerable<EnrollmentDTO>> GetRelevantEnrollmentsAsync();
    }
}
