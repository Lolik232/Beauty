using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Data.Infrastructure
{
    public class ConnectionManager
    {
        private static ConnectionManager instance;

        public IDictionary<string, string> ConnectionStrings { get; set; }

        public static ConnectionManager GetInstance()
        {
            if (instance is null)
            {
                var connectionStrings = new Dictionary<string, string>();
                connectionStrings.Add("BeautyDatabase", "Data Source=DESKTOP-4107QQI\\SQLEXPRESS;Initial Catalog=Beauty;Integrated Security=True");

                instance = new ConnectionManager(connectionStrings);
            }

            return instance;
        }

        public ConnectionManager(IDictionary<string, string> connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }
    }
}
