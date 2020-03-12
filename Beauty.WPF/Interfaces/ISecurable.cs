using System.Security;

namespace Beauty.WPF.Interfaces
{
    public interface ISecurable
    {
        SecureString SecurePassword { get; }
        bool IsPasswordEmpty { get; set; }
    }
}
