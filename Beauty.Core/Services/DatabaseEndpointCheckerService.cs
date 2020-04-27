using Beauty.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Services
{
    public class DatabaseEndpointCheckerService : IEndpointCheckerService
    {
        private bool disposing;
        private int delay;
        private Action<bool> stateChangedCallback;
        private bool firstCallMade;

        public string Endpoint { get; private set; }
        public bool Result { get; private set; }

        public DatabaseEndpointCheckerService(string endpoint, int delay, Action<bool> stateChangedCallback)
        {
            Endpoint = endpoint;
            this.delay = delay;
            this.stateChangedCallback = stateChangedCallback;
        }

        public void Start()
        {
            Task.Run(OnStartExecute);
        }

        private async Task OnStartExecute()
        {
            while (!disposing)
            {
                var sqlConnection = default(SqlConnection);
                var exception = default(Exception);

                try
                {
                    sqlConnection = new SqlConnection(Endpoint);

                    await sqlConnection.OpenAsync();
                }

                catch (Exception ex)
                {
                    exception = ex;
                }

                var result = sqlConnection?.State == ConnectionState.Open;

                sqlConnection?.Close();

                if (!firstCallMade || Result != result)
                {
                    Result = result;
                    stateChangedCallback?.Invoke(Result);
                }

                firstCallMade = true;

                if (!disposing)
                {
                    await Task.Delay(delay);
                }
            }
        }

        public void Dispose()
        {
            disposing = true;
        }
    }
}
