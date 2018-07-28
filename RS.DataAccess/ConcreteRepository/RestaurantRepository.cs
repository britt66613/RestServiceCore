using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RS.DataAccess.Interfaces;
using RS.Entities.Entity;

namespace RS.DataAccess.ConcreteRepository
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(DbContext context) : base(context) { }
    }
}
