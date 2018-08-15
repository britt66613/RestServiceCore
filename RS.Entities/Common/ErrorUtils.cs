using System;
using System.Collections.Generic;
using System.Text;

namespace RS.Entities.Common
{
    public class ErrorUtils
    {
        public static string GetErrorMessage(Exception e, string defaultException)
        {
            if (e.InnerException != null) return GetErrorMessage(e.InnerException, defaultException);
            return !String.IsNullOrEmpty(e.Message) ? e.Message : defaultException;
        }
    }
}
