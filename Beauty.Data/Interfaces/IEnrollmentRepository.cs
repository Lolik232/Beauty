using Beauty.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Data.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория записей
    /// </summary>
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        /// <summary>
        /// Возвращает актуальные записи из базы данных
        /// </summary>
        Task<IEnumerable<Enrollment>> FindRelevantEnrollmentsAsync();
    }
}
