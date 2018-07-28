using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RS.Entities.Entity;

namespace RS.DataAccess.ConcreteRepository
{
    public class FoodMenuRepository : GenericRepository<FoodMenu>
    {
        public FoodMenuRepository(DbContext context) : base(context) { }
    }
}
