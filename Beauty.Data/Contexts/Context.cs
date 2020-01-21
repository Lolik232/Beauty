using Beauty.Data.Initializers;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Data.Contexts
{
    public class Context : DbContext
    {
        static Context()
        {
            var contextInitializer = new ContextInitializer();
            Database.SetInitializer(contextInitializer);
        }

        public Context()
            : base("BeautyDatabase")
        { }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerPosition> WorkerPositions { get; set; }
    }
}
