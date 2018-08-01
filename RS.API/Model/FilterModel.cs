using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS.API.Model
{
    public class FilterModel
    {
        public string [] Includes { get; set; }
        public string[] Categories { get; set; }
        public double Rating { get; set; }
    }
}
