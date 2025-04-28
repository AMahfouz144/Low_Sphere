using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Common.Exceptions
{
    public class ValidationsException: IdentitySpaceException
    {
        public List<ValidationResult> ValidationData { private set; get; } = new List<ValidationResult>();
        public List<string> InvalidFields { private set; get; } 

        public ValidationsException()
            : base(ExceptionType.Validation)
        {
            HttpStatusCode = 405; 
        }

        public ValidationsException(string clientMessage , string message)
            :base(message)
        {
            HttpStatusCode = 405;
            this.ClientMessage = clientMessage;
            Type = ExceptionType.Validation; 
        }

        public ValidationsException(string clientMessage , List<ValidationResult> validationResult)
            :base(ExceptionType.Validation)
        {
            HttpStatusCode = 405;
            this.ValidationData = validationResult;
            this.ClientMessage = clientMessage;

            this.InvalidFields = validationResult.Select(obj => obj.ErrorMessage)?.ToList();   
        }
    }
}