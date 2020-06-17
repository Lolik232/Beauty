using System;

namespace Beauty.Core.Interfaces
{
    public interface IEndpointCheckerService : IDisposable
    {
        string Endpoint { get; }
        bool Result { get; }
        void Start();
    }
}
