using System;
using System.Collections.Generic;
using System.Linq;
using RS.Services.Interfaces;
using RS.Entities.Entity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RS.DataAccess.Db;
using RS.Entities.Common;

namespace RS.Services.Services
{
    public class RestaurantService : GenericService<Restaurant>, IRestaurantService<Restaurant>
    {
        public RestaurantService(RestaurantContext context) : base(context) { }

        public override ServiceResult<Restaurant> Create(Restaurant entity)
        {
            try
            {
                var result = base.Create(entity);
                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult<Restaurant>(ex);                
            }

        }

        public override ServiceResult Update(Restaurant entity)
        {
            try
            {
                var result = new ServiceResult();
                result = base.Update(entity);
                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }            
        }

        public override ServiceResult Update(params Restaurant[] entities)
        {
            try
            {
                var result = new ServiceResult();
                result =  base.Update(entities);
                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResult(ex);
            }
        }
    }
}
