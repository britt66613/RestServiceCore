using RS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RS.DataAccess
{
    public interface IRepository : IDisposable
    {
        void Save();

        Task<int> SaveAsync();
    }

    public interface IRepository<T> : IRepository where T : class, IIdentifier<Guid>
    {
        IQueryable<T> All(string[] includes = null);

        T Create(T item);

        T Find(Expression<Func<T, bool>> predicate, string[] includes = null);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[] includes = null);

        T FindByKey(Guid key);

        Task<T> FindByKeyAsync(object key);

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null);

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50, string[] includes = null);

        bool Contains(Expression<Func<T, bool>> predicate);

        Task<EntityEntry<T>> CreateAsync(T item);

        Task<T> UpdateAsync(T item);

        T Update(T item);

        void Delete(T item);

        Task<int> DeleteAsync(T item);

        void Delete(Expression<Func<T, bool>> predicate);
    }
}
