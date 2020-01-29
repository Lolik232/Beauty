using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.WPF.Interfaces
{
    public interface ISecurable
    {
        SecureString SecurePassword { get; }
        bool IsPasswordEmpty { get; }
    }
}
