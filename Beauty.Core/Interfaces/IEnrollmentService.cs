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
        Task<IEnumerable<EnrollmentDTO>> GetEnrollmentsAsync(string filterText = null);

        /// <summary>
        /// Возвращает список актуальных записей
        /// </summary>
        Task<IEnumerable<EnrollmentDTO>> GetRelevantEnrollmentsAsync(string filterText = null);

        Task<Enrollment> GetEnrollmentAsync(int enrollmentId);

        Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);

        Task EditEnrollmentAsync(Enrollment enrollment);

        Task RemoveEnrollmentAsync(int enrollmentId);
    }
}
