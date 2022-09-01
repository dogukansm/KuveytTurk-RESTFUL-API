using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KuveytTurk.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using KuveytTurk.CORE.Entities;

namespace KuveytTurk.CORE.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public async Task<bool> Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                var change = await context.SaveChangesAsync();

                if (change >= 1)
                    return true;

                return false;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                var change =await context.SaveChangesAsync();

                if (change >= 1)
                    return true;
                
                return false;
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var res = await context.Set<TEntity>().SingleOrDefaultAsync(filter);
                return res ?? null;
            }
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                var change =await context.SaveChangesAsync();

                if (change >= 1)
                    return true;
                
                return false;
            }
        }
    }
}
