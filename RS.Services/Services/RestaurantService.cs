using System;
using System.Collections.Generic;
using System.Linq;
using RS.Services.Interfaces;
using RS.Entities.Entity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RS.DataAccess.Db;

namespace RS.Services.Services
{
    public class RestaurantService : GenericService<Restaurant>, IRestaurantService<Restaurant>
    {
        public RestaurantService(RestaurantContext context) : base(context) { }

        public bool Contains(Expression<Func<Restaurant, bool>> predicate)
        {
            var result = EntityRepo.Contains(predicate);

            return result;
        }

        public Restaurant Create(Restaurant entity)
        {
            var queryResult = EntityRepo.Create(entity);
            return queryResult.Entity;
        }

        public void Delete(Guid id)
        {
            var queryResult = EntityRepo.FindByKey(id);

            EntityRepo.Delete(queryResult);
        }

        public void Delete(Restaurant entity)
        {
            EntityRepo.Delete(entity);
        }

        public void Delete(Expression<Func<Restaurant, bool>> predicate)
        {
            EntityRepo.Delete(predicate);
        }

        public IEnumerable<Restaurant> Filter(Expression<Func<Restaurant, bool>> predicate)
        {
            var result = EntityRepo.Filter(predicate);
            return result;
        }

        public Restaurant Find(Expression<Func<Restaurant, bool>> predicate, string[] includes = null)
        {
            var result = EntityRepo.Find((predicate), includes);
            return result;
        }

        public IEnumerable<Restaurant> GetAll(string[] includes = null)
        {
            var result = EntityRepo.All().Include(restaurant => restaurant.Location)
                                        .Include(restaurant => restaurant.Menu).ThenInclude(menu => menu.FoodMenus);
            return result;
        }

        public Restaurant GetByKey(Guid id)
        {
            var result = EntityRepo.FindByKey(id);
            return result;
        }

        public void Update(Restaurant entity)
        {
            EntityRepo.Update(entity);
        }

        public void Update(params Restaurant[] entities)
        {
            foreach (var entity in entities)
                {
                    EntityRepo.Update(entity);
                }
        }
    }
}
