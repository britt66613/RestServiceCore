using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RS.Entities.Entity;

namespace RS.DataAccess.ConcreteRepository
{
    public class ShareRepository : GenericRepository<Share>
    {
        public ShareRepository(DbContext context) : base(context) { }
    }
}
