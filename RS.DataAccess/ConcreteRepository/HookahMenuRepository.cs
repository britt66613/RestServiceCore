﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RS.Entities.Entity;

namespace RS.DataAccess.ConcreteRepository
{
    public class HookahMenuRepository : GenericRepository<HookahMenu>
    {
        public HookahMenuRepository(DbContext context) : base(context) { }
    }
}
