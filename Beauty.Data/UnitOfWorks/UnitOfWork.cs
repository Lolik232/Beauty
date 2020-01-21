using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using Beauty.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Data.UnitOfWorks
{
    /// <summary>
    /// Класс для работы с репозиториями
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Context context;

        /// <summary>
        /// Возвращает репозиторий записей
        /// </summary>
        public IEnrollmentRepository Enrollments { get; }

        /// <summary>
        /// Возвращает репозиторий должностей сотрудников
        /// </summary>
        public IPositionRepository Positions { get; }

        /// <summary>
        /// Возвращает репозиторий сотрудников
        /// </summary>
        public IWorkerRepository Workers { get; }

        /// <summary>
        /// Возвращает репозиторий конкретного сотрудника и конкретной должности
        /// </summary>
        public IWorkerPositionRepository WorkerPositions { get; }

        public UnitOfWork()
        {
            context = new Context();

            Enrollments = new EnrollmentRepository(context);
            Positions = new PositionRepository(context);
            Workers = new WorkerRepository(context);
            WorkerPositions = new WorkerPositionRepository(context);
        }
        
        /// <summary>
        /// Обновляет модель данных в базе данных
        /// </summary>
        /// <param name="model">Модель данных</param>
        public async Task UpdateAsync(object model)
        {
            context.Entry(model).State = EntityState.Modified;
            await SaveAsync();
        }

        /// <summary>
        /// Сохраняет все изменения моделей данных в базе данных
        /// </summary>
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
