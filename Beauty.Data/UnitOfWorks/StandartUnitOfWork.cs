using Beauty.Data.ContextsFactories;
using Beauty.Data.Contexts;
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
        public IServiceRepository ServiceRepository { get; }

        public StandartUnitOfWork()
        {
            var contextFactory = new StandartContextFactory();
            context = contextFactory.Create();

            Enrollments = new StandartEnrollmentRepository(context);
            Positions = new StandartPositionRepository(context);
            Workers = new StandartWorkerRepository(context);
            WorkerPositions = new StandartWorkerPositionRepository(context);
            ServiceRepository = new StandartServiceRepository(context);
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
