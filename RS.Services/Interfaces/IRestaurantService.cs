using System;
using System.Collections.Generic;
using System.Text;
using RS.Entities.Interfaces;

namespace RS.Services.Interfaces
{
    public interface IRestaurantService<T> : IBaseService<T> where T : class, IIdentifier<Guid>
    {
    }
}
