using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Infrastructure
{
    public class LoginDetails : OperationDetails
    {
        public Worker Worker { get; }
        public DateTime DateTime { get; }

        public LoginDetails(Worker worker, DateTime dateTime, bool isFailed)
            : base(isFailed)
        {
            Worker = worker;
            DateTime = dateTime;
        }
    }
}
