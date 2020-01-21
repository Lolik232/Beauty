using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Interfaces
{
    public interface ICryptographyService
    {
        string ToMD5Hash(string value);
    }
}
