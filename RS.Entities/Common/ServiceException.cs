using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Entities.Common
{
    public class ServiceException : Exception
    {
        public ServiceException()
        {
        }

        public ServiceException(string message) : base(message)
        {
        }
    }
}
