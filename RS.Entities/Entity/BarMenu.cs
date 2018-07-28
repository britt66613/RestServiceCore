using System;
using System.Collections.Generic;
using System.Text;
using RS.Entities.Enum;

namespace RS.Entities.Entity
{
    public class BarMenu : BaseMenuItem
    {
        public string Ingridients { get; set; }
        public Temperature? Temperature { get; set; }
        public int Amount { get; set; }
    }
}
