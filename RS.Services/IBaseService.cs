using RS.Entities.Common;
using RS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RS.Services
{
    public interface IBaseGetService<T> : IDisposable where T : class, IIdentifier<Guid>
    {
        IEnumerable<T> All(string[] includes = null);

        T Find(Expression<Func<T, bool>> predicate, string[] includes = null);

        T FindByKey(Guid id);

        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null);

        bool Contains(Expression<Func<T, bool>> predicate);
    }

    public interface IBaseService<T> : IBaseGetService<T> where T : class, IIdentifier<Guid>
    {        
        ServiceResult<T> Create(T entity);

        ServiceResult Update(T entity);

        ServiceResult Update(params T[] entities);

        ServiceResult Delete(Guid id);

        ServiceResult Delete(T entity);

        ServiceResult Delete(Expression<Func<T, bool>> predicate);
    }
}
