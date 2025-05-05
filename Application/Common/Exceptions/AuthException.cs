namespace Common.Exceptions
{
    public class AuthException : CustomException
    {
        public AuthExceptionType AuthExceptionType { set; get; }

        public AuthException()
            :base(ExceptionType.Auth)
        {
            HttpStatusCode = 401;
        }

        public AuthException(string message, AuthExceptionType type)
            : this()
        {
            this.ClientMessage = message;
            this.AuthExceptionType = type;

            if(type == AuthExceptionType.Expired)
                HttpStatusCode = 451; //Unavailable For Legal Reasons //Need to refresh
        }
    }
}