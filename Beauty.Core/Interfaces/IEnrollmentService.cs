using Beauty.Core.DTOs;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с записями
    /// </summary>
    public interface IEnrollmentService
    {
        Task<IEnumerable<DateTime>> GetEnrollmentDatesAsync();

        Task<IEnumerable<EnrollmentDTO>> GetEnrollmentsAsync();

        Task<IEnumerable<EnrollmentDTO>> GetEnrollmentsAsync(string filterText);

        Task<IEnumerable<EnrollmentDTO>> GetEnrollmentsAsync(string filterText, DateTime date);

        Task<Enrollment> GetEnrollmentAsync(int enrollmentId);

        Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);

        Task EditEnrollmentAsync(Enrollment enrollment);

        Task RemoveEnrollmentAsync(int enrollmentId);
    }
}
