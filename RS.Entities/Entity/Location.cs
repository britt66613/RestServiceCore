using System;
using System.Collections.Generic;
using System.Text;
using RS.Entities.Interfaces;

namespace RS.Entities.Entity
{
    public class Location : ILocationDbEntity
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
    }
}
