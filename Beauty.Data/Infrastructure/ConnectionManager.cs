using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Data.Infrastructure
{
    public class ConnectionManager
    {
        private static ConnectionManager connectionManager;

        public IDictionary<string, string> ConnectionStrings { get; set; }

        public static ConnectionManager GetConnectionManager()
        {
            if (connectionManager is null)
            {
                var connectionStrings = new Dictionary<string, string>();
                connectionStrings.Add("BeautyDatabase", "Data Source=DESKTOP-4107QQI\\SQLEXPRESS;Initial Catalog=Beauty;Integrated Security=True");

                connectionManager = new ConnectionManager(connectionStrings);
            }

            return connectionManager;
        }

        public ConnectionManager(IDictionary<string, string> connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }
    }
}
