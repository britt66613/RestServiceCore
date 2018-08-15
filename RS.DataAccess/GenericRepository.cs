using Microsoft.EntityFrameworkCore;
using RS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RS.DataAccess
{
    public abstract class GenericRepository : IRepository
    {
        protected DbContext Context { get; set; }

        private bool _disposed;

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                Context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class GenericRepository<T> : GenericRepository, IRepository<T> where T : class, IIdentifier<Guid>
    {
        protected DbSet<T> DbSet { get; set; }

        public GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual IQueryable<T> All(string[] includes = null)
        {
            if (includes == null || !includes.Any()) return DbSet.AsQueryable();
            var query = DbSet.Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
            var result = query.AsQueryable();
            return result;
        }
        public virtual T Find(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes == null || !includes.Any()) return DbSet.FirstOrDefault(predicate);
            var query = DbSet.Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
            var result = query.FirstOrDefault(predicate);
            return result;
        }
        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes == null || !includes.Any()) return DbSet.FirstOrDefault(predicate);
            var query = DbSet.Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
            var result = await query.FirstOrDefaultAsync(predicate);
            return result;
        }
        public virtual T FindByKey(Guid key)
        {
            return DbSet.Find(key);
        }
        public virtual async Task<T> FindByKeyAsync(object key)
        {
            return await DbSet.FindAsync(key);
        }
        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes == null || !includes.Any()) return DbSet.Where(predicate).AsQueryable();
            var query = DbSet.Include(includes.First());
            query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
            var result = query.Where(predicate).AsQueryable();
            return result;
        }
        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            var skipCount = index * size;
            IQueryable<T> resetSet;
            if (includes != null && includes.Any())
            {
                var query = DbSet.Include(includes.First());
                query = includes.Skip(1).Aggregate(query, (current, include) => current.Include(include));
                resetSet = predicate != null ? query.Where(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                resetSet = predicate != null ? DbSet.Where(predicate).AsQueryable() : DbSet.AsQueryable();
            }
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            var result = resetSet.AsQueryable();
            return result;
        }
        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        //=====================================================

        public T Create(T item)  
        {
            var result = DbSet.Add(item);
            Context.SaveChanges();
            return result.Entity;     
        }

        public async Task<EntityEntry<T>> CreateAsync(T item)
        {
            var result = Context.Set<T>().Add(item);
            await Context.SaveChangesAsync();
            return result;
        }

        public async Task<T> UpdateAsync(T item)
        {
            T exist = await Context.Set<T>().FindAsync(item.Id);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(item);
                await Context.SaveChangesAsync();
            }
            return exist;
        }

        public T Update(T item)
        {
                T exist = Context.Set<T>().Find(item.Id);
                if (exist != null)
                {
                    Context.Entry(exist).CurrentValues.SetValues(item);
                    Context.SaveChanges();
                }
                return exist;            
        }

        public void Delete(T item)
        {
            using (var context = Context)
            {
                context.Set<T>().Remove(item);
                context.SaveChanges();
            }
        }

        public async Task<int> DeleteAsync(T item)
        {
            Context.Set<T>().Remove(item);
            return await Context.SaveChangesAsync();
        }

        public void  Delete(Expression<Func<T, bool>> predicate)
        {
            var objects = Filter(predicate);
            if (objects.Any()) DbSet.RemoveRange(objects);
            Context.SaveChanges();
        }
    }
}
