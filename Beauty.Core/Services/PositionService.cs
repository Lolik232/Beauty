using Beauty.Core.Interfaces;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beauty.Core.Services
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork unitOfWork;

        public PositionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Position>> GetPositionsAsync()
        {
            return await unitOfWork.Positions.FindAllAsync();
        }
    }
}
