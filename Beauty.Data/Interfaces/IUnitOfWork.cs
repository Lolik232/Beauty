using System.Threading.Tasks;

namespace Beauty.Data.Interfaces
{
    /// <summary>
    /// Интерфейс класс, инкапсулирующего в себе работу с репозиториями
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Репозиторий записей
        /// </summary>
        IEnrollmentRepository Enrollments { get; }

        /// <summary>
        /// Репозиторий должностей
        /// </summary>
        IPositionRepository Positions { get; }

        /// <summary>
        /// Репозиторий сотрудников
        /// </summary>
        IWorkerRepository Workers { get; }

        /// <summary>
        /// Репозиторий должностей, связанных с сотрудниками
        /// </summary>
        IWorkerPositionRepository WorkerPositions { get; }

        /// <summary>
        /// Репозиторий сервисов, связанный с записями
        /// </summary>
        IServiceRepository ServiceRepository { get; }

        /// <summary>
        /// Обновляет модель данных в базе данных
        /// </summary>
        /// <param name="model">Модель данных, которую необходимо обновить</param>
        Task UpdateAsync(object model);

        /// <summary>
        /// Сохраняет все изменения в базу данных
        /// </summary>
        Task<int> SaveAsync();
    }
}