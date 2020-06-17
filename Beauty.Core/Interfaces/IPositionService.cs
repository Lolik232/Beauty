using Beauty.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Core.Interfaces
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetPositionsAsync();
    }
}