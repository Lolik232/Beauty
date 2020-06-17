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
        Task<string> FindWorkerShortnameAsync(int workerId);
    }
}
