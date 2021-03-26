using System;
using System.Runtime.Serialization;

namespace WaelAlshabaniBlog.Core.Domain.Exception
{
    [Serializable]
    public class InvalidBlogTitleLengthException : System.Exception
    {
        public InvalidBlogTitleLengthException(string? message) : base(message)
        {
        }

        public InvalidBlogTitleLengthException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidBlogTitleLengthException(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
    }
}
