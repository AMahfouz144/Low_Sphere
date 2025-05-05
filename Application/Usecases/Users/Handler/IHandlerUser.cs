using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Usecases.Users
{
    public interface IHandlerUser
    {
        bool IsMobileNumber(string mobileNumber);
        bool IsNID(string NID);
    }
}
