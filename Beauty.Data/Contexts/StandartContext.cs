using Beauty.Data.Initializers;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Data.Entity;

namespace Beauty.Data.Contexts
{
    public class StandartContext : DbContext, IContext
    {
        private readonly IDatabaseInitializer<StandartContext> contextInitializer;

        public StandartContext(IDatabaseInitializer<StandartContext> contextInitializer, string connectionString) 
            : base(connectionString)
        {
            this.contextInitializer = contextInitializer;
            Database.SetInitializer(contextInitializer);
        }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerPosition> WorkerPositions { get; set; }
    }
}
