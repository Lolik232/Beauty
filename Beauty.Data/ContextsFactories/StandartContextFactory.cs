using Beauty.Data.ContextsInitializers;
using Beauty.Data.Contexts;
using System.Data.Entity.Infrastructure;
using Beauty.Data.Infrastructure;

namespace Beauty.Data.ContextsFactories
{
    public class StandartContextFactory : IDbContextFactory<StandartContext>
    {
        public StandartContext Create()
        {
            var contextInitializer = new ContextInitializer();
            var connectionName = ConnectionManager.GetInstance().ConnectionStrings["BeautyDatabase"];

            return new StandartContext(contextInitializer, connectionName);
        }
    }
}
