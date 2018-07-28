using RS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RS.Services
{
    public interface IBaseService<T>  where T : class, IIdentifier<Guid>
    {
        IEnumerable<T> GetAll(string[] includes = null);

        T Find(Expression<Func<T, bool>> predicate, string[] includes = null);

        T GetByKey(Guid id);
        
        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null);

        bool Contains(Expression<Func<T, bool>> predicate);

        T Create(T entity);

        void Update(T entity);

        void Update(params T[] entities);

        void Delete(Guid id);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> predicate);
    }
}
