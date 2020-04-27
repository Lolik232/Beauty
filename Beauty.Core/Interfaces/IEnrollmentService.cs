using Beauty.Core.DTOs;
using Beauty.Data.Models;
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

        Task<Enrollment> GetEnrollmentAsync(int enrollmentId);

        Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);

        Task EditEnrollmentAsync(Enrollment enrollment);

        Task RemoveEnrollmentAsync(int enrollmentId);
    }
}
