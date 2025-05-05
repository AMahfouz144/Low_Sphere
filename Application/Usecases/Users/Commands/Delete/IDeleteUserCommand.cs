using Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecases.Users.Commands
{
    public interface IDeleteUserCommand
    {
       Task<bool> Excute(Guid id);
    }
}
