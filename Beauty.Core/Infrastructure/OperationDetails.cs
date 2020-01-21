using Beauty.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Infrastructure
{
    public abstract class OperationDetails : IOperationDetails
    {
        public bool IsFailed { get; }

        public OperationDetails(bool isFailed)
        {
            IsFailed = isFailed;
        }
    }
}
