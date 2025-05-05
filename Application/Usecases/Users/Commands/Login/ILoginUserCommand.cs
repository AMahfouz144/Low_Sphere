using Application.Usecases.Users.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecases.Users.Commands
{
    public interface ILoginUserCommand
    {
       Task <string> Excute(LoginModel model);
    }
}
