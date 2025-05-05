namespace Common.Exceptions
{
    public class BusinessException : CustomException
    {
        public string BusinessRule { set; get; }

        public BusinessException()
            : base(ExceptionType.Business)
        {
            HttpStatusCode = 406;
        }

        public BusinessException(string clientMessage, string businessRule)
            : this()
        {
            this.ClientMessage = clientMessage;
            this.BusinessRule = businessRule;
        }
    }
}
