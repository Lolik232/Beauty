using Beauty.Core.Infrastructure;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Interfaces
{
    public interface ILoginService
    {
        Task<IOperationDetails> LoginAsync(Worker worker, string password);
    }
}
