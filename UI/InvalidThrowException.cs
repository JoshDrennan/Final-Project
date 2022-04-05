using System.Runtime.Serialization;

namespace lib
{
    [Serializable]
    internal class InvalidThrowException : Exception
    {
        public InvalidThrowException()
        {
        }

        public InvalidThrowException(string? message) : base(message)
        {
            message = "Invalid roll inputs";
        }

        public InvalidThrowException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidThrowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}