using RS.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace RS.Entities.Entity
{
    public class Menu : IIdentifier<Guid>
    {
        //Guid
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public virtual ICollection<FoodMenu> FoodMenus { get; set; }
        public virtual ICollection<BarMenu> BarMenus { get; set; }
        public virtual ICollection<HookahMenu> HookahMenus { get; set; }
        public virtual ICollection<SecondaryServicesMenu> SecondaryServicesMenus { get; set; }

        public Menu()
        {
            FoodMenus = new List<FoodMenu>();
            BarMenus = new List<BarMenu>();
            HookahMenus = new List<HookahMenu>();
            SecondaryServicesMenus = new List<SecondaryServicesMenu>();
        }
    }
}
