using System;
using System.Collections.Generic;

namespace TMOnline.Shared.Core.Exceptions
{
    [Serializable]
    public class ValidationErrorException : ApplicationException
    {
        public IEnumerable<string> ErrorMessages { get; }

        public ValidationErrorException(IEnumerable<string> errorMessages)
        {
            this.ErrorMessages = errorMessages;
        }
    }
}
