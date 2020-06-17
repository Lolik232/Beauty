using Beauty.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Services
{
    public class HttpEndpointCheckerService : IEndpointCheckerService
    {
        private bool disposing;
        private int delay;
        private Action<bool> stateChangedCallback;
        private bool firstCallMade;

        public string Endpoint { get; private set; }
        public bool Result { get; private set; }

        public HttpEndpointCheckerService(string endpoint, int delay, Action<bool> stateChangedCallback)
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
                var response = default(HttpWebResponse);
                var exception = default(Exception);

                try
                {
                    var request = WebRequest.CreateHttp(Endpoint);
                    request.Method = HttpMethod.Get.ToString();

                    response = await request.GetResponseAsync() as HttpWebResponse;
                }

                catch (Exception ex)
                {
                    exception = ex;
                }

                var result = response?.StatusCode == HttpStatusCode.OK;

                response?.Close();

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
