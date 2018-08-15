using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RS.Entities.Common
{
    public class ServiceResult
    {
        public virtual bool Succeeded => Errors == null || !Errors.Any();

        public Exception Exception { get; private set; }

        public List<string> Errors { get; set; }

        public ServiceResult()
        {
        }

        public ServiceResult(IEnumerable<string> errors)
        {
            Errors = errors.ToList();
        }

        public ServiceResult(Exception exception)
        {
            Exception = exception;
            string error = ErrorUtils.GetErrorMessage(exception, "Service error");
            if (Errors == null) Errors = new List<string>();
            Errors.Add(error);
        }

        public ServiceResult(string error) : this(new[] { error })
        {
        }

        public virtual string ErrorMessage
        {
            get
            {
                if (Errors != null && Errors.Any())
                {
                    return string.Join(",", Errors.ToArray());
                }
                return null;
            }
        }
    }

    public class ServiceResult<T> : ServiceResult where T : class
    {
        public ServiceResult() { }

        public ServiceResult(T result)
        {
            Result = result;
        }

        public ServiceResult(IEnumerable<string> errors) : base(errors) { }

        public ServiceResult(string error) : base(error) { }

        public ServiceResult(Exception exception) : base(exception) { }

        public T Result { get; set; }

        public override bool Succeeded => Result != null && base.Succeeded;

        public override string ErrorMessage
        {
            get
            {
                if (Errors != null && Errors.Any())
                {
                    return string.Join(", ", Errors.ToArray());
                }
                return Result == null ? "Service error" : null;
            }
        }
    }
}
