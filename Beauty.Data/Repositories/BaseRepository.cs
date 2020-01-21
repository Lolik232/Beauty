using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Data.Repositories
{
    public abstract class BaseRepository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly Context context;

        public BaseRepository(Context context)
        {
            this.context = context;
        }

        public virtual async Task<TModel> AddAsync(int? modelId)
        {
            var model = await FindAsync(modelId);
            return context.Set<TModel>().Add(model);
        }

        public virtual async Task AddRangeAsync(ICollection<int> modelIds)
        {
            var models = new List<TModel>();

            foreach (var modelId in modelIds)
            {
                var model = await FindAsync(modelId);
                models.Add(model);
            }

            context.Set<TModel>().AddRange(models);
        }

        public virtual async Task<TModel> FirstAsync()
        {
            return await context.Set<TModel>().FirstOrDefaultAsync();
        }

        public virtual TModel Last()
        {
            return context.Set<TModel>().LastOrDefault();
        }

        public virtual async Task<TModel> FindAsync(int? modelId)
        {
            return await context.Set<TModel>().FindAsync(modelId.Value);
        }

        public virtual async Task<ICollection<TModel>> FindAllAsync()
        {
            return await context.Set<TModel>().ToListAsync();
        }

        public virtual async Task RemoveAsync(int? modelId)
        {
            var model = await FindAsync(modelId);
            context.Set<TModel>().Remove(model);
        }

        public virtual async Task RemoveRangeAsync(ICollection<int> modelIds)
        {
            var models = new List<TModel>();

            foreach (var modelId in modelIds)
            {
                var model = await FindAsync(modelId);
                models.Add(model);
            }

            context.Set<TModel>().RemoveRange(models);
        }
    }
}
