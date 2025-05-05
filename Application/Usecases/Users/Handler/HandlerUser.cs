using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Usecases.Users
{
    class HandlerUser : IHandlerUser
    {

        public bool IsMobileNumber(string mobileNumber)
        {
            return new RegexValidation().IsMobileNumber(mobileNumber);
        }

        public bool IsNID(string NID)
        {
            return new RegexValidation().IsNID(NID);
        }
    }
}
