using System;

namespace Common.Exceptions
{
    public class IdentitySpaceException : Exception
    {
        public string ClientMessage { set; get; }
        public int HttpStatusCode { protected set; get; }
        public ExceptionType Type { set; get; }

        public IdentitySpaceException(ExceptionType type)
        {
            this.Type = type;
        }

        public IdentitySpaceException(string message)
            : base(message)
        {
        }
    }
}