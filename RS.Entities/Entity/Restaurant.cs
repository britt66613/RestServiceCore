using RS.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RS.Entities.Interfaces;

namespace RS.Entities.Entity
{
    public class Restaurant : IIdentifier<Guid>
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DefaultValue(Status.Open)]
        public Status Status { get; set; }

        public string CategoryList { get; set; }

        public DateTime Time { get; set; }

        public Guid? LocationId { get; set; }

        public virtual Location Location { get; set; }

        public Guid? MenuId { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
