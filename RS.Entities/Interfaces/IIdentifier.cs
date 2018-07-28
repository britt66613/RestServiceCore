using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Entities.Interfaces
{
    public interface IIdentifier<T>
    {
        T Id { get; set; }
    }
}
