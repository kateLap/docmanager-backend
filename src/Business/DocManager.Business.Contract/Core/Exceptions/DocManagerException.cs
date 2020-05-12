using System;

namespace DocManager.Business.Contract.Core.Exceptions
{
    public class DocManagerException : Exception
    {
        public string CustomMessage { get; }

        public DocManagerException(string customMessage, string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
            CustomMessage = customMessage;
        }

        public DocManagerException(string errorMessage)
            : this(errorMessage, errorMessage)
        {
        }

        public DocManagerException(string customMessage, string errorMessage)
            : base(errorMessage)
        {
            CustomMessage = customMessage;
        }
    }
}
