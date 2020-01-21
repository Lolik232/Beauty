using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Data.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<TModel> AddAsync(int? modelId);
        Task AddRangeAsync(ICollection<int> modelIds);
        Task<TModel> FirstAsync();
        TModel Last();
        Task<TModel> FindAsync(int? modelId);
        Task<ICollection<TModel>> FindAllAsync();
        Task RemoveAsync(int? modelId);
        Task RemoveRangeAsync(ICollection<int> modelIds);
    }
}
