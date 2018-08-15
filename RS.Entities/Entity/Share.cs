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
        public DateTime UpdateTime { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
