using System;
using System.Collections.Generic;

namespace TMOnline.Shared.Core.Exceptions
{
    public enum FeatureExceptionType
    {
        Unknown = 1000,
        InvalidOperation,
        RestrictedOperation,
        BlockedOperation
    }

    [Serializable]
    public class FeatureException : ApplicationException
    {
        public FeatureExceptionType ExceptionType { get; }
        public IEnumerable<string> ErrorMessages { get; }

        public FeatureException(FeatureExceptionType exceptionType,params string[] errorMessages)
        {
            this.ExceptionType = exceptionType;
            this.ErrorMessages = errorMessages;
        }
    }
}
