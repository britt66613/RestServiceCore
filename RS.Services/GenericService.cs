using RS.DataAccess;
using RS.DataAccess.Db;
using RS.Entities.Common;
using RS.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RS.Services
{
    public abstract class GenericService : IDisposable
    {
        private bool _disposed;

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed) return;
            _disposed = true;
        }
    }

    public abstract class GenericService<T> : GenericService, IBaseService<T> where T : class, IIdentifier<Guid>
    {
        protected IRepository<T> EntityRepo;

        public GenericService(RestaurantContext context)
        {
            EntityRepo = new GenericRepository<T>(context);
        }

        public virtual IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            try
            {
                var result = EntityRepo.Filter(predicate, includes);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual IEnumerable<T> All(string[] includes = null)
        {
            try
            {
                var result = EntityRepo.All(includes);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual T Find(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            try
            {
                var result = EntityRepo.Find(predicate, includes);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual T FindByKey(Guid id)
        {
            try
            {
                var result = EntityRepo.FindByKey(id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual bool Contains(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var result = EntityRepo.Contains(predicate);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual ServiceResult<T> Create(T entity)
        {
            try
            {
                if (entity == null) throw new ArgumentException(nameof(entity));
                var result = new ServiceResult<T>();
                var queryResult = EntityRepo.Create(entity);
                result.Result = queryResult;
                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult<T>(ex);
            }
        }

        public virtual ServiceResult Update(T entity)
        {
            try
            {
                if (entity == null) throw new ArgumentException(nameof(entity));
                var result = new ServiceResult();
                var queryResult = EntityRepo.Update(entity);
                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        public virtual ServiceResult Update(params T[] entities)
        {
            try
            {
                var result = new ServiceResult();
                foreach (var entity in entities)
                {
                    EntityRepo.Update(entity);
                }
                return result;

            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        public virtual ServiceResult Delete(T entity)
        {
            try
            {
                var result = new ServiceResult();
                EntityRepo.Delete(entity);
                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        public virtual ServiceResult Delete(Guid id)
        {
            try
            {
                var result = new ServiceResult();

                var queryResult = EntityRepo.FindByKey(id);

                EntityRepo.Delete(queryResult);

                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }

        public virtual ServiceResult Delete(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var result = new ServiceResult();

                EntityRepo.Delete(predicate);

                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }
    }
}
