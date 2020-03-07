using Beauty.Data.Models;
using System.Threading.Tasks;

namespace Beauty.Core.Interfaces
{
    public interface ILoginService
    {
        Task<bool> LoginAsync(int userId, string password);
        void Logout();
    }
}