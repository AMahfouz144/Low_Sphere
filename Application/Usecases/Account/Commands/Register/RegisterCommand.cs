using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecases.Account.Commands
{
    public class RegisterCommand : IRegisterCommand
    {
        public Task<Guid> Excute(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
