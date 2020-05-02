using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Data.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория записей
    /// </summary>
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        Task<IEnumerable<DateTime>> FindEnrollmentDatesAsync();

        Task<IEnumerable<Enrollment>> FindAllAsync(string filterText);

        Task<IEnumerable<Enrollment>> FindAllAsync(string filterText, DateTime filterDate);
    }
}
