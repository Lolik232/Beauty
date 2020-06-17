﻿using Beauty.Data.Contexts;
using Beauty.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Beauty.Data.Repositories
{
    public abstract class BaseStandartRepository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly StandartContext context;

        public BaseStandartRepository(StandartContext context)
        {
            this.context = context;
        }

        public virtual TModel Add(TModel model)
        {
            return context.Set<TModel>().Add(model);
        }

        public virtual IEnumerable<TModel> AddRange(IEnumerable<TModel> models)
        {
            return context.Set<TModel>().AddRange(models);
        }

        public virtual async Task<TModel> FirstAsync()
        {
            return await context.Set<TModel>().FirstOrDefaultAsync();
        }

        public virtual TModel Last()
        {
            return context.Set<TModel>().LastOrDefault();
        }

        public virtual async Task<TModel> FindAsync(int modelId)
        {
            return await context.Set<TModel>().FindAsync(modelId);
        }

        public virtual async Task<IEnumerable<TModel>> FindAllAsync()
        {
            return await context.Set<TModel>().ToListAsync();
        }

        public virtual async Task RemoveAsync(int modelId)
        {
            var model = await FindAsync(modelId);

            context.Set<TModel>().Remove(model);
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<int> modelIds)
        {
            var models = new List<TModel>();

            foreach (var modelId in modelIds)
            {
                var model = await FindAsync(modelId);
                models.Add(model);
            }

            context.Set<TModel>().RemoveRange(models);
        }

        public virtual void RemoveRange(IEnumerable<TModel> models)
        {
            context.Set<TModel>().RemoveRange(models);
        }
    }
}
