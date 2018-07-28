using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RS.Entities.Entity;

namespace RS.DataAccess.ConcreteRepository
{
    public class BarMenuRepository : GenericRepository<BarMenu>
    {
        public BarMenuRepository(DbContext context) : base(context) { }
    }
}
