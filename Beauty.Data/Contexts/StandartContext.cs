using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Data.Entity;

namespace Beauty.Data.Contexts
{
    public class StandartContext : DbContext, IContext
    {
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerPosition> WorkerPositions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<EnrollmentService> EnrollmentServices { get; set; }

        public StandartContext(IDatabaseInitializer<StandartContext> contextInitializer, string connectionString) 
            : base(connectionString)
        {
            Database.SetInitializer(contextInitializer);
        }
    }
}
