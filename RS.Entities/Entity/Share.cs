using System;
using System.Collections.Generic;
using System.Text;
using RS.Entities.Interfaces;

namespace RS.Entities.Entity
{
    public class Share : IShareDbEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
    }
}
