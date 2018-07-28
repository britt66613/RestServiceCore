using System;
using System.Collections.Generic;
using System.Text;
using RS.Entities.Interfaces;

namespace RS.Entities.Entity
{
    public class BaseMenuItem : IBaseMenuItemDbEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Guid MenuId { get; set; }
        public virtual Menu Menu { get; set; }
    }
}
