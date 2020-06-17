using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Beauty.Data.Contexts
{
    public class StandartContext : DbContext, IContext
    {
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerPosition> WorkerPositions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<EnrollmentWorkerService> EnrollmentWorkerServices { get; set; }
        public DbSet<PositionService> PositionServices { get; set; }

        public StandartContext(IDatabaseInitializer<StandartContext> contextInitializer, string connectionName) 
            : base(connectionName)
        {
            Database.SetInitializer(contextInitializer);
        }
    }
}
