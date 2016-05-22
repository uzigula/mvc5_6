using System;
using System.Runtime.Serialization;

namespace System
{
    [Serializable]
    public class NotDataFoundException : Exception
    {
        public NotDataFoundException()
        {
        }

        public NotDataFoundException(string message) : base(message)
        {
        }

        public NotDataFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotDataFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}