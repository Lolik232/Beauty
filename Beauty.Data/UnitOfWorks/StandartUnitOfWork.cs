using Beauty.Data.Contexts;
using Beauty.Data.Initializers;
using Beauty.Data.Interfaces;
using Beauty.Data.Repositories;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Beauty.Data.UnitOfWorks
{
    public class StandartUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StandartContext context;

        public IEnrollmentRepository Enrollments { get; }
        public IPositionRepository Positions { get; }
        public IWorkerRepository Workers { get; }
        public IWorkerPositionRepository WorkerPositions { get; }

        public StandartUnitOfWork()
        {
            var contextInitializer = new ContextInitializer();
            var connectionString = "BeautyDatabase";

            context = new StandartContext(contextInitializer, connectionString);

            Enrollments = new StandartEnrollmentRepository(context);
            Positions = new StandartPositionRepository(context);
            Workers = new StandartWorkerRepository(context);
            WorkerPositions = new StandartWorkerPositionRepository(context);
        }
        
        public async Task UpdateAsync(object model)
        {
            context.Entry(model).State = EntityState.Modified;

            await SaveAsync();
        }

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
