using System;

namespace Common.Exceptions
{
    public class CustomException : Exception
    {
        public string ClientMessage { set; get; }
        public int HttpStatusCode { protected set; get; }
        public ExceptionType Type { set; get; }

        public CustomException(ExceptionType type)
        {
            this.Type = type;
        }

        public CustomException(string message)
            : base(message)
        {
        }
    }
}