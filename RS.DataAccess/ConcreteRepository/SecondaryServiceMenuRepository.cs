using RS.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RS.DataAccess.ConcreteRepository
{
    public class SecondaryServiceMenuRepository : GenericRepository<SecondaryServicesMenu>
    {
        public SecondaryServiceMenuRepository(DbContext context) : base(context) { }
    }
}
