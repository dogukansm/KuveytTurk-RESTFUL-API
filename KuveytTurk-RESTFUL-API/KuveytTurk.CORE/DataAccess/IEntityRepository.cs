using KuveytTurk.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KuveytTurk.CORE.Entities;

namespace KuveytTurk.CORE.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
